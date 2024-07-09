namespace AcademiaABM.Presentacion
{
    partial class EditarAlumno
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
            GuardarButton = new Button();
            CancelarButton = new Button();
            EditarUsuarioLabel = new Label();
            DireccionLabel = new Label();
            DireccionTextBox = new TextBox();
            LegajoLabel = new Label();
            LegajoTextBox = new TextBox();
            NombreLabel = new Label();
            NombreTextBox = new TextBox();
            ApellidoLabel = new Label();
            ApellidoTextBox = new TextBox();
            TelefonoLabel = new Label();
            TelefonoTextBox = new TextBox();
            SuspendLayout();
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
            GuardarButton.Click += EditarGuardarButton_Click;
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
            CancelarButton.Click += EditarCancelarButton_Click;
            // 
            // EditarUsuarioLabel
            // 
            EditarUsuarioLabel.AutoSize = true;
            EditarUsuarioLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditarUsuarioLabel.Location = new Point(15, 9);
            EditarUsuarioLabel.Name = "EditarUsuarioLabel";
            EditarUsuarioLabel.Size = new Size(184, 37);
            EditarUsuarioLabel.TabIndex = 12;
            EditarUsuarioLabel.Text = "Editar Usuario";
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
            // ApellidoLabel
            // 
            ApellidoLabel.AutoSize = true;
            ApellidoLabel.Location = new Point(26, 62);
            ApellidoLabel.Name = "ApellidoLabel";
            ApellidoLabel.Size = new Size(54, 15);
            ApellidoLabel.TabIndex = 11;
            ApellidoLabel.Text = "Apellido:";
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
            // EditarAlumno
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(215, 293);
            Controls.Add(TelefonoLabel);
            Controls.Add(TelefonoTextBox);
            Controls.Add(GuardarButton);
            Controls.Add(CancelarButton);
            Controls.Add(EditarUsuarioLabel);
            Controls.Add(DireccionLabel);
            Controls.Add(DireccionTextBox);
            Controls.Add(LegajoLabel);
            Controls.Add(LegajoTextBox);
            Controls.Add(NombreLabel);
            Controls.Add(NombreTextBox);
            Controls.Add(ApellidoLabel);
            Controls.Add(ApellidoTextBox);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditarAlumno";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GuardarButton;
        private Button CancelarButton;
        private Label EditarUsuarioLabel;
        private Label DireccionLabel;
        private TextBox DireccionTextBox;
        private Label LegajoLabel;
        private TextBox LegajoTextBox;
        private Label NombreLabel;
        private TextBox NombreTextBox;
        private Label ApellidoLabel;
        private TextBox ApellidoTextBox;
        private Label TelefonoLabel;
        private TextBox TelefonoTextBox;
    }
}