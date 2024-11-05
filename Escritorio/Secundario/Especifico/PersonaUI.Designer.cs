namespace Escritorio
{
    partial class PersonaUI
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
            NombreLabel = new Label();
            NombreTextBox = new TextBox();
            ApellidoLabel = new Label();
            ApellidoTextBox = new TextBox();
            DireccionLabel = new Label();
            DireccionTextBox = new TextBox();
            EmailLabel = new Label();
            EmailTextBox = new TextBox();
            TelefonoLabel = new Label();
            TelefonoTextBox = new TextBox();
            FechaNacimientoLabel = new Label();
            FechaNacimientoDatePicker = new DateTimePicker();
            LegajoLabel = new Label();
            LegajoTextBox = new TextBox();
            TipoPersonaLabel = new Label();
            TipoPersonaComboBox = new ComboBox();
            PlanLabel = new Label();
            PlanComboBox = new ComboBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(92, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(110, 37);
            TituloLabel.TabIndex = 20;
            TituloLabel.Text = "Persona";
            // 
            // NombreLabel
            // 
            NombreLabel.AutoSize = true;
            NombreLabel.Location = new Point(75, 67);
            NombreLabel.Name = "NombreLabel";
            NombreLabel.Size = new Size(54, 15);
            NombreLabel.TabIndex = 19;
            NombreLabel.Text = "Nombre:";
            // 
            // NombreTextBox
            // 
            NombreTextBox.BackColor = SystemColors.ControlDarkDark;
            NombreTextBox.ForeColor = SystemColors.Menu;
            NombreTextBox.Location = new Point(140, 64);
            NombreTextBox.Name = "NombreTextBox";
            NombreTextBox.Size = new Size(228, 23);
            NombreTextBox.TabIndex = 0;
            // 
            // ApellidoLabel
            // 
            ApellidoLabel.AutoSize = true;
            ApellidoLabel.Location = new Point(75, 103);
            ApellidoLabel.Name = "ApellidoLabel";
            ApellidoLabel.Size = new Size(54, 15);
            ApellidoLabel.TabIndex = 18;
            ApellidoLabel.Text = "Apellido:";
            // 
            // ApellidoTextBox
            // 
            ApellidoTextBox.BackColor = SystemColors.ControlDarkDark;
            ApellidoTextBox.ForeColor = SystemColors.Menu;
            ApellidoTextBox.Location = new Point(140, 100);
            ApellidoTextBox.Name = "ApellidoTextBox";
            ApellidoTextBox.Size = new Size(228, 23);
            ApellidoTextBox.TabIndex = 1;
            // 
            // DireccionLabel
            // 
            DireccionLabel.AutoSize = true;
            DireccionLabel.Location = new Point(69, 140);
            DireccionLabel.Name = "DireccionLabel";
            DireccionLabel.Size = new Size(60, 15);
            DireccionLabel.TabIndex = 17;
            DireccionLabel.Text = "Direccion:";
            // 
            // DireccionTextBox
            // 
            DireccionTextBox.BackColor = SystemColors.ControlDarkDark;
            DireccionTextBox.ForeColor = SystemColors.Menu;
            DireccionTextBox.Location = new Point(140, 136);
            DireccionTextBox.Name = "DireccionTextBox";
            DireccionTextBox.Size = new Size(228, 23);
            DireccionTextBox.TabIndex = 2;
            // 
            // EmailLabel
            // 
            EmailLabel.AutoSize = true;
            EmailLabel.Location = new Point(90, 176);
            EmailLabel.Name = "EmailLabel";
            EmailLabel.Size = new Size(39, 15);
            EmailLabel.TabIndex = 16;
            EmailLabel.Text = "Email:";
            // 
            // EmailTextBox
            // 
            EmailTextBox.BackColor = SystemColors.ControlDarkDark;
            EmailTextBox.ForeColor = SystemColors.Menu;
            EmailTextBox.Location = new Point(140, 172);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(228, 23);
            EmailTextBox.TabIndex = 3;
            // 
            // TelefonoLabel
            // 
            TelefonoLabel.AutoSize = true;
            TelefonoLabel.Location = new Point(75, 211);
            TelefonoLabel.Name = "TelefonoLabel";
            TelefonoLabel.Size = new Size(55, 15);
            TelefonoLabel.TabIndex = 15;
            TelefonoLabel.Text = "Telefono:";
            // 
            // TelefonoTextBox
            // 
            TelefonoTextBox.BackColor = SystemColors.ControlDarkDark;
            TelefonoTextBox.ForeColor = SystemColors.Menu;
            TelefonoTextBox.Location = new Point(140, 208);
            TelefonoTextBox.Name = "TelefonoTextBox";
            TelefonoTextBox.Size = new Size(228, 23);
            TelefonoTextBox.TabIndex = 4;
            // 
            // FechaNacimientoLabel
            // 
            FechaNacimientoLabel.AutoSize = true;
            FechaNacimientoLabel.Location = new Point(9, 248);
            FechaNacimientoLabel.Name = "FechaNacimientoLabel";
            FechaNacimientoLabel.Size = new Size(122, 15);
            FechaNacimientoLabel.TabIndex = 14;
            FechaNacimientoLabel.Text = "Fecha de Nacimiento:";
            // 
            // FechaNacimientoDatePicker
            // 
            FechaNacimientoDatePicker.Location = new Point(141, 244);
            FechaNacimientoDatePicker.Name = "FechaNacimientoDatePicker";
            FechaNacimientoDatePicker.Size = new Size(228, 23);
            FechaNacimientoDatePicker.TabIndex = 5;
            // 
            // LegajoLabel
            // 
            LegajoLabel.AutoSize = true;
            LegajoLabel.Location = new Point(85, 283);
            LegajoLabel.Name = "LegajoLabel";
            LegajoLabel.Size = new Size(45, 15);
            LegajoLabel.TabIndex = 13;
            LegajoLabel.Text = "Legajo:";
            // 
            // LegajoTextBox
            // 
            LegajoTextBox.BackColor = SystemColors.ControlDarkDark;
            LegajoTextBox.ForeColor = SystemColors.Menu;
            LegajoTextBox.Location = new Point(140, 280);
            LegajoTextBox.Name = "LegajoTextBox";
            LegajoTextBox.Size = new Size(228, 23);
            LegajoTextBox.TabIndex = 6;
            // 
            // TipoPersonaLabel
            // 
            TipoPersonaLabel.AutoSize = true;
            TipoPersonaLabel.Location = new Point(96, 319);
            TipoPersonaLabel.Name = "TipoPersonaLabel";
            TipoPersonaLabel.Size = new Size(33, 15);
            TipoPersonaLabel.TabIndex = 12;
            TipoPersonaLabel.Text = "Tipo:";
            // 
            // TipoPersonaComboBox
            // 
            TipoPersonaComboBox.BackColor = SystemColors.GrayText;
            TipoPersonaComboBox.ForeColor = SystemColors.Window;
            TipoPersonaComboBox.FormattingEnabled = true;
            TipoPersonaComboBox.Location = new Point(140, 316);
            TipoPersonaComboBox.Name = "TipoPersonaComboBox";
            TipoPersonaComboBox.Size = new Size(228, 23);
            TipoPersonaComboBox.TabIndex = 7;
            // 
            // PlanLabel
            // 
            PlanLabel.AutoSize = true;
            PlanLabel.Location = new Point(96, 355);
            PlanLabel.Name = "PlanLabel";
            PlanLabel.Size = new Size(33, 15);
            PlanLabel.TabIndex = 11;
            PlanLabel.Text = "Plan:";
            // 
            // PlanComboBox
            // 
            PlanComboBox.BackColor = SystemColors.GrayText;
            PlanComboBox.ForeColor = SystemColors.Window;
            PlanComboBox.FormattingEnabled = true;
            PlanComboBox.Location = new Point(140, 352);
            PlanComboBox.Name = "PlanComboBox";
            PlanComboBox.Size = new Size(228, 23);
            PlanComboBox.TabIndex = 8;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(74, 399);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 10;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(216, 399);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 9;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // PersonaUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 443);
            Controls.Add(TituloLabel);
            Controls.Add(NombreLabel);
            Controls.Add(NombreTextBox);
            Controls.Add(ApellidoLabel);
            Controls.Add(ApellidoTextBox);
            Controls.Add(DireccionLabel);
            Controls.Add(DireccionTextBox);
            Controls.Add(EmailLabel);
            Controls.Add(EmailTextBox);
            Controls.Add(TelefonoLabel);
            Controls.Add(TelefonoTextBox);
            Controls.Add(FechaNacimientoLabel);
            Controls.Add(FechaNacimientoDatePicker);
            Controls.Add(LegajoLabel);
            Controls.Add(LegajoTextBox);
            Controls.Add(TipoPersonaLabel);
            Controls.Add(TipoPersonaComboBox);
            Controls.Add(PlanLabel);
            Controls.Add(PlanComboBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "PersonaUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label NombreLabel;
        private TextBox NombreTextBox;
        private TextBox ApellidoTextBox;
        private Label ApellidoLabel;
        private Label DireccionLabel;
        private TextBox DireccionTextBox;
        private Label EmailLabel;
        private TextBox EmailTextBox;
        private Label TelefonoLabel;
        private TextBox TelefonoTextBox;
        private Label FechaNacimientoLabel;
        private DateTimePicker FechaNacimientoDatePicker;
        private Label LegajoLabel;
        private TextBox LegajoTextBox;
        private Label TipoPersonaLabel;
        private ComboBox TipoPersonaComboBox;
        private Label PlanLabel;
        private ComboBox PlanComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}