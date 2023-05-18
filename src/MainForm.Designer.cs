namespace Dither
{
    partial class MainForm
    {
        DitherClass dither = new DitherClass();

        string filePath = "";

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        /// 

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        /// 
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LoadButton = new System.Windows.Forms.Button();
            this.EditedPicture = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NoiseLevel = new System.Windows.Forms.TrackBar();
            this.StyleBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.EditedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoiseLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(12, 60);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(90, 45);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // EditedPicture
            // 
            this.EditedPicture.Location = new System.Drawing.Point(12, 12);
            this.EditedPicture.Name = "EditedPicture";
            this.EditedPicture.Size = new System.Drawing.Size(51, 42);
            this.EditedPicture.TabIndex = 1;
            this.EditedPicture.TabStop = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(108, 60);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(90, 45);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // NoiseLevel
            // 
            this.NoiseLevel.Location = new System.Drawing.Point(204, 60);
            this.NoiseLevel.Minimum = 1;
            this.NoiseLevel.Name = "NoiseLevel";
            this.NoiseLevel.Size = new System.Drawing.Size(363, 45);
            this.NoiseLevel.TabIndex = 3;
            this.NoiseLevel.Value = 1;
            this.NoiseLevel.Scroll += new System.EventHandler(this.NoiseLevel_Scroll);
            // 
            // StyleBox
            // 
            this.StyleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StyleBox.FormattingEnabled = true;
            this.StyleBox.Items.AddRange(new object[] {
            "Pastel",
            "SoftBlue",
            "WarmTones",
            "AutumnShades",
            "FluentPurple",
            "BlackAndWhite"});
            this.StyleBox.Location = new System.Drawing.Point(573, 73);
            this.StyleBox.Name = "StyleBox";
            this.StyleBox.Size = new System.Drawing.Size(121, 21);
            this.StyleBox.TabIndex = 0;
            this.StyleBox.SelectedIndexChanged += new System.EventHandler(this.StyleBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 119);
            this.Controls.Add(this.StyleBox);
            this.Controls.Add(this.NoiseLevel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EditedPicture);
            this.Controls.Add(this.LoadButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Dither";
            ((System.ComponentModel.ISupportInitialize)(this.EditedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NoiseLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.PictureBox EditedPicture;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TrackBar NoiseLevel;
        private System.Windows.Forms.ComboBox StyleBox;
    }
}

