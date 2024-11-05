namespace Escritorio
{
    partial class CursoUI
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
            TituloLabel = new Label();
            AnioCalendarioLabel = new Label();
            AnioCalendarioTextBox = new TextBox();
            CupoLabel = new Label();
            CupoTextBox = new TextBox();
            ComisionLabel = new Label();
            ComisionComboBox = new ComboBox();
            MateriaLabel = new Label();
            MateriaComboBox = new ComboBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(103, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(85, 37);
            TituloLabel.TabIndex = 10;
            TituloLabel.Text = "Curso";
            // 
            // AnioCalendarioLabel
            // 
            AnioCalendarioLabel.AutoSize = true;
            AnioCalendarioLabel.Location = new Point(32, 67);
            AnioCalendarioLabel.Name = "AnioCalendarioLabel";
            AnioCalendarioLabel.Size = new Size(92, 15);
            AnioCalendarioLabel.TabIndex = 9;
            AnioCalendarioLabel.Text = "Año Calendario:";
            // 
            // AnioCalendarioTextBox
            // 
            AnioCalendarioTextBox.BackColor = SystemColors.ControlDarkDark;
            AnioCalendarioTextBox.ForeColor = SystemColors.Menu;
            AnioCalendarioTextBox.Location = new Point(130, 64);
            AnioCalendarioTextBox.Name = "AnioCalendarioTextBox";
            AnioCalendarioTextBox.Size = new Size(200, 23);
            AnioCalendarioTextBox.TabIndex = 0;
            // 
            // CupoLabel
            // 
            CupoLabel.AutoSize = true;
            CupoLabel.Location = new Point(85, 103);
            CupoLabel.Name = "CupoLabel";
            CupoLabel.Size = new Size(39, 15);
            CupoLabel.TabIndex = 8;
            CupoLabel.Text = "Cupo:";
            // 
            // CupoTextBox
            // 
            CupoTextBox.BackColor = SystemColors.ControlDarkDark;
            CupoTextBox.ForeColor = SystemColors.Menu;
            CupoTextBox.Location = new Point(130, 100);
            CupoTextBox.Name = "CupoTextBox";
            CupoTextBox.Size = new Size(200, 23);
            CupoTextBox.TabIndex = 1;
            // 
            // ComisionLabel
            // 
            ComisionLabel.AutoSize = true;
            ComisionLabel.Location = new Point(63, 140);
            ComisionLabel.Name = "ComisionLabel";
            ComisionLabel.Size = new Size(61, 15);
            ComisionLabel.TabIndex = 7;
            ComisionLabel.Text = "Comision:";
            // 
            // ComisionComboBox
            // 
            ComisionComboBox.BackColor = SystemColors.GrayText;
            ComisionComboBox.ForeColor = SystemColors.Window;
            ComisionComboBox.FormattingEnabled = true;
            ComisionComboBox.Location = new Point(130, 136);
            ComisionComboBox.Name = "ComisionComboBox";
            ComisionComboBox.Size = new Size(200, 23);
            ComisionComboBox.TabIndex = 2;
            // 
            // MateriaLabel
            // 
            MateriaLabel.AutoSize = true;
            MateriaLabel.Location = new Point(74, 175);
            MateriaLabel.Name = "MateriaLabel";
            MateriaLabel.Size = new Size(50, 15);
            MateriaLabel.TabIndex = 6;
            MateriaLabel.Text = "Materia:";
            // 
            // MateriaComboBox
            // 
            MateriaComboBox.BackColor = SystemColors.GrayText;
            MateriaComboBox.ForeColor = SystemColors.Window;
            MateriaComboBox.FormattingEnabled = true;
            MateriaComboBox.Location = new Point(130, 172);
            MateriaComboBox.Name = "MateriaComboBox";
            MateriaComboBox.Size = new Size(200, 23);
            MateriaComboBox.TabIndex = 3;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(66, 214);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 5;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(208, 214);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 4;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // CursoUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 256);
            Controls.Add(TituloLabel);
            Controls.Add(AnioCalendarioLabel);
            Controls.Add(AnioCalendarioTextBox);
            Controls.Add(CupoLabel);
            Controls.Add(CupoTextBox);
            Controls.Add(ComisionLabel);
            Controls.Add(ComisionComboBox);
            Controls.Add(MateriaLabel);
            Controls.Add(MateriaComboBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "CursoUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label AnioCalendarioLabel;
        private TextBox AnioCalendarioTextBox;
        private Label CupoLabel;
        private TextBox CupoTextBox;
        private Label ComisionLabel;
        private ComboBox ComisionComboBox;
        private Label MateriaLabel;
        private ComboBox MateriaComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}