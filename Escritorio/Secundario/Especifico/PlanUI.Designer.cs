namespace Escritorio
{
    partial class PlanUI
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
            DescPlanLabel = new Label();
            DescPlanTextBox = new TextBox();
            EspecialidadLabel = new Label();
            EspecialidadComboBox = new ComboBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(101, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(68, 37);
            TituloLabel.TabIndex = 6;
            TituloLabel.Text = "Plan";
            // 
            // DescPlanLabel
            // 
            DescPlanLabel.AutoSize = true;
            DescPlanLabel.Location = new Point(28, 67);
            DescPlanLabel.Name = "DescPlanLabel";
            DescPlanLabel.Size = new Size(72, 15);
            DescPlanLabel.TabIndex = 5;
            DescPlanLabel.Text = "Descripción:";
            // 
            // DescPlanTextBox
            // 
            DescPlanTextBox.BackColor = SystemColors.ControlDarkDark;
            DescPlanTextBox.ForeColor = SystemColors.Menu;
            DescPlanTextBox.Location = new Point(113, 64);
            DescPlanTextBox.Name = "DescPlanTextBox";
            DescPlanTextBox.Size = new Size(216, 23);
            DescPlanTextBox.TabIndex = 0;
            // 
            // EspecialidadLabel
            // 
            EspecialidadLabel.AutoSize = true;
            EspecialidadLabel.Location = new Point(25, 103);
            EspecialidadLabel.Name = "EspecialidadLabel";
            EspecialidadLabel.Size = new Size(75, 15);
            EspecialidadLabel.TabIndex = 4;
            EspecialidadLabel.Text = "Especialidad:";
            // 
            // EspecialidadComboBox
            // 
            EspecialidadComboBox.BackColor = SystemColors.ControlDarkDark;
            EspecialidadComboBox.ForeColor = SystemColors.Menu;
            EspecialidadComboBox.FormattingEnabled = true;
            EspecialidadComboBox.Location = new Point(113, 100);
            EspecialidadComboBox.Name = "EspecialidadComboBox";
            EspecialidadComboBox.Size = new Size(216, 23);
            EspecialidadComboBox.TabIndex = 1;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(64, 143);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 3;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(203, 143);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 2;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // PlanUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 184);
            Controls.Add(TituloLabel);
            Controls.Add(DescPlanLabel);
            Controls.Add(DescPlanTextBox);
            Controls.Add(EspecialidadLabel);
            Controls.Add(EspecialidadComboBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "PlanUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label DescPlanLabel;
        private TextBox DescPlanTextBox;
        private Label EspecialidadLabel;
        private ComboBox EspecialidadComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}