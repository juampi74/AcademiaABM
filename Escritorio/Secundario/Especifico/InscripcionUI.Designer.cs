namespace Escritorio
{
    partial class InscripcionUI
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
            TituloLabel.Location = new Point(80, 8);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(144, 37);
            TituloLabel.TabIndex = 10;
            TituloLabel.Text = "Inscripcion";
            // 
            // CursoLabel
            // 
            CursoLabel.AutoSize = true;
            CursoLabel.Location = new Point(46, 61);
            CursoLabel.Name = "CursoLabel";
            CursoLabel.Size = new Size(41, 15);
            CursoLabel.TabIndex = 9;
            CursoLabel.Text = "Curso:";
            // 
            // CursoComboBox
            // 
            CursoComboBox.BackColor = SystemColors.GrayText;
            CursoComboBox.ForeColor = SystemColors.Window;
            CursoComboBox.FormattingEnabled = true;
            CursoComboBox.Location = new Point(93, 59);
            CursoComboBox.Name = "CursoComboBox";
            CursoComboBox.Size = new Size(248, 23);
            CursoComboBox.TabIndex = 0;
            // 
            // AlumnoLabel
            // 
            AlumnoLabel.AutoSize = true;
            AlumnoLabel.Location = new Point(33, 103);
            AlumnoLabel.Name = "AlumnoLabel";
            AlumnoLabel.Size = new Size(53, 15);
            AlumnoLabel.TabIndex = 8;
            AlumnoLabel.Text = "Alumno:";
            // 
            // AlumnoComboBox
            // 
            AlumnoComboBox.BackColor = SystemColors.GrayText;
            AlumnoComboBox.ForeColor = SystemColors.Window;
            AlumnoComboBox.FormattingEnabled = true;
            AlumnoComboBox.Location = new Point(93, 101);
            AlumnoComboBox.Name = "AlumnoComboBox";
            AlumnoComboBox.Size = new Size(248, 23);
            AlumnoComboBox.TabIndex = 1;
            // 
            // CondicionLabel
            // 
            CondicionLabel.AutoSize = true;
            CondicionLabel.Location = new Point(21, 144);
            CondicionLabel.Name = "CondicionLabel";
            CondicionLabel.Size = new Size(65, 15);
            CondicionLabel.TabIndex = 7;
            CondicionLabel.Text = "Condicion:";
            // 
            // CondicionTextBox
            // 
            CondicionTextBox.BackColor = SystemColors.ControlDarkDark;
            CondicionTextBox.ForeColor = SystemColors.Menu;
            CondicionTextBox.Location = new Point(92, 141);
            CondicionTextBox.Name = "CondicionTextBox";
            CondicionTextBox.Size = new Size(251, 23);
            CondicionTextBox.TabIndex = 2;
            // 
            // NotaLabel
            // 
            NotaLabel.AutoSize = true;
            NotaLabel.Location = new Point(49, 183);
            NotaLabel.Name = "NotaLabel";
            NotaLabel.Size = new Size(36, 15);
            NotaLabel.TabIndex = 6;
            NotaLabel.Text = "Nota:";
            // 
            // NotaTextBox
            // 
            NotaTextBox.BackColor = SystemColors.ControlDarkDark;
            NotaTextBox.ForeColor = SystemColors.Menu;
            NotaTextBox.Location = new Point(92, 180);
            NotaTextBox.Name = "NotaTextBox";
            NotaTextBox.Size = new Size(251, 23);
            NotaTextBox.TabIndex = 3;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(78, 221);
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
            GuardarButton.Location = new Point(219, 221);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 4;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // InscripcionUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 261);
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
            Name = "InscripcionUI";
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