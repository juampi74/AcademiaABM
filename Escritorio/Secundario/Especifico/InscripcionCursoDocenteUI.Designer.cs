namespace Escritorio
{
    partial class InscripcionCursoDocenteUI
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
            AlumnoLabel = new Label();
            AlumnoComboBox = new ComboBox();
            CondicionLabel = new Label();
            CondicionTextBox = new TextBox();
            NotaLabel = new Label();
            NotaTextBox = new TextBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(122, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(144, 37);
            TituloLabel.TabIndex = 10;
            TituloLabel.Text = "Inscripcion";
            // 
            // CursoLabel
            // 
            CursoLabel.AutoSize = true;
            CursoLabel.Location = new Point(39, 103);
            CursoLabel.Name = "CursoLabel";
            CursoLabel.Size = new Size(41, 15);
            CursoLabel.TabIndex = 8;
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
            CursoComboBox.TabIndex = 1;
            // 
            // AlumnoLabel
            // 
            AlumnoLabel.AutoSize = true;
            AlumnoLabel.Location = new Point(27, 67);
            AlumnoLabel.Name = "AlumnoLabel";
            AlumnoLabel.Size = new Size(53, 15);
            AlumnoLabel.TabIndex = 9;
            AlumnoLabel.Text = "Alumno:";
            // 
            // AlumnoComboBox
            // 
            AlumnoComboBox.BackColor = SystemColors.GrayText;
            AlumnoComboBox.ForeColor = SystemColors.Window;
            AlumnoComboBox.FormattingEnabled = true;
            AlumnoComboBox.Location = new Point(93, 64);
            AlumnoComboBox.Name = "AlumnoComboBox";
            AlumnoComboBox.Size = new Size(320, 23);
            AlumnoComboBox.TabIndex = 0;
            // 
            // CondicionLabel
            // 
            CondicionLabel.AutoSize = true;
            CondicionLabel.Location = new Point(16, 175);
            CondicionLabel.Name = "CondicionLabel";
            CondicionLabel.Size = new Size(65, 15);
            CondicionLabel.TabIndex = 6;
            CondicionLabel.Text = "Condicion:";
            // 
            // CondicionTextBox
            // 
            CondicionTextBox.BackColor = SystemColors.ControlDarkDark;
            CondicionTextBox.ForeColor = SystemColors.Menu;
            CondicionTextBox.Location = new Point(93, 172);
            CondicionTextBox.Name = "CondicionTextBox";
            CondicionTextBox.Size = new Size(320, 23);
            CondicionTextBox.TabIndex = 3;
            // 
            // NotaLabel
            // 
            NotaLabel.AutoSize = true;
            NotaLabel.Location = new Point(45, 139);
            NotaLabel.Name = "NotaLabel";
            NotaLabel.Size = new Size(36, 15);
            NotaLabel.TabIndex = 7;
            NotaLabel.Text = "Nota:";
            // 
            // NotaTextBox
            // 
            NotaTextBox.BackColor = SystemColors.ControlDarkDark;
            NotaTextBox.ForeColor = SystemColors.Menu;
            NotaTextBox.Location = new Point(93, 136);
            NotaTextBox.Name = "NotaTextBox";
            NotaTextBox.Size = new Size(320, 23);
            NotaTextBox.TabIndex = 2;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(113, 217);
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
            GuardarButton.Location = new Point(254, 217);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 4;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // InscripcionCursoDocenteUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 261);
            Controls.Add(TituloLabel);
            Controls.Add(CursoLabel);
            Controls.Add(CursoComboBox);
            Controls.Add(AlumnoLabel);
            Controls.Add(AlumnoComboBox);
            Controls.Add(CondicionLabel);
            Controls.Add(CondicionTextBox);
            Controls.Add(NotaLabel);
            Controls.Add(NotaTextBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "InscripcionCursoDocenteUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label CursoLabel;
        private ComboBox CursoComboBox;
        private Label AlumnoLabel;
        private ComboBox AlumnoComboBox;
        private Label CondicionLabel;
        private TextBox CondicionTextBox;
        private Label NotaLabel;
        private TextBox NotaTextBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}