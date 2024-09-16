using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OriginDatProblem.Converter;

namespace Graph
{
    public partial class MainForm : Form
    {
        readonly string fitFieldInfo = @"Этот параметр опирается на тот факт,
что резонансное значение магнитного поля
для фона и образца должно быть одинаково,
так как оба измерения проводились при
одинаковом значении магнитного поля.

Если выбран, то спектр образца преобразуется
путем домножения значений по горизонтальной
оси на число, которое обеспечит равенство
резонансных магнитных полей

Для корректной работы необходимо наличите
.DSC файлов в папке с .dat файлами";
        readonly string subtractMNKInfo = @"Если после вычитания фона, спектр образца
будет иметь ненулевой наклон, то программа
вычтет из спектра его линейную аппроксимацию
по МНК";

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            FileInfo fon = null;
            FileInfo file = null;
            var dialog = new OpenFileDialog
            {
                Title = "Выберите файл",
                Filter = "All files (*.*)|*.*|ASCII Data (*.dat)|*.dat",
                RestoreDirectory = true
            };
            this.resultButton.Location = new Point()
            {
                X = (ClientSize.Width - this.resultButton.Width) / 2,
                Y = this.resultButton.Location.Y
            };
            this.subtractBackCheckBox.CheckedChanged += (sender, args) =>
            {
                this.fonBox.Enabled = this.subtractBackCheckBox.Checked;
                this.fonButton.Enabled = this.subtractBackCheckBox.Checked;
                if (!this.subtractBackCheckBox.Checked)
                    this.fonBox.Clear();
            };
            this.fitFieldCheckBox.MouseHover += (sender, args) =>
                this.infoToolTip.SetToolTip(this.fitFieldCheckBox, fitFieldInfo);
            this.subtractMNKCheckBox.MouseHover += (sender, args) =>
                this.infoToolTip.SetToolTip(this.subtractMNKCheckBox, subtractMNKInfo);
            this.fileButton.Click += (sender, args) =>
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.fileBox.Text = dialog.FileName;
                    if (File.Exists(fileBox.Text) && fileBox.Text.EndsWith(".dat"))
                        file = new FileInfo(fileBox.Text);
                    else
                        file = null;
                }
            };
            this.fonButton.Click += (sender, args) =>
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.fonBox.Text = dialog.FileName;
                    if (File.Exists(fonBox.Text) && fonBox.Text.EndsWith(".dat"))
                        fon = new FileInfo(fonBox.Text);
                    else fon = null;
                }  
            };
            this.resultButton.Click += (sender, args) =>
            {
                if (File.Exists(fileBox.Text) && fileBox.Text.EndsWith(".dat"))
                {
                    if (this.subtractBackCheckBox.Checked && fon is null)
                    {
                        MessageBox.Show("Некорректный ввод. Не найден файл фона.", this.Name,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    file = new FileInfo(fileBox.Text);
                    var fitField = this.fitFieldCheckBox.Checked;
                    var subtractMNK = this.subtractMNKCheckBox.Checked;
                    file = CreateResultedFile(file, fon, fitField, subtractMNK);
                    MessageBox.Show("Файл " + file.Name + " успешно создан в директории "
                        + file.DirectoryName + '.', this.Name, MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                    MessageBox.Show("Файл спектра не найден или некорректное расширение файла.", this.Name,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            this.denoiseMenu.Click += (sender, args) =>
            {
                new DenoiseForm(file).Show(); 
            };
            this.developerMenu.Click += (sender, args) =>
            {
                new AboutBox().Show();
            };
            this.fitFieldMethodMenu.Click += (sender, args) =>
            {
                throw new NotImplementedException();
            };
            this.subtractMNKMethodMenu.Click += (sender, args) =>
            {
                throw new NotImplementedException();
            };
            this.denoiseMethodMenu.Click += (sender, args) =>
            {
                throw new NotImplementedException();
            };
            this.methodsInfoMenu.Click += (sender, args) =>
            {
                throw new NotImplementedException();
            };

        }
    }
}
