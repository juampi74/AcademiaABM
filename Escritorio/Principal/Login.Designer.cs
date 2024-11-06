namespace Escritorio
{
    partial class Login
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
            BievenidaLabel = new Label();
            NombreDeUsuarioLabel = new Label();
            ClaveLabel = new Label();
            NombreDeUsuarioTextBox = new TextBox();
            ClaveTextBox = new TextBox();
            btnIngresar = new Button();
            IngresarInformacionLabel = new Label();
            SuspendLayout();
            // 
            // BievenidaLabel
            // 
            BievenidaLabel.AutoSize = true;
            BievenidaLabel.Font = new Font("Segoe UI", 15F);
            BievenidaLabel.Location = new Point(35, 10);
            BievenidaLabel.Name = "BievenidaLabel";
            BievenidaLabel.Size = new Size(214, 28);
            BievenidaLabel.TabIndex = 6;
            BievenidaLabel.Text = "¡Bienvenido al Sistema!";
            BievenidaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NombreDeUsuarioLabel
            // 
            NombreDeUsuarioLabel.AutoSize = true;
            NombreDeUsuarioLabel.Location = new Point(23, 83);
            NombreDeUsuarioLabel.Name = "NombreDeUsuarioLabel";
            NombreDeUsuarioLabel.Size = new Size(113, 15);
            NombreDeUsuarioLabel.TabIndex = 4;
            NombreDeUsuarioLabel.Text = "Nombre de Usuario:";
            // 
            // ClaveLabel
            // 
            ClaveLabel.AutoSize = true;
            ClaveLabel.Location = new Point(66, 117);
            ClaveLabel.Name = "ClaveLabel";
            ClaveLabel.Size = new Size(70, 15);
            ClaveLabel.TabIndex = 3;
            ClaveLabel.Text = "Contraseña:";
            // 
            // NombreDeUsuarioTextBox
            // 
            NombreDeUsuarioTextBox.Location = new Point(155, 80);
            NombreDeUsuarioTextBox.Name = "NombreDeUsuarioTextBox";
            NombreDeUsuarioTextBox.Size = new Size(100, 23);
            NombreDeUsuarioTextBox.TabIndex = 0;
            // 
            // ClaveTextBox
            // 
            ClaveTextBox.Location = new Point(155, 114);
            ClaveTextBox.Name = "ClaveTextBox";
            ClaveTextBox.PasswordChar = '*';
            ClaveTextBox.Size = new Size(100, 23);
            ClaveTextBox.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(179, 156);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(75, 23);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // IngresarInformacionLabel
            // 
            IngresarInformacionLabel.AutoSize = true;
            IngresarInformacionLabel.Location = new Point(26, 46);
            IngresarInformacionLabel.Name = "IngresarInformacionLabel";
            IngresarInformacionLabel.Size = new Size(232, 15);
            IngresarInformacionLabel.TabIndex = 5;
            IngresarInformacionLabel.Text = "Por favor, digite su información de Ingreso";
            IngresarInformacionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 196);
            Controls.Add(IngresarInformacionLabel);
            Controls.Add(btnIngresar);
            Controls.Add(ClaveTextBox);
            Controls.Add(NombreDeUsuarioTextBox);
            Controls.Add(ClaveLabel);
            Controls.Add(NombreDeUsuarioLabel);
            Controls.Add(BievenidaLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Login";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Login";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BievenidaLabel;
        private Label NombreDeUsuarioLabel;
        private Label ClaveLabel;
        private TextBox NombreDeUsuarioTextBox;
        private TextBox ClaveTextBox;
        private Button btnIngresar;
        private Label IngresarInformacionLabel;
    }
}