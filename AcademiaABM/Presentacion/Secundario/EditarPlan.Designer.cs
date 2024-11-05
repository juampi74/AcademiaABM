namespace AcademiaABM.Presentacion
{
    partial class EditarPlan
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
            EditarPlanLabel = new Label();
            DescPlanLabel = new Label();
            DescPlanTextBox = new TextBox();
            IdEspecialidadLabel = new Label();
            IdEspecialidadTextBox = new TextBox();
            GuardarButton = new Button();
            CancelarButton = new Button();
            SuspendLayout();
            // 
            // EditarPlanLabel
            // 
            EditarPlanLabel.AutoSize = true;
            EditarPlanLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditarPlanLabel.Location = new Point(68, 12);
            EditarPlanLabel.Name = "EditarPlanLabel";
            EditarPlanLabel.Size = new Size(178, 46);
            EditarPlanLabel.TabIndex = 20;
            EditarPlanLabel.Text = "Editar Plan";
            // 
            // DescPlanLabel
            // 
            DescPlanLabel.AutoSize = true;
            DescPlanLabel.Location = new Point(39, 80);
            DescPlanLabel.Name = "DescPlanLabel";
            DescPlanLabel.Size = new Size(90, 20);
            DescPlanLabel.TabIndex = 12;
            DescPlanLabel.Text = "Descripción:";
            // 
            // DescPlanTextBox
            // 
            DescPlanTextBox.BackColor = SystemColors.ControlDarkDark;
            DescPlanTextBox.ForeColor = SystemColors.Menu;
            DescPlanTextBox.Location = new Point(145, 77);
            DescPlanTextBox.Margin = new Padding(3, 4, 3, 4);
            DescPlanTextBox.Name = "DescPlanTextBox";
            DescPlanTextBox.Size = new Size(147, 27);
            DescPlanTextBox.TabIndex = 7;
            // 
            // IdEspecialidadLabel
            // 
            IdEspecialidadLabel.AutoSize = true;
            IdEspecialidadLabel.Location = new Point(35, 136);
            IdEspecialidadLabel.Name = "IdEspecialidadLabel";
            IdEspecialidadLabel.Size = new Size(96, 20);
            IdEspecialidadLabel.TabIndex = 12;
            IdEspecialidadLabel.Text = "Especialidad:";
            // 
            // IdEspecialidadTextBox
            // 
            IdEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            IdEspecialidadTextBox.ForeColor = SystemColors.Menu;
            IdEspecialidadTextBox.Location = new Point(145, 133);
            IdEspecialidadTextBox.Margin = new Padding(3, 4, 3, 4);
            IdEspecialidadTextBox.Name = "IdEspecialidadTextBox";
            IdEspecialidadTextBox.Size = new Size(147, 27);
            IdEspecialidadTextBox.TabIndex = 7;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(201, 192);
            GuardarButton.Margin = new Padding(3, 4, 3, 4);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(86, 31);
            GuardarButton.TabIndex = 9;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += EditarGuardarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(38, 192);
            CancelarButton.Margin = new Padding(3, 4, 3, 4);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(86, 31);
            CancelarButton.TabIndex = 10;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += EditarCancelarButton_Click;
            // 
            // EditarPlan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 242);
            Controls.Add(EditarPlanLabel);
            Controls.Add(DescPlanLabel);
            Controls.Add(DescPlanTextBox);
            Controls.Add(IdEspecialidadLabel);
            Controls.Add(IdEspecialidadTextBox);
            Controls.Add(GuardarButton);
            Controls.Add(CancelarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "EditarPlan";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label EditarPlanLabel;
        private Label DescPlanLabel;
        private TextBox DescPlanTextBox;
        private Label IdEspecialidadLabel;
        private TextBox IdEspecialidadTextBox;
        private Button GuardarButton;
        private Button CancelarButton;
    }
}