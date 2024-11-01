namespace Escritorio
{
    partial class UsuarioUI
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
            NombreUsuarioLabel = new Label();
            NombreUsuarioTextBox = new TextBox();
            ClaveLabel = new Label();
            ClaveTextBox = new TextBox();
            HabilitadoLabel = new Label();
            CambiaClaveLabel = new Label();
            PersonaLabel = new Label();
            PersonaComboBox = new ComboBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            CambiaClaveComboBox = new ComboBox();
            HabilitadoComboBox = new ComboBox();
            AdministradorCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(56, 11);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(108, 37);
            TituloLabel.TabIndex = 13;
            TituloLabel.Text = "Usuario";
            // 
            // NombreUsuarioLabel
            // 
            NombreUsuarioLabel.AutoSize = true;
            NombreUsuarioLabel.Location = new Point(22, 67);
            NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            NombreUsuarioLabel.Size = new Size(113, 15);
            NombreUsuarioLabel.TabIndex = 12;
            NombreUsuarioLabel.Text = "Nombre de Usuario:";
            // 
            // NombreUsuarioTextBox
            // 
            NombreUsuarioTextBox.BackColor = SystemColors.ControlDarkDark;
            NombreUsuarioTextBox.ForeColor = SystemColors.Menu;
            NombreUsuarioTextBox.Location = new Point(141, 64);
            NombreUsuarioTextBox.Name = "NombreUsuarioTextBox";
            NombreUsuarioTextBox.Size = new Size(129, 23);
            NombreUsuarioTextBox.TabIndex = 0;
            // 
            // ClaveLabel
            // 
            ClaveLabel.AutoSize = true;
            ClaveLabel.Location = new Point(96, 101);
            ClaveLabel.Name = "ClaveLabel";
            ClaveLabel.Size = new Size(39, 15);
            ClaveLabel.TabIndex = 11;
            ClaveLabel.Text = "Clave:";
            // 
            // ClaveTextBox
            // 
            ClaveTextBox.BackColor = SystemColors.ControlDarkDark;
            ClaveTextBox.ForeColor = SystemColors.Menu;
            ClaveTextBox.Location = new Point(140, 98);
            ClaveTextBox.Name = "ClaveTextBox";
            ClaveTextBox.Size = new Size(129, 23);
            ClaveTextBox.TabIndex = 1;
            // 
            // HabilitadoLabel
            // 
            HabilitadoLabel.AutoSize = true;
            HabilitadoLabel.Location = new Point(70, 137);
            HabilitadoLabel.Name = "HabilitadoLabel";
            HabilitadoLabel.Size = new Size(65, 15);
            HabilitadoLabel.TabIndex = 10;
            HabilitadoLabel.Text = "Habilitado:";
            // 
            // CambiaClaveLabel
            // 
            CambiaClaveLabel.AutoSize = true;
            CambiaClaveLabel.Location = new Point(52, 171);
            CambiaClaveLabel.Name = "CambiaClaveLabel";
            CambiaClaveLabel.Size = new Size(83, 15);
            CambiaClaveLabel.TabIndex = 9;
            CambiaClaveLabel.Text = "Cambia Clave:";
            // 
            // PersonaLabel
            // 
            PersonaLabel.AutoSize = true;
            PersonaLabel.Location = new Point(83, 241);
            PersonaLabel.Name = "PersonaLabel";
            PersonaLabel.Size = new Size(52, 15);
            PersonaLabel.TabIndex = 8;
            PersonaLabel.Text = "Persona:";
            // 
            // PersonaComboBox
            // 
            PersonaComboBox.BackColor = SystemColors.GrayText;
            PersonaComboBox.ForeColor = SystemColors.Window;
            PersonaComboBox.FormattingEnabled = true;
            PersonaComboBox.Location = new Point(140, 238);
            PersonaComboBox.Name = "PersonaComboBox";
            PersonaComboBox.Size = new Size(127, 23);
            PersonaComboBox.TabIndex = 5;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(34, 278);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 7;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(176, 278);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 6;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // CambiaClaveComboBox
            // 
            CambiaClaveComboBox.BackColor = SystemColors.GrayText;
            CambiaClaveComboBox.ForeColor = SystemColors.Window;
            CambiaClaveComboBox.FormattingEnabled = true;
            CambiaClaveComboBox.Location = new Point(140, 168);
            CambiaClaveComboBox.Name = "CambiaClaveComboBox";
            CambiaClaveComboBox.Size = new Size(127, 23);
            CambiaClaveComboBox.TabIndex = 3;
            // 
            // HabilitadoComboBox
            // 
            HabilitadoComboBox.BackColor = SystemColors.GrayText;
            HabilitadoComboBox.ForeColor = SystemColors.Window;
            HabilitadoComboBox.FormattingEnabled = true;
            HabilitadoComboBox.Location = new Point(141, 134);
            HabilitadoComboBox.Name = "HabilitadoComboBox";
            HabilitadoComboBox.Size = new Size(127, 23);
            HabilitadoComboBox.TabIndex = 2;
            // 
            // AdministradorCheckBox
            // 
            AdministradorCheckBox.AutoSize = true;
            AdministradorCheckBox.Location = new Point(36, 206);
            AdministradorCheckBox.Name = "AdministradorCheckBox";
            AdministradorCheckBox.Size = new Size(102, 19);
            AdministradorCheckBox.TabIndex = 4;
            AdministradorCheckBox.Text = "Administrador";
            AdministradorCheckBox.UseVisualStyleBackColor = true;
            AdministradorCheckBox.CheckedChanged += AdministradorCheckBox_CheckedChanged;
            // 
            // UsuarioUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 316);
            Controls.Add(AdministradorCheckBox);
            Controls.Add(HabilitadoComboBox);
            Controls.Add(CambiaClaveComboBox);
            Controls.Add(TituloLabel);
            Controls.Add(NombreUsuarioLabel);
            Controls.Add(NombreUsuarioTextBox);
            Controls.Add(ClaveLabel);
            Controls.Add(ClaveTextBox);
            Controls.Add(HabilitadoLabel);
            Controls.Add(CambiaClaveLabel);
            Controls.Add(PersonaLabel);
            Controls.Add(PersonaComboBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "UsuarioUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label NombreUsuarioLabel;
        private TextBox NombreUsuarioTextBox;
        private Label ClaveLabel;
        private TextBox ClaveTextBox;
        private Label HabilitadoLabel;
        private Label CambiaClaveLabel;
        private Label PersonaLabel;
        private ComboBox PersonaComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
        private ComboBox CambiaClaveComboBox;
        private ComboBox HabilitadoComboBox;
        private CheckBox AdministradorCheckBox;
    }
}