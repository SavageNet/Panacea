using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using static Statistics.Processing;

namespace OriginDatProblem
{
    public class Converter
    {
        public static List<string> ToListString(List<List<double>> fileData)
        {
            var result = new List<string>
            {
                "Field\tIntensity",
                ""
            };
            foreach (List<double> line in fileData) 
                result.Add(String.Join("\t", line[0].ToString("0.00000000000").Replace(',', '.'),
                    line[1].ToString().Replace(',', '.')));
            return result;
        }

        public static List<double> GetDataFromLine(string line)
        {
            try
            {
                var wordsStringArray = Regex.Replace(line, @"\s+", " ").Trim().Split(' ');
                if (wordsStringArray.Length == 3)
                {
                    double index = int.Parse(wordsStringArray[0],
                        CultureInfo.InvariantCulture);
                    double field = double.Parse(wordsStringArray[1],
                        CultureInfo.InvariantCulture);
                    double intensity = double.Parse(wordsStringArray[2],
                        CultureInfo.InvariantCulture);
                    return new List<double>() { field, intensity };
                }
                else
                {
                    double field = double.Parse(wordsStringArray[0].Replace(',', '.'),
                        CultureInfo.InvariantCulture);
                    double intensity = double.Parse(wordsStringArray[1].Replace(',', '.'),
                        CultureInfo.InvariantCulture);
                    return new List<double>() { field, intensity };
                }
            }
            catch { return null; }
        }

        public static List<List<double>> GetData(FileInfo file)
        {
            StreamReader reader = file.OpenText();
            var data = new List<List<double>>();
            var line = reader.ReadLine();
            while (line != null)
            {
                var lineData = GetDataFromLine(line);
                if (lineData != null) data.Add(lineData);
                line = reader.ReadLine();
            }
            reader.Close();
            return data;
        }

        /// <summary>
        /// Этот медод создаст совместимый для загрузки в OriginLab dat файл в папке,
        /// где находится спектр эпр "file".
        /// При этом если передать в метод файл "fon", в котором находится спекр эпр фона,
        /// то медод совместитит первые точки фона и спектра и вычтет фон.
        /// Если fon будет null, то вычитания не будет
        /// </summary>
        public static FileInfo CreateResultedFile(FileInfo file, FileInfo fon,
            bool fitField = false, bool subtractMNK = false)
        {
            var fileData = GetData(file);
            if (fon != null)
            {
                var fonData = GetData(fon);
                if (fitField)
                {
                    var fileMWFQ = ExtractFromDSC(file, "MWFQ");
                    var fonMWFQ = ExtractFromDSC(fon, "MWFQ");
                    var k = fonMWFQ / fileMWFQ;
                    foreach (var line in fileData)
                        line[0] *= k;
                }
                fileData = SubtractFon(fileData, fonData);
            }
            if (subtractMNK)
            {
                var f = ApproxByMNK(fileData);
                foreach (var line in fileData)
                    line[1] -= f(line[0]);
            }
            return CreateRewritedFile(file, fileData);
        }

        static List<List<double>> SubtractFon(List<List<double>> fileData, List<List<double>> fonData)
        {
            var f = ApproxFunc(fileData);
            var resultFileData = new List<List<double>>();
            foreach (var line in fonData)
            {
                var fonX = line[0];
                var fonY = line[1];
                if (fileData[0][0] <= fonX && fonX <= fileData[fileData.Count - 1][0])
                {
                    resultFileData.Add(new List<double>()
                        {
                            fonX,
                            f(fonX) - fonY
                        });
                }
            }
            return resultFileData;
        }

        public static FileInfo CreateRewritedFile(FileInfo oldFile, List<List<double>> fileData)
        {
            if (oldFile.DirectoryName == null) throw new Exception("Dirrectory is invalid");
            var resultFile = new FileInfo(
                Path.Combine(oldFile.DirectoryName, "Origin compatible " + oldFile.Name));
            File.WriteAllLines(resultFile.FullName, ToListString(fileData));
            return resultFile;
        }

        public static double ExtractFromDSC(FileInfo file, string target)
        {
            var filePath = file.FullName
                .Replace(".dat", ".DSC")
                .Replace("Origin compatible ", "");
            var fileMWFQ = File.ReadAllText(filePath).Split('\n').
                Where(line => line.Contains(target))
                .First();
            fileMWFQ = Regex.Replace(fileMWFQ, @"\s+", " ").Trim().Split(' ')[1];
            return double.Parse(fileMWFQ, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        static void Main()
        {
            var path = "C:\\Users\\for_g\\OneDrive\\Desktop\\Универ\\Разобраться с ориджином";
            var fileName = "SnO300 — копия.dat";
            var fonName = "Fon — копия.dat";
            var filePath = Path.Combine(path, fileName);
            var fonPath = Path.Combine(path, fonName);

            var file = new FileInfo(filePath);
            var fon = new FileInfo(fonPath);

            CreateResultedFile(file, fon);
        }

    }
}