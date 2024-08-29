namespace AcademiaABM.Presentacion
{
    partial class NuevoPlan
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
            NuevoPlanLabel = new Label();
            DescPlanLabel = new Label();
            DescPlanTextBox = new TextBox();
            IdEspecialidadLabel = new Label();
            IdEspecialidadTextBox = new TextBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // NuevoPlanLabel
            // 
            NuevoPlanLabel.AutoSize = true;
            NuevoPlanLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NuevoPlanLabel.Location = new Point(62, 12);
            NuevoPlanLabel.Name = "NuevoPlanLabel";
            NuevoPlanLabel.Size = new Size(190, 46);
            NuevoPlanLabel.TabIndex = 10;
            NuevoPlanLabel.Text = "Nuevo Plan";
            // 
            // DescPlanLabel
            // 
            DescPlanLabel.AutoSize = true;
            DescPlanLabel.Location = new Point(42, 82);
            DescPlanLabel.Name = "DescPlanLabel";
            DescPlanLabel.Size = new Size(90, 20);
            DescPlanLabel.TabIndex = 9;
            DescPlanLabel.Text = "Descripción:";
            // 
            // DescPlanTextBox
            // 
            DescPlanTextBox.BackColor = SystemColors.ControlDarkDark;
            DescPlanTextBox.ForeColor = SystemColors.Menu;
            DescPlanTextBox.Location = new Point(145, 80);
            DescPlanTextBox.Margin = new Padding(3, 4, 3, 4);
            DescPlanTextBox.Name = "DescPlanTextBox";
            DescPlanTextBox.Size = new Size(148, 27);
            DescPlanTextBox.TabIndex = 0;
            // 
            // IdEspecialidadLabel
            // 
            IdEspecialidadLabel.AutoSize = true;
            IdEspecialidadLabel.Location = new Point(36, 141);
            IdEspecialidadLabel.Name = "IdEspecialidadLabel";
            IdEspecialidadLabel.Size = new Size(96, 20);
            IdEspecialidadLabel.TabIndex = 9;
            IdEspecialidadLabel.Text = "Especialidad:";
            // 
            // IdEspecialidadTextBox
            // 
            IdEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            IdEspecialidadTextBox.ForeColor = SystemColors.Menu;
            IdEspecialidadTextBox.Location = new Point(145, 138);
            IdEspecialidadTextBox.Margin = new Padding(3, 4, 3, 4);
            IdEspecialidadTextBox.Name = "IdEspecialidadTextBox";
            IdEspecialidadTextBox.Size = new Size(148, 27);
            IdEspecialidadTextBox.TabIndex = 0;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(39, 199);
            CancelarButton.Margin = new Padding(3, 4, 3, 4);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(86, 31);
            CancelarButton.TabIndex = 5;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(201, 199);
            GuardarButton.Margin = new Padding(3, 4, 3, 4);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(86, 31);
            GuardarButton.TabIndex = 4;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // NuevoPlan
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 246);
            Controls.Add(NuevoPlanLabel);
            Controls.Add(DescPlanLabel);
            Controls.Add(DescPlanTextBox);
            Controls.Add(IdEspecialidadLabel);
            Controls.Add(IdEspecialidadTextBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "NuevoPlan";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            Load += NuevoPlan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NuevoPlanLabel;
        private Label DescPlanLabel;
        private TextBox DescPlanTextBox;
        private Label IdEspecialidadLabel;
        private TextBox IdEspecialidadTextBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}