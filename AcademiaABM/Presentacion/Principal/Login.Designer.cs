namespace AcademiaABM.Presentacion.Principal
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
            BievenidaLabel.Location = new Point(18, 7);
            BievenidaLabel.Name = "BievenidaLabel";
            BievenidaLabel.Size = new Size(214, 28);
            BievenidaLabel.TabIndex = 7;
            BievenidaLabel.Text = "¡Bienvenido al Sistema!";
            BievenidaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NombreDeUsuarioLabel
            // 
            NombreDeUsuarioLabel.AutoSize = true;
            NombreDeUsuarioLabel.Location = new Point(13, 80);
            NombreDeUsuarioLabel.Name = "NombreDeUsuarioLabel";
            NombreDeUsuarioLabel.Size = new Size(113, 15);
            NombreDeUsuarioLabel.TabIndex = 5;
            NombreDeUsuarioLabel.Text = "Nombre de Usuario:";
            // 
            // ClaveLabel
            // 
            ClaveLabel.AutoSize = true;
            ClaveLabel.Location = new Point(86, 116);
            ClaveLabel.Name = "ClaveLabel";
            ClaveLabel.Size = new Size(39, 15);
            ClaveLabel.TabIndex = 4;
            ClaveLabel.Text = "Clave:";
            // 
            // NombreDeUsuarioTextBox
            // 
            NombreDeUsuarioTextBox.Location = new Point(132, 77);
            NombreDeUsuarioTextBox.Name = "NombreDeUsuarioTextBox";
            NombreDeUsuarioTextBox.Size = new Size(100, 23);
            NombreDeUsuarioTextBox.TabIndex = 0;
            // 
            // ClaveTextBox
            // 
            ClaveTextBox.Location = new Point(132, 112);
            ClaveTextBox.Name = "ClaveTextBox";
            ClaveTextBox.PasswordChar = '*';
            ClaveTextBox.Size = new Size(100, 23);
            ClaveTextBox.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(159, 150);
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
            IngresarInformacionLabel.Location = new Point(9, 42);
            IngresarInformacionLabel.Name = "IngresarInformacionLabel";
            IngresarInformacionLabel.Size = new Size(232, 15);
            IngresarInformacionLabel.TabIndex = 6;
            IngresarInformacionLabel.Text = "Por favor, digite su información de Ingreso";
            IngresarInformacionLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 184);
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