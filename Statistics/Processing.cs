using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MathNet;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using static System.Net.Mime.MediaTypeNames;

namespace Statistics
{
    public static class Processing
    {
        public static Func<double, double> ApproxByMNK(List<List<double>> fileData)
        {
            var x = new List<double>();
            var y = new List<double>();
            foreach (var line in fileData)
            {
                x.Add(line[0]);
                y.Add(line[1]);
            }
            var k = Cov(x, y) / D(x);
            var b = y.Average() - k * x.Average();
            Console.WriteLine("{0}x {1} {2}\tr^2 = {3}", k, b > 0 ? '+' : '-', Math.Abs(b), Corr(x, y) * Corr(x, y));
            return t => k * t + b;
        }

        public static Func<double, double> ApproxFunc(List<List<double>> fileData)
        {
            var x = new List<double>();
            var y = new List<double>();
            foreach (var line in fileData)
            {
                x.Add(line[0]);
                y.Add(line[1]);
            }
            return t =>
            {
                double x1 = 0;
                double x2 = 0;
                double y1 = 0;
                double y2 = 0;
                for (var i = 0; i < x.Count - 1; i++)
                {
                    if (x[i] <= t && t <= x[i + 1])
                    {
                        (x1, x2) = (x[i], x[i + 1]);
                        (y1, y2) = (y[i], y[i + 1]);
                    }
                }
                return Line(x1, y1, x2, y2)(t);
            };
        }

        private static double Cov(List<double> x, List<double> y)
        {
            var meanX = x.Average();
            var meanY = y.Average();
            return x.Zip(y, (a, b) => (a - meanX) * (b - meanY)).Average();
        }

        private static double D(List<double> x)
        {
            return Cov(x, x);
        }

        private static double Corr(List<double> x, List<double> y)
        {
            return Cov(x, y) / Math.Sqrt(D(x) * D(y));
        }

        private static Func<double, double> Line(double x1, double y1, double x2, double y2)
        {
            return x => y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }

    }

    public static class Denoise
    {
        public static Complex32[] GetImage(List<double> y)
        {
            var image = new Complex32[y.Count];
            for (int i = 0; i < image.Length; i++)
                image[i] = new Complex32((float)y[i], 0);
            Fourier.Forward(image);
            return image;
        }

        public static (Complex32[], double) GetProcessedImage(Complex32[] image, double threshold)
        {
            var result = new Complex32[image.Length];
            var max = image.Max((x) => Complex32.Abs(x));
            for (int i = 0; i < result.Length; i++)
                result[i] = Complex32.Abs(image[i]) < threshold * max ? 0 : image[i];
            return (result, max);
        }

        public static double[] GetProcessedOriginal(Complex32[] processedImage)
        {
            var result_temp = new Complex32[processedImage.Length];
            var result = new double[processedImage.Length];
            processedImage.CopyTo(result_temp, 0);
            Fourier.Inverse(result_temp);
            for (int i = 0; i < result.Length; i++)
                result[i] = result_temp[i].Real;
            return result;
        }

        public static void Test()
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().Location);
        }
    }
}
