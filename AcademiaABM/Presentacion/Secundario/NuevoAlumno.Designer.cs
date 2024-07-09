namespace AcademiaABM.Presentacion
{
    partial class NuevoAlumno
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
            ApellidoTextBox = new TextBox();
            ApellidoLabel = new Label();
            NombreLabel = new Label();
            NombreTextBox = new TextBox();
            LegajoLabel = new Label();
            LegajoTextBox = new TextBox();
            DireccionLabel = new Label();
            DireccionTextBox = new TextBox();
            NuevoUsuarioLabel = new Label();
            CancelarButton = new Button();
            GuardarButton = new Button();
            TelefonoLabel = new Label();
            TelefonoTextBox = new TextBox();
            SuspendLayout();
            // 
            // ApellidoTextBox
            // 
            ApellidoTextBox.BackColor = SystemColors.ControlDarkDark;
            ApellidoTextBox.ForeColor = SystemColors.Menu;
            ApellidoTextBox.Location = new Point(86, 59);
            ApellidoTextBox.Name = "ApellidoTextBox";
            ApellidoTextBox.Size = new Size(100, 23);
            ApellidoTextBox.TabIndex = 0;
            // 
            // ApellidoLabel
            // 
            ApellidoLabel.AutoSize = true;
            ApellidoLabel.Location = new Point(26, 62);
            ApellidoLabel.Name = "ApellidoLabel";
            ApellidoLabel.Size = new Size(54, 15);
            ApellidoLabel.TabIndex = 11;
            ApellidoLabel.Text = "Apellido:";
            // 
            // NombreLabel
            // 
            NombreLabel.AutoSize = true;
            NombreLabel.Location = new Point(26, 101);
            NombreLabel.Name = "NombreLabel";
            NombreLabel.Size = new Size(54, 15);
            NombreLabel.TabIndex = 10;
            NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            NombreTextBox.BackColor = SystemColors.ControlDarkDark;
            NombreTextBox.ForeColor = SystemColors.Menu;
            NombreTextBox.Location = new Point(86, 98);
            NombreTextBox.Name = "NombreTextBox";
            NombreTextBox.Size = new Size(100, 23);
            NombreTextBox.TabIndex = 1;
            // 
            // LegajoLabel
            // 
            LegajoLabel.AutoSize = true;
            LegajoLabel.Location = new Point(35, 139);
            LegajoLabel.Name = "LegajoLabel";
            LegajoLabel.Size = new Size(45, 15);
            LegajoLabel.TabIndex = 9;
            LegajoLabel.Text = "Legajo:";
            // 
            // LegajoTextBox
            // 
            LegajoTextBox.BackColor = SystemColors.ControlDarkDark;
            LegajoTextBox.ForeColor = SystemColors.Menu;
            LegajoTextBox.Location = new Point(86, 136);
            LegajoTextBox.Name = "LegajoTextBox";
            LegajoTextBox.Size = new Size(100, 23);
            LegajoTextBox.TabIndex = 2;
            // 
            // DireccionLabel
            // 
            DireccionLabel.AutoSize = true;
            DireccionLabel.Location = new Point(20, 178);
            DireccionLabel.Name = "DireccionLabel";
            DireccionLabel.Size = new Size(60, 15);
            DireccionLabel.TabIndex = 8;
            DireccionLabel.Text = "Direccion:";
            // 
            // DireccionTextBox
            // 
            DireccionTextBox.BackColor = SystemColors.ControlDarkDark;
            DireccionTextBox.ForeColor = SystemColors.Menu;
            DireccionTextBox.Location = new Point(86, 175);
            DireccionTextBox.Name = "DireccionTextBox";
            DireccionTextBox.Size = new Size(100, 23);
            DireccionTextBox.TabIndex = 3;
            // 
            // NuevoUsuarioLabel
            // 
            NuevoUsuarioLabel.AutoSize = true;
            NuevoUsuarioLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NuevoUsuarioLabel.Location = new Point(12, 9);
            NuevoUsuarioLabel.Name = "NuevoUsuarioLabel";
            NuevoUsuarioLabel.Size = new Size(193, 37);
            NuevoUsuarioLabel.TabIndex = 12;
            NuevoUsuarioLabel.Text = "Nuevo Usuario";
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(26, 254);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 6;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(111, 254);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 5;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // TelefonoLabel
            // 
            TelefonoLabel.AutoSize = true;
            TelefonoLabel.Location = new Point(25, 217);
            TelefonoLabel.Name = "TelefonoLabel";
            TelefonoLabel.Size = new Size(55, 15);
            TelefonoLabel.TabIndex = 7;
            TelefonoLabel.Text = "Telefono:";
            // 
            // TelefonoTextBox
            // 
            TelefonoTextBox.BackColor = SystemColors.ControlDarkDark;
            TelefonoTextBox.ForeColor = SystemColors.Menu;
            TelefonoTextBox.Location = new Point(86, 213);
            TelefonoTextBox.Name = "TelefonoTextBox";
            TelefonoTextBox.Size = new Size(100, 23);
            TelefonoTextBox.TabIndex = 4;
            // 
            // NuevoAlumno
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(215, 293);
            Controls.Add(TelefonoLabel);
            Controls.Add(TelefonoTextBox);
            Controls.Add(GuardarButton);
            Controls.Add(CancelarButton);
            Controls.Add(NuevoUsuarioLabel);
            Controls.Add(DireccionLabel);
            Controls.Add(DireccionTextBox);
            Controls.Add(LegajoLabel);
            Controls.Add(LegajoTextBox);
            Controls.Add(NombreLabel);
            Controls.Add(NombreTextBox);
            Controls.Add(ApellidoLabel);
            Controls.Add(ApellidoTextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NuevoAlumno";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ApellidoTextBox;
        private Label ApellidoLabel;
        private Label NombreLabel;
        private TextBox NombreTextBox;
        private Label LegajoLabel;
        private TextBox LegajoTextBox;
        private Label DireccionLabel;
        private TextBox DireccionTextBox;
        private Label NuevoUsuarioLabel;
        private Button CancelarButton;
        private Button GuardarButton;
        private Label TelefonoLabel;
        private TextBox TelefonoTextBox;
    }
}