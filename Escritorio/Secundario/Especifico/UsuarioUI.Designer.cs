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
            PersonaLabel = new Label();
            PersonaComboBox = new ComboBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            AdministradorCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(59, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(108, 37);
            TituloLabel.TabIndex = 13;
            TituloLabel.Text = "Usuario";
            // 
            // NombreUsuarioLabel
            // 
            NombreUsuarioLabel.AutoSize = true;
            NombreUsuarioLabel.Location = new Point(22, 68);
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
            ClaveLabel.Location = new Point(96, 104);
            ClaveLabel.Name = "ClaveLabel";
            ClaveLabel.Size = new Size(39, 15);
            ClaveLabel.TabIndex = 11;
            ClaveLabel.Text = "Clave:";
            // 
            // ClaveTextBox
            // 
            ClaveTextBox.BackColor = SystemColors.ControlDarkDark;
            ClaveTextBox.ForeColor = SystemColors.Menu;
            ClaveTextBox.Location = new Point(140, 100);
            ClaveTextBox.Name = "ClaveTextBox";
            ClaveTextBox.Size = new Size(129, 23);
            ClaveTextBox.TabIndex = 1;
            // 
            // PersonaLabel
            // 
            PersonaLabel.AutoSize = true;
            PersonaLabel.Location = new Point(83, 175);
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
            PersonaComboBox.Location = new Point(140, 172);
            PersonaComboBox.Name = "PersonaComboBox";
            PersonaComboBox.Size = new Size(127, 23);
            PersonaComboBox.TabIndex = 5;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(34, 219);
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
            GuardarButton.Location = new Point(176, 219);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 6;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // AdministradorCheckBox
            // 
            AdministradorCheckBox.AutoSize = true;
            AdministradorCheckBox.Location = new Point(36, 136);
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
            ClientSize = new Size(298, 262);
            Controls.Add(AdministradorCheckBox);
            Controls.Add(TituloLabel);
            Controls.Add(NombreUsuarioLabel);
            Controls.Add(NombreUsuarioTextBox);
            Controls.Add(ClaveLabel);
            Controls.Add(ClaveTextBox);
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
        private Label PersonaLabel;
        private ComboBox PersonaComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
        private CheckBox AdministradorCheckBox;
    }
}