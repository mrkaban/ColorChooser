namespace ColorChooser
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnOpenColorChooser = new System.Windows.Forms.Button();
            this.chkAlmostTop = new System.Windows.Forms.CheckBox();
            this.txtHexFull = new System.Windows.Forms.TextBox();
            this.txtHexShort = new System.Windows.Forms.TextBox();
            this.txtRgbShort = new System.Windows.Forms.TextBox();
            this.txtRgbFull = new System.Windows.Forms.TextBox();
            this.btnPickColor = new System.Windows.Forms.Button();
            this.btnRgbForm = new System.Windows.Forms.Button();
            this.btnRgbForm2 = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenColorChooser
            // 
            this.btnOpenColorChooser.Location = new System.Drawing.Point(218, 11);
            this.btnOpenColorChooser.Name = "btnOpenColorChooser";
            this.btnOpenColorChooser.Size = new System.Drawing.Size(95, 48);
            this.btnOpenColorChooser.TabIndex = 0;
            this.btnOpenColorChooser.Text = "Выбрать из палитры";
            this.btnOpenColorChooser.UseVisualStyleBackColor = true;
            this.btnOpenColorChooser.Click += new System.EventHandler(this.Button1Click);
            // 
            // chkAlmostTop
            // 
            this.chkAlmostTop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAlmostTop.AutoSize = true;
            this.chkAlmostTop.Location = new System.Drawing.Point(218, 88);
            this.chkAlmostTop.Name = "chkAlmostTop";
            this.chkAlmostTop.Size = new System.Drawing.Size(81, 23);
            this.chkAlmostTop.TabIndex = 1;
            this.chkAlmostTop.Text = "Поверх окон";
            this.chkAlmostTop.UseVisualStyleBackColor = true;
            this.chkAlmostTop.CheckedChanged += new System.EventHandler(this.CheckBox1CheckedChanged);
            // 
            // txtHexFull
            // 
            this.txtHexFull.Location = new System.Drawing.Point(12, 12);
            this.txtHexFull.Name = "txtHexFull";
            this.txtHexFull.Size = new System.Drawing.Size(200, 20);
            this.txtHexFull.TabIndex = 2;
            this.txtHexFull.Text = "#000000";
            this.txtHexFull.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
            this.txtHexFull.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHexFullKeyPress);
            this.txtHexFull.Leave += new System.EventHandler(this.TxtHexFullLeave);
            // 
            // txtHexShort
            // 
            this.txtHexShort.Location = new System.Drawing.Point(12, 38);
            this.txtHexShort.Name = "txtHexShort";
            this.txtHexShort.Size = new System.Drawing.Size(200, 20);
            this.txtHexShort.TabIndex = 3;
            this.txtHexShort.Text = "000000";
            this.txtHexShort.TextChanged += new System.EventHandler(this.TextBox2TextChanged);
            this.txtHexShort.Leave += new System.EventHandler(this.TxtHexShortLeave);
            // 
            // txtRgbShort
            // 
            this.txtRgbShort.Location = new System.Drawing.Point(12, 64);
            this.txtRgbShort.Name = "txtRgbShort";
            this.txtRgbShort.ReadOnly = true;
            this.txtRgbShort.Size = new System.Drawing.Size(122, 20);
            this.txtRgbShort.TabIndex = 4;
            this.txtRgbShort.Text = "0,0,0";
            this.txtRgbShort.DoubleClick += new System.EventHandler(this.TextBox3DoubleClick);
            // 
            // txtRgbFull
            // 
            this.txtRgbFull.Location = new System.Drawing.Point(12, 90);
            this.txtRgbFull.Name = "txtRgbFull";
            this.txtRgbFull.ReadOnly = true;
            this.txtRgbFull.Size = new System.Drawing.Size(122, 20);
            this.txtRgbFull.TabIndex = 5;
            this.txtRgbFull.Text = "rgb(0,0,0)";
            this.txtRgbFull.DoubleClick += new System.EventHandler(this.TextBox3DoubleClick);
            // 
            // btnPickColor
            // 
            this.btnPickColor.Location = new System.Drawing.Point(319, 12);
            this.btnPickColor.Name = "btnPickColor";
            this.btnPickColor.Size = new System.Drawing.Size(81, 99);
            this.btnPickColor.TabIndex = 6;
            this.btnPickColor.Text = "Выбор цвета с экрана (зажать и навести)";
            this.btnPickColor.UseVisualStyleBackColor = true;
            this.btnPickColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button2MouseDown);
            this.btnPickColor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button2MouseUp);
            // 
            // btnRgbForm
            // 
            this.btnRgbForm.Location = new System.Drawing.Point(137, 63);
            this.btnRgbForm.Name = "btnRgbForm";
            this.btnRgbForm.Size = new System.Drawing.Size(75, 22);
            this.btnRgbForm.TabIndex = 7;
            this.btnRgbForm.Text = "Настроить";
            this.btnRgbForm.UseVisualStyleBackColor = true;
            this.btnRgbForm.Click += new System.EventHandler(this.BtnRgbFormClick);
            // 
            // btnRgbForm2
            // 
            this.btnRgbForm2.Location = new System.Drawing.Point(137, 89);
            this.btnRgbForm2.Name = "btnRgbForm2";
            this.btnRgbForm2.Size = new System.Drawing.Size(75, 22);
            this.btnRgbForm2.TabIndex = 8;
            this.btnRgbForm2.Text = "Настроить";
            this.btnRgbForm2.UseVisualStyleBackColor = true;
            this.btnRgbForm2.Click += new System.EventHandler(this.BtnRgbFormClick);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(218, 63);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(95, 22);
            this.btnInvert.TabIndex = 9;
            this.btnInvert.Text = "Инвертировать";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(410, 119);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.btnRgbForm2);
            this.Controls.Add(this.btnRgbForm);
            this.Controls.Add(this.btnPickColor);
            this.Controls.Add(this.txtRgbFull);
            this.Controls.Add(this.txtRgbShort);
            this.Controls.Add(this.txtHexShort);
            this.Controls.Add(this.txtHexFull);
            this.Controls.Add(this.chkAlmostTop);
            this.Controls.Add(this.btnOpenColorChooser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Цветовая пипетка для экрана от КонтинентСвободы.рф";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenColorChooser;
        private System.Windows.Forms.CheckBox chkAlmostTop;
        private System.Windows.Forms.TextBox txtHexFull;
        private System.Windows.Forms.TextBox txtHexShort;
        private System.Windows.Forms.TextBox txtRgbShort;
        private System.Windows.Forms.TextBox txtRgbFull;
        private System.Windows.Forms.Button btnPickColor;
		private System.Windows.Forms.Button btnRgbForm;
		private System.Windows.Forms.Button btnRgbForm2;
		private System.Windows.Forms.Button btnInvert;
    }
}

