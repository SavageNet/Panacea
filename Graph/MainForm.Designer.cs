namespace Graph
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.processingMethodsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.denoiseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.methodsInfoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fitFieldMethodMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractMNKMethodMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.denoiseMethodMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.developerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.symbol = new System.Windows.Forms.PictureBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fonLabel = new System.Windows.Forms.Label();
            this.fileBox = new System.Windows.Forms.TextBox();
            this.fonBox = new System.Windows.Forms.TextBox();
            this.fileButton = new System.Windows.Forms.Button();
            this.fonButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.fitFieldCheckBox = new System.Windows.Forms.CheckBox();
            this.subtractMNKCheckBox = new System.Windows.Forms.CheckBox();
            this.subtractBackCheckBox = new System.Windows.Forms.CheckBox();
            this.infoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbol)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processingMethodsMenu,
            this.referenceMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(933, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // processingMethodsMenu
            // 
            this.processingMethodsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.denoiseMenu});
            this.processingMethodsMenu.Name = "processingMethodsMenu";
            this.processingMethodsMenu.Size = new System.Drawing.Size(79, 20);
            this.processingMethodsMenu.Text = "Обработка";
            // 
            // denoiseMenu
            // 
            this.denoiseMenu.Name = "denoiseMenu";
            this.denoiseMenu.Size = new System.Drawing.Size(169, 22);
            this.denoiseMenu.Text = "Обработка шума";
            // 
            // referenceMenu
            // 
            this.referenceMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.methodsInfoMenu,
            this.developerMenu});
            this.referenceMenu.Name = "referenceMenu";
            this.referenceMenu.Size = new System.Drawing.Size(65, 20);
            this.referenceMenu.Text = "Справка";
            // 
            // methodsInfoMenu
            // 
            this.methodsInfoMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fitFieldMethodMenu,
            this.subtractMNKMethodMenu,
            this.denoiseMethodMenu});
            this.methodsInfoMenu.Name = "methodsInfoMenu";
            this.methodsInfoMenu.Size = new System.Drawing.Size(250, 22);
            this.methodsInfoMenu.Text = "Справка по методам обработки";
            // 
            // fitFieldMethodMenu
            // 
            this.fitFieldMethodMenu.Name = "fitFieldMethodMenu";
            this.fitFieldMethodMenu.Size = new System.Drawing.Size(210, 22);
            this.fitFieldMethodMenu.Text = "Подгон магнитного пля";
            // 
            // subtractMNKMethodMenu
            // 
            this.subtractMNKMethodMenu.Name = "subtractMNKMethodMenu";
            this.subtractMNKMethodMenu.Size = new System.Drawing.Size(210, 22);
            this.subtractMNKMethodMenu.Text = "Исключение наклона";
            // 
            // denoiseMethodMenu
            // 
            this.denoiseMethodMenu.Name = "denoiseMethodMenu";
            this.denoiseMethodMenu.Size = new System.Drawing.Size(210, 22);
            this.denoiseMethodMenu.Text = "Метод шумоподавления";
            // 
            // developerMenu
            // 
            this.developerMenu.Name = "developerMenu";
            this.developerMenu.Size = new System.Drawing.Size(250, 22);
            this.developerMenu.Text = "Разработчик";
            // 
            // symbol
            // 
            this.symbol.Image = ((System.Drawing.Image)(resources.GetObject("symbol.Image")));
            this.symbol.InitialImage = null;
            this.symbol.Location = new System.Drawing.Point(771, 12);
            this.symbol.Name = "symbol";
            this.symbol.Size = new System.Drawing.Size(150, 150);
            this.symbol.TabIndex = 1;
            this.symbol.TabStop = false;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.Location = new System.Drawing.Point(12, 60);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(753, 102);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Данная программа создаст удобный для загрузки в OriginLab .dat файл в папке, где " +
    "находится спектр эпр, полученный из прибора.";
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileLabel.Location = new System.Drawing.Point(12, 269);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(77, 15);
            this.fileLabel.TabIndex = 3;
            this.fileLabel.Text = "Спектр (.dat)";
            // 
            // fonLabel
            // 
            this.fonLabel.AutoSize = true;
            this.fonLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fonLabel.Location = new System.Drawing.Point(12, 339);
            this.fonLabel.Name = "fonLabel";
            this.fonLabel.Size = new System.Drawing.Size(61, 15);
            this.fonLabel.TabIndex = 4;
            this.fonLabel.Text = "Фон (.dat)";
            // 
            // fileBox
            // 
            this.fileBox.Location = new System.Drawing.Point(12, 285);
            this.fileBox.Multiline = true;
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(713, 23);
            this.fileBox.TabIndex = 5;
            // 
            // fonBox
            // 
            this.fonBox.Location = new System.Drawing.Point(12, 355);
            this.fonBox.Multiline = true;
            this.fonBox.Name = "fonBox";
            this.fonBox.Size = new System.Drawing.Size(713, 23);
            this.fonBox.TabIndex = 6;
            // 
            // fileButton
            // 
            this.fileButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileButton.Location = new System.Drawing.Point(772, 284);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(114, 25);
            this.fileButton.TabIndex = 7;
            this.fileButton.Text = "Обзор";
            this.fileButton.UseVisualStyleBackColor = true;
            // 
            // fonButton
            // 
            this.fonButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fonButton.Location = new System.Drawing.Point(772, 354);
            this.fonButton.Name = "fonButton";
            this.fonButton.Size = new System.Drawing.Size(114, 25);
            this.fonButton.TabIndex = 8;
            this.fonButton.Text = "Обзор";
            this.fonButton.UseVisualStyleBackColor = true;
            // 
            // resultButton
            // 
            this.resultButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultButton.Location = new System.Drawing.Point(373, 417);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(175, 69);
            this.resultButton.TabIndex = 9;
            this.resultButton.Text = "Подготовить данные";
            this.resultButton.UseVisualStyleBackColor = true;
            // 
            // fitFieldCheckBox
            // 
            this.fitFieldCheckBox.AutoSize = true;
            this.fitFieldCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fitFieldCheckBox.Location = new System.Drawing.Point(694, 417);
            this.fitFieldCheckBox.Name = "fitFieldCheckBox";
            this.fitFieldCheckBox.Size = new System.Drawing.Size(227, 21);
            this.fitFieldCheckBox.TabIndex = 10;
            this.fitFieldCheckBox.Text = "Подогнать поле спектра под фон";
            this.fitFieldCheckBox.UseVisualStyleBackColor = true;
            // 
            // subtractMNKCheckBox
            // 
            this.subtractMNKCheckBox.AutoSize = true;
            this.subtractMNKCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subtractMNKCheckBox.Location = new System.Drawing.Point(694, 442);
            this.subtractMNKCheckBox.Name = "subtractMNKCheckBox";
            this.subtractMNKCheckBox.Size = new System.Drawing.Size(165, 21);
            this.subtractMNKCheckBox.TabIndex = 11;
            this.subtractMNKCheckBox.Text = "Убрать наклон спектра\r\n";
            this.subtractMNKCheckBox.UseVisualStyleBackColor = true;
            // 
            // subtractBackCheckBox
            // 
            this.subtractBackCheckBox.AutoSize = true;
            this.subtractBackCheckBox.Checked = true;
            this.subtractBackCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.subtractBackCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.subtractBackCheckBox.Location = new System.Drawing.Point(694, 467);
            this.subtractBackCheckBox.Name = "subtractBackCheckBox";
            this.subtractBackCheckBox.Size = new System.Drawing.Size(103, 21);
            this.subtractBackCheckBox.TabIndex = 12;
            this.subtractBackCheckBox.Text = "Вычесть фон\r\n";
            this.subtractBackCheckBox.UseVisualStyleBackColor = true;
            // 
            // infoToolTip
            // 
            this.infoToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.infoToolTip.ToolTipTitle = "Информация";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.subtractBackCheckBox);
            this.Controls.Add(this.subtractMNKCheckBox);
            this.Controls.Add(this.fitFieldCheckBox);
            this.Controls.Add(this.resultButton);
            this.Controls.Add(this.fonButton);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.fonBox);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.fonLabel);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.symbol);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Panacea";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.symbol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem processingMethodsMenu;
        private System.Windows.Forms.ToolStripMenuItem referenceMenu;
        private System.Windows.Forms.ToolStripMenuItem denoiseMenu;
        private System.Windows.Forms.ToolStripMenuItem developerMenu;
        private System.Windows.Forms.ToolStripMenuItem methodsInfoMenu;
        private System.Windows.Forms.ToolStripMenuItem fitFieldMethodMenu;
        private System.Windows.Forms.ToolStripMenuItem subtractMNKMethodMenu;
        private System.Windows.Forms.ToolStripMenuItem denoiseMethodMenu;
        private System.Windows.Forms.PictureBox symbol;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Label fonLabel;
        private System.Windows.Forms.TextBox fileBox;
        private System.Windows.Forms.TextBox fonBox;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.Button fonButton;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.CheckBox fitFieldCheckBox;
        private System.Windows.Forms.CheckBox subtractMNKCheckBox;
        private System.Windows.Forms.CheckBox subtractBackCheckBox;
        private System.Windows.Forms.ToolTip infoToolTip;
    }
}