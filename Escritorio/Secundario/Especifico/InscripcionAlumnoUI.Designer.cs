namespace Escritorio
{
    partial class InscripcionAlumnoUI
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
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(88, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(144, 37);
            TituloLabel.TabIndex = 4;
            TituloLabel.Text = "Inscripcion";
            // 
            // CursoLabel
            // 
            CursoLabel.AutoSize = true;
            CursoLabel.Location = new Point(30, 66);
            CursoLabel.Name = "CursoLabel";
            CursoLabel.Size = new Size(41, 15);
            CursoLabel.TabIndex = 3;
            CursoLabel.Text = "Curso:";
            // 
            // CursoComboBox
            // 
            CursoComboBox.BackColor = SystemColors.GrayText;
            CursoComboBox.ForeColor = SystemColors.Window;
            CursoComboBox.FormattingEnabled = true;
            CursoComboBox.Location = new Point(82, 64);
            CursoComboBox.Name = "CursoComboBox";
            CursoComboBox.Size = new Size(278, 23);
            CursoComboBox.TabIndex = 0;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(99, 105);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 2;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(240, 105);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 1;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // InscripcionAlumnoUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(408, 146);
            Controls.Add(TituloLabel);
            Controls.Add(CursoLabel);
            Controls.Add(CursoComboBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "InscripcionAlumnoUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label CursoLabel;
        private ComboBox CursoComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}