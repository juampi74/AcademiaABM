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
            HabilitadoTextBox = new TextBox();
            CambiaClaveLabel = new Label();
            CambiaClaveTextbox = new TextBox();
            PersonaLabel = new Label();
            PersonaComboBox = new ComboBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(56, 11);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(108, 37);
            TituloLabel.TabIndex = 12;
            TituloLabel.Text = "Usuario";
            // 
            // NombreUsuarioLabel
            // 
            NombreUsuarioLabel.AutoSize = true;
            NombreUsuarioLabel.Location = new Point(22, 67);
            NombreUsuarioLabel.Name = "NombreUsuarioLabel";
            NombreUsuarioLabel.Size = new Size(113, 15);
            NombreUsuarioLabel.TabIndex = 11;
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
            ClaveLabel.TabIndex = 10;
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
            HabilitadoLabel.TabIndex = 9;
            HabilitadoLabel.Text = "Habilitado:";
            // 
            // HabilitadoTextBox
            // 
            HabilitadoTextBox.BackColor = SystemColors.ControlDarkDark;
            HabilitadoTextBox.ForeColor = SystemColors.Menu;
            HabilitadoTextBox.Location = new Point(140, 134);
            HabilitadoTextBox.Name = "HabilitadoTextBox";
            HabilitadoTextBox.Size = new Size(129, 23);
            HabilitadoTextBox.TabIndex = 2;
            // 
            // CambiaClaveLabel
            // 
            CambiaClaveLabel.AutoSize = true;
            CambiaClaveLabel.Location = new Point(52, 171);
            CambiaClaveLabel.Name = "CambiaClaveLabel";
            CambiaClaveLabel.Size = new Size(83, 15);
            CambiaClaveLabel.TabIndex = 8;
            CambiaClaveLabel.Text = "Cambia Clave:";
            // 
            // CambiaClaveTextbox
            // 
            CambiaClaveTextbox.BackColor = SystemColors.ControlDarkDark;
            CambiaClaveTextbox.ForeColor = SystemColors.Menu;
            CambiaClaveTextbox.Location = new Point(140, 168);
            CambiaClaveTextbox.Name = "CambiaClaveTextbox";
            CambiaClaveTextbox.Size = new Size(129, 23);
            CambiaClaveTextbox.TabIndex = 3;
            // 
            // PersonaLabel
            // 
            PersonaLabel.AutoSize = true;
            PersonaLabel.Location = new Point(83, 207);
            PersonaLabel.Name = "PersonaLabel";
            PersonaLabel.Size = new Size(52, 15);
            PersonaLabel.TabIndex = 7;
            PersonaLabel.Text = "Persona:";
            // 
            // PersonaComboBox
            // 
            PersonaComboBox.BackColor = SystemColors.GrayText;
            PersonaComboBox.ForeColor = SystemColors.Window;
            PersonaComboBox.FormattingEnabled = true;
            PersonaComboBox.Location = new Point(140, 204);
            PersonaComboBox.Name = "PersonaComboBox";
            PersonaComboBox.Size = new Size(127, 23);
            PersonaComboBox.TabIndex = 4;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(34, 244);
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
            GuardarButton.Location = new Point(176, 244);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 5;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // UsuarioUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(298, 281);
            Controls.Add(TituloLabel);
            Controls.Add(NombreUsuarioLabel);
            Controls.Add(NombreUsuarioTextBox);
            Controls.Add(ClaveLabel);
            Controls.Add(ClaveTextBox);
            Controls.Add(HabilitadoLabel);
            Controls.Add(HabilitadoTextBox);
            Controls.Add(CambiaClaveLabel);
            Controls.Add(CambiaClaveTextbox);
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
        private TextBox HabilitadoTextBox;
        private Label CambiaClaveLabel;
        private TextBox CambiaClaveTextbox;
        private Label PersonaLabel;
        private ComboBox PersonaComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}