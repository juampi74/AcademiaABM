namespace AcademiaABM.Presentacion
{
    partial class NuevaComision
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
            NuevaComisionLabel = new Label();
            DescripcionLabel = new Label();
            DescripcionTextBox = new TextBox();
            AnioEspecialidadTextBox = new TextBox();
            AnioEspecialidadLabel = new Label();
            IdPlanLabel = new Label();
            IdPlanTextBox = new TextBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // NuevaComisionLabel
            // 
            NuevaComisionLabel.AutoSize = true;
            NuevaComisionLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NuevaComisionLabel.Location = new Point(26, 9);
            NuevaComisionLabel.Name = "NuevaComisionLabel";
            NuevaComisionLabel.Size = new Size(212, 37);
            NuevaComisionLabel.TabIndex = 12;
            NuevaComisionLabel.Text = "Nueva Comision";
            // 
            // DescripcionLabel
            // 
            DescripcionLabel.AutoSize = true;
            DescripcionLabel.Location = new Point(57, 66);
            DescripcionLabel.Name = "DescripcionLabel";
            DescripcionLabel.Size = new Size(72, 15);
            DescripcionLabel.TabIndex = 10;
            DescripcionLabel.Text = "Descripcion:";
            // 
            // DescripcionTextBox
            // 
            DescripcionTextBox.BackColor = SystemColors.ControlDarkDark;
            DescripcionTextBox.ForeColor = SystemColors.Menu;
            DescripcionTextBox.Location = new Point(140, 63);
            DescripcionTextBox.Name = "DescripcionTextBox";
            DescripcionTextBox.Size = new Size(100, 23);
            DescripcionTextBox.TabIndex = 1;
            // 
            // AnioEspecialidadLabel
            // 
            AnioEspecialidadLabel.AutoSize = true;
            AnioEspecialidadLabel.Location = new Point(30, 103);
            AnioEspecialidadLabel.Name = "AnioEspecialidadLabel";
            AnioEspecialidadLabel.Size = new Size(100, 15);
            AnioEspecialidadLabel.TabIndex = 11;
            AnioEspecialidadLabel.Text = "Año Especialidad:";
            // 
            // AnioEspecialidadTextBox
            // 
            AnioEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            AnioEspecialidadTextBox.ForeColor = SystemColors.Menu;
            AnioEspecialidadTextBox.Location = new Point(140, 100);
            AnioEspecialidadTextBox.Name = "AnioEspecialidadTextBox";
            AnioEspecialidadTextBox.Size = new Size(100, 23);
            AnioEspecialidadTextBox.TabIndex = 0;
            // 
            // IdPlanLabel
            // 
            IdPlanLabel.AutoSize = true;
            IdPlanLabel.Location = new Point(96, 143);
            IdPlanLabel.Name = "IdPlanLabel";
            IdPlanLabel.Size = new Size(33, 15);
            IdPlanLabel.TabIndex = 18;
            IdPlanLabel.Text = "Plan:";
            // 
            // IdPlanTextBox
            // 
            IdPlanTextBox.BackColor = SystemColors.ControlDarkDark;
            IdPlanTextBox.ForeColor = SystemColors.Menu;
            IdPlanTextBox.Location = new Point(140, 139);
            IdPlanTextBox.Name = "IdPlanTextBox";
            IdPlanTextBox.Size = new Size(100, 23);
            IdPlanTextBox.TabIndex = 17;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(22, 181);
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
            GuardarButton.Location = new Point(164, 181);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 5;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // NuevaComision
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 218);
            Controls.Add(NuevaComisionLabel);
            Controls.Add(DescripcionLabel);
            Controls.Add(DescripcionTextBox);
            Controls.Add(AnioEspecialidadLabel);
            Controls.Add(AnioEspecialidadTextBox);
            Controls.Add(IdPlanLabel);
            Controls.Add(IdPlanTextBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "NuevaComision";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NuevaComisionLabel;
        private Label DescripcionLabel;
        private TextBox DescripcionTextBox;
        private TextBox AnioEspecialidadTextBox;
        private Label AnioEspecialidadLabel;
        private Label IdPlanLabel;
        private TextBox IdPlanTextBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}