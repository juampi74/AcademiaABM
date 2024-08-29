namespace AcademiaABM.Presentacion
{
    partial class EditarCurso
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
            EditarCursoLabel = new Label();
            AnioCalendarioLabel = new Label();
            AnioCalendarioTextBox = new TextBox();
            CupoLabel = new Label();
            CupoTextBox = new TextBox();
            IdComsionLabel = new Label();
            IdComisionTextBox = new TextBox();
            IdMateriaLabel = new Label();
            IdMateriaTextBox = new TextBox();
            GuardarButton = new Button();
            CancelarButton = new Button();
            SuspendLayout();
            // 
            // EditarCursoLabel
            // 
            EditarCursoLabel.AutoSize = true;
            EditarCursoLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditarCursoLabel.Location = new Point(52, 10);
            EditarCursoLabel.Name = "EditarCursoLabel";
            EditarCursoLabel.Size = new Size(161, 37);
            EditarCursoLabel.TabIndex = 20;
            EditarCursoLabel.Text = "Editar Curso";
            // 
            // AnioCalendarioLabel
            // 
            AnioCalendarioLabel.AutoSize = true;
            AnioCalendarioLabel.Location = new Point(17, 59);
            AnioCalendarioLabel.Name = "AnioCalendarioLabel";
            AnioCalendarioLabel.Size = new Size(92, 15);
            AnioCalendarioLabel.TabIndex = 12;
            AnioCalendarioLabel.Text = "Año Calendario:";
            // 
            // AnioCalendarioTextBox
            // 
            AnioCalendarioTextBox.BackColor = SystemColors.ControlDarkDark;
            AnioCalendarioTextBox.ForeColor = SystemColors.Menu;
            AnioCalendarioTextBox.Location = new Point(117, 57);
            AnioCalendarioTextBox.Name = "AnioCalendarioTextBox";
            AnioCalendarioTextBox.Size = new Size(129, 23);
            AnioCalendarioTextBox.TabIndex = 7;
            // 
            // CupoLabel
            // 
            CupoLabel.AutoSize = true;
            CupoLabel.Location = new Point(70, 91);
            CupoLabel.Name = "CupoLabel";
            CupoLabel.Size = new Size(39, 15);
            CupoLabel.TabIndex = 14;
            CupoLabel.Text = "Cupo:";
            // 
            // CupoTextBox
            // 
            CupoTextBox.BackColor = SystemColors.ControlDarkDark;
            CupoTextBox.ForeColor = SystemColors.Menu;
            CupoTextBox.Location = new Point(117, 89);
            CupoTextBox.Name = "CupoTextBox";
            CupoTextBox.Size = new Size(129, 23);
            CupoTextBox.TabIndex = 5;
            // 
            // IdComsionLabel
            // 
            IdComsionLabel.AutoSize = true;
            IdComsionLabel.Location = new Point(48, 124);
            IdComsionLabel.Name = "IdComsionLabel";
            IdComsionLabel.Size = new Size(61, 15);
            IdComsionLabel.TabIndex = 11;
            IdComsionLabel.Text = "Comisión:";
            // 
            // IdComisionTextBox
            // 
            IdComisionTextBox.BackColor = SystemColors.ControlDarkDark;
            IdComisionTextBox.ForeColor = SystemColors.Menu;
            IdComisionTextBox.Location = new Point(117, 123);
            IdComisionTextBox.Name = "IdComisionTextBox";
            IdComisionTextBox.Size = new Size(129, 23);
            IdComisionTextBox.TabIndex = 8;
            // 
            // IdMateriaLabel
            // 
            IdMateriaLabel.AutoSize = true;
            IdMateriaLabel.Location = new Point(59, 158);
            IdMateriaLabel.Name = "IdMateriaLabel";
            IdMateriaLabel.Size = new Size(50, 15);
            IdMateriaLabel.TabIndex = 11;
            IdMateriaLabel.Text = "Materia:";
            // 
            // IdMateriaTextBox
            // 
            IdMateriaTextBox.BackColor = SystemColors.ControlDarkDark;
            IdMateriaTextBox.ForeColor = SystemColors.Menu;
            IdMateriaTextBox.Location = new Point(117, 156);
            IdMateriaTextBox.Name = "IdMateriaTextBox";
            IdMateriaTextBox.Size = new Size(129, 23);
            IdMateriaTextBox.TabIndex = 8;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(163, 191);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 9;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += EditarGuardarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(20, 191);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 10;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += EditarCancelarButton_Click;
            // 
            // EditarCurso
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 230);
            Controls.Add(EditarCursoLabel);
            Controls.Add(AnioCalendarioLabel);
            Controls.Add(AnioCalendarioTextBox);
            Controls.Add(CupoLabel);
            Controls.Add(CupoTextBox);
            Controls.Add(IdComsionLabel);
            Controls.Add(IdComisionTextBox);
            Controls.Add(IdMateriaLabel);
            Controls.Add(IdMateriaTextBox);
            Controls.Add(GuardarButton);
            Controls.Add(CancelarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditarCurso";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label EditarCursoLabel;
        private Label AnioCalendarioLabel;
        private TextBox AnioCalendarioTextBox;
        private Label CupoLabel;
        private TextBox CupoTextBox;
        private Label IdComsionLabel;
        private TextBox IdComisionTextBox;
        private Label IdMateriaLabel;
        private TextBox IdMateriaTextBox;
        private Button GuardarButton;
        private Button CancelarButton;
    }
}