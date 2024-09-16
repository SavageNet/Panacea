using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Statistics.Processing;
using static Statistics.Denoise;
using static OriginDatProblem.Converter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ScrollBar;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Graph
{
    public partial class DenoiseForm : Form
    {
        private static List<double> denoisedX;
        private static List<double> denoisedY;
        public DenoiseForm(FileInfo file)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            var dialog = new OpenFileDialog
            {
                Title = "Выберите файл",
                Filter = "All files (*.*)|*.*|ASCII Data (*.dat)|*.dat",
                RestoreDirectory = true,
                InitialDirectory = file == null ? "" : file.DirectoryName
            };
            var saveDialog = new SaveFileDialog
            {
                Title = "Сохранить как",
                Filter = "All files (*.*)|*.*|ASCII Data (*.dat)|*.dat",
                RestoreDirectory = true,
                InitialDirectory = file == null ? "" : file.DirectoryName
            };
            this.numericUpDownIncrement.Value = this.numericUpDownIncrement.Increment;
            this.numericUpDownSmoothValue.Increment = this.numericUpDownIncrement.Value;
            this.numericUpDownSmoothValue.Value = this.numericUpDownIncrement.Value;
            var threshold = (double)numericUpDownSmoothValue.Value;
            this.chart.ChartAreas["Result"].AxisX.LabelStyle.Format = "0";
            this.chart.ChartAreas["PSD"].AxisX.LabelStyle.Format = "0.00"
            this.checkBoxHideOriginal.CheckedChanged += (sender, args) =>
            {
                this.chart.Series["Original"].Color = this.checkBoxHideOriginal.Checked ? Color.Transparent : Color.DeepSkyBlue;
            };
            this.buttonLoad.Click += (sender, args) =>
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(dialog.FileName) && dialog.FileName.EndsWith(".dat"))
                    {
                        file = new FileInfo(dialog.FileName);
                        (denoisedX, denoisedY) = UpdateGraphs(file, threshold);
                        this.labelCurrentFile.Text = String.Format("Текущий файл\n\nИмя файла: {0}\n\nДиректория файла: {1}",
                            file.Name, file.Directory);
                        dialog.InitialDirectory = file.DirectoryName;
                        saveDialog.InitialDirectory = file.DirectoryName;
                    }
                }
            };
            this.numericUpDownIncrement.ValueChanged += (sender, args) =>
            {
                this.numericUpDownSmoothValue.Increment = this.numericUpDownIncrement.Value;
            };
            this.numericUpDownSmoothValue.ValueChanged += (sender, args) =>
            {
                threshold = (double)numericUpDownSmoothValue.Value;
                if (file != null) (denoisedX, denoisedY) = UpdateGraphs(file, threshold);
            };
            this.buttonSave.Click += (sender, args) =>
            {
                if (file != null)
                {
                    var contents = new List<string>()
                    {
                        "Field\tIntensity",
                        ""
                    };
                    for (int i = 0; i < denoisedX.Count; i++)
                        contents.Add(String.Join("\t", denoisedX[i].ToString("0.00000000000").Replace(',', '.'),
                            denoisedY[i].ToString().Replace(',', '.')));
                    File.WriteAllLines(file.FullName, contents);
                    MessageBox.Show("Файл " + file.Name + " успешно перезаписан в директории "
                        + file.DirectoryName + '.', this.Name, MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            };
            this.buttonSaveAs.Click += (sender, args) =>
            {
                if (file != null)
                {
                    saveDialog.FileName = file.Name;
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var contents = new List<string>()
                        {
                            "Field\tIntensity",
                            ""
                        };
                        for (int i = 0; i < denoisedX.Count; i++)
                            contents.Add(String.Join("\t", denoisedX[i].ToString("0.00000000000").Replace(',', '.'),
                                denoisedY[i].ToString().Replace(',', '.')));
                        var resultFullName = saveDialog.FileName.EndsWith(".dat") ? saveDialog.FileName.Trim() : String.Join("", saveDialog.FileName.Trim().Concat(".dat"));
                        var fileToSave = new FileInfo(resultFullName);
                        File.WriteAllLines(fileToSave.FullName, contents);
                        MessageBox.Show("Файл " + fileToSave.Name + " успешно сохранен в директории "
                            + fileToSave.DirectoryName + '.', this.Name, MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
            };
            if (file != null)
            {
                this.labelCurrentFile.Text = String.Format("Текущий файл:\n\nИмя файла: {0}\n\nДиректория файла: {1}",
                    file.Name, file.Directory);
                (denoisedX, denoisedY) = UpdateGraphs(file, threshold);
            }
        }

        private (List<double>, List<double>) UpdateGraphs(FileInfo file, double threshhold)
        {
            var fileData = GetData(file);
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            foreach (var s in this.chart.Series)
                s.Points.Clear();
            foreach (var line in fileData)
            {
                this.chart.Series["Original"].Points.AddXY(line[0], line[1]);
                x.Add(line[0]);
                y.Add(line[1]);
            }
            var DscFilePath = file.FullName
                .Replace(".dat", ".DSC")
                .Replace("Origin compatible ", "");
            var convTime = File.Exists(DscFilePath) ? ExtractFromDSC(file, "ConvTime") : 81.92;
            var imageX = Fourier.FrequencyScale(y.Count, 1000 / convTime);
            (var fourierImageProcessed, var max) = GetProcessedImage(GetImage(y), threshhold);
            for (int i = 0; i < fourierImageProcessed.Length; i++)
            {
                this.chart.Series["FourierPSD"].Points
                    .AddXY(imageX[i], Complex32.Abs(fourierImageProcessed[i]) / max);
            }
            var denoisedY = GetProcessedOriginal(fourierImageProcessed);
            for (int i = 0; i < denoisedY.Length; i++)
            {
                this.chart.Series["Denoised"].Points.AddXY(x[i], denoisedY[i]);
            }
            return (x, denoisedY.ToList());
        }
    }
}
