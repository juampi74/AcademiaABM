namespace Escritorio
{
    partial class DictadoUI
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
            CursoLabel = new Label();
            CursoComboBox = new ComboBox();
            DocenteLabel = new Label();
            DocenteComboBox = new ComboBox();
            CargoLabel = new Label();
            CargoTextBox = new TextBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(140, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(110, 37);
            TituloLabel.TabIndex = 8;
            TituloLabel.Text = "Dictado";
            // 
            // CursoLabel
            // 
            CursoLabel.AutoSize = true;
            CursoLabel.Location = new Point(46, 103);
            CursoLabel.Name = "CursoLabel";
            CursoLabel.Size = new Size(41, 15);
            CursoLabel.TabIndex = 7;
            CursoLabel.Text = "Curso:";
            // 
            // CursoComboBox
            // 
            CursoComboBox.BackColor = SystemColors.GrayText;
            CursoComboBox.ForeColor = SystemColors.Window;
            CursoComboBox.FormattingEnabled = true;
            CursoComboBox.Location = new Point(93, 100);
            CursoComboBox.Name = "CursoComboBox";
            CursoComboBox.Size = new Size(320, 23);
            CursoComboBox.TabIndex = 0;
            // 
            // DocenteLabel
            // 
            DocenteLabel.AutoSize = true;
            DocenteLabel.Location = new Point(33, 67);
            DocenteLabel.Name = "DocenteLabel";
            DocenteLabel.Size = new Size(54, 15);
            DocenteLabel.TabIndex = 6;
            DocenteLabel.Text = "Docente:";
            // 
            // DocenteComboBox
            // 
            DocenteComboBox.BackColor = SystemColors.GrayText;
            DocenteComboBox.ForeColor = SystemColors.Window;
            DocenteComboBox.FormattingEnabled = true;
            DocenteComboBox.Location = new Point(93, 64);
            DocenteComboBox.Name = "DocenteComboBox";
            DocenteComboBox.Size = new Size(320, 23);
            DocenteComboBox.TabIndex = 1;
            // 
            // CargoLabel
            // 
            CargoLabel.AutoSize = true;
            CargoLabel.Location = new Point(45, 140);
            CargoLabel.Name = "CargoLabel";
            CargoLabel.Size = new Size(42, 15);
            CargoLabel.TabIndex = 5;
            CargoLabel.Text = "Cargo:";
            // 
            // CargoTextBox
            // 
            CargoTextBox.BackColor = SystemColors.ControlDarkDark;
            CargoTextBox.ForeColor = SystemColors.Menu;
            CargoTextBox.Location = new Point(93, 136);
            CargoTextBox.Name = "CargoTextBox";
            CargoTextBox.Size = new Size(320, 23);
            CargoTextBox.TabIndex = 2;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(115, 180);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 4;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(256, 180);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 3;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // DictadoUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 221);
            Controls.Add(TituloLabel);
            Controls.Add(CursoLabel);
            Controls.Add(CursoComboBox);
            Controls.Add(DocenteLabel);
            Controls.Add(DocenteComboBox);
            Controls.Add(CargoLabel);
            Controls.Add(CargoTextBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "DictadoUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label CursoLabel;
        private ComboBox CursoComboBox;
        private Label DocenteLabel;
        private ComboBox DocenteComboBox;
        private Label CargoLabel;
        private TextBox CargoTextBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}