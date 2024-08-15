namespace AcademiaABM.Presentacion
{
    partial class NuevoCurso
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
            NuevoCursoLabel = new Label();
            AnioCalendarioLabel = new Label();
            AnioCalendarioTextBox = new TextBox();
            CupoLabel = new Label();
            CupoTextBox = new TextBox();
            IdComisionLabel = new Label();
            IdComisionTextBox = new TextBox();
            IdMateriaLabel = new Label();
            IdMateriaTextBox = new TextBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // NuevoCursoLabel
            // 
            NuevoCursoLabel.AutoSize = true;
            NuevoCursoLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NuevoCursoLabel.Location = new Point(46, 9);
            NuevoCursoLabel.Name = "NuevoCursoLabel";
            NuevoCursoLabel.Size = new Size(170, 37);
            NuevoCursoLabel.TabIndex = 12;
            NuevoCursoLabel.Text = "Nuevo Curso";
            // 
            // AnioCalendarioLabel
            // 
            AnioCalendarioLabel.AutoSize = true;
            AnioCalendarioLabel.Location = new Point(44, 67);
            AnioCalendarioLabel.Name = "AnioCalendarioLabel";
            AnioCalendarioLabel.Size = new Size(92, 15);
            AnioCalendarioLabel.TabIndex = 10;
            AnioCalendarioLabel.Text = "Año Calendario:";
            // 
            // AnioCalendarioTextBox
            // 
            AnioCalendarioTextBox.BackColor = SystemColors.ControlDarkDark;
            AnioCalendarioTextBox.ForeColor = SystemColors.Menu;
            AnioCalendarioTextBox.Location = new Point(140, 63);
            AnioCalendarioTextBox.Name = "AnioCalendarioTextBox";
            AnioCalendarioTextBox.Size = new Size(100, 23);
            AnioCalendarioTextBox.TabIndex = 1;
            // 
            // CupoLabel
            // 
            CupoLabel.AutoSize = true;
            CupoLabel.Location = new Point(96, 104);
            CupoLabel.Name = "CupoLabel";
            CupoLabel.Size = new Size(39, 15);
            CupoLabel.TabIndex = 11;
            CupoLabel.Text = "Cupo:";
            // 
            // CupoTextBox
            // 
            CupoTextBox.BackColor = SystemColors.ControlDarkDark;
            CupoTextBox.ForeColor = SystemColors.Menu;
            CupoTextBox.Location = new Point(140, 100);
            CupoTextBox.Name = "CupoTextBox";
            CupoTextBox.Size = new Size(100, 23);
            CupoTextBox.TabIndex = 0;
            // 
            // IdComisionLabel
            // 
            IdComisionLabel.AutoSize = true;
            IdComisionLabel.Location = new Point(77, 143);
            IdComisionLabel.Name = "IdComisionLabel";
            IdComisionLabel.Size = new Size(61, 15);
            IdComisionLabel.TabIndex = 18;
            IdComisionLabel.Text = "Comision:";
            // 
            // IdComisionTextBox
            // 
            IdComisionTextBox.BackColor = SystemColors.ControlDarkDark;
            IdComisionTextBox.ForeColor = SystemColors.Menu;
            IdComisionTextBox.Location = new Point(140, 139);
            IdComisionTextBox.Name = "IdComisionTextBox";
            IdComisionTextBox.Size = new Size(100, 23);
            IdComisionTextBox.TabIndex = 17;
            // 
            // IdMateriaLabel
            // 
            IdMateriaLabel.AutoSize = true;
            IdMateriaLabel.Location = new Point(87, 183);
            IdMateriaLabel.Name = "IdMateriaLabel";
            IdMateriaLabel.Size = new Size(50, 15);
            IdMateriaLabel.TabIndex = 18;
            IdMateriaLabel.Text = "Materia:";
            // 
            // IdMateriaTextBox
            // 
            IdMateriaTextBox.BackColor = SystemColors.ControlDarkDark;
            IdMateriaTextBox.ForeColor = SystemColors.Menu;
            IdMateriaTextBox.Location = new Point(140, 180);
            IdMateriaTextBox.Name = "IdMateriaTextBox";
            IdMateriaTextBox.Size = new Size(100, 23);
            IdMateriaTextBox.TabIndex = 17;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(22, 221);
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
            GuardarButton.Location = new Point(164, 221);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 5;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // NuevoCurso
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 256);
            Controls.Add(NuevoCursoLabel);
            Controls.Add(AnioCalendarioLabel);
            Controls.Add(AnioCalendarioTextBox);
            Controls.Add(CupoLabel);
            Controls.Add(CupoTextBox);
            Controls.Add(IdComisionLabel);
            Controls.Add(IdComisionTextBox);
            Controls.Add(IdMateriaLabel);
            Controls.Add(IdMateriaTextBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NuevoCurso";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NuevoCursoLabel;
        private Label AnioCalendarioLabel;
        private TextBox AnioCalendarioTextBox;
        private Label CupoLabel;
        private TextBox CupoTextBox;
        private Label IdComisionLabel;
        private TextBox IdComisionTextBox;
        private Label IdMateriaLabel;
        private TextBox IdMateriaTextBox;
        private Button CancelarButton;
        private Button GuardarButton;

    }
}