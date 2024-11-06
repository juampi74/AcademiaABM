namespace Escritorio
{
    partial class ComisionUI
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
            DescripcionLabel = new Label();
            DescripcionTextBox = new TextBox();
            AnioEspecialidadTextBox = new TextBox();
            AnioEspecialidadLabel = new Label();
            PlanLabel = new Label();
            PlanComboBox = new ComboBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(95, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(129, 37);
            TituloLabel.TabIndex = 8;
            TituloLabel.Text = "Comision";
            // 
            // DescripcionLabel
            // 
            DescripcionLabel.AutoSize = true;
            DescripcionLabel.Location = new Point(40, 66);
            DescripcionLabel.Name = "DescripcionLabel";
            DescripcionLabel.Size = new Size(72, 15);
            DescripcionLabel.TabIndex = 7;
            DescripcionLabel.Text = "Descripcion:";
            // 
            // DescripcionTextBox
            // 
            DescripcionTextBox.BackColor = SystemColors.ControlDarkDark;
            DescripcionTextBox.ForeColor = SystemColors.Menu;
            DescripcionTextBox.Location = new Point(124, 64);
            DescripcionTextBox.Name = "DescripcionTextBox";
            DescripcionTextBox.Size = new Size(245, 23);
            DescripcionTextBox.TabIndex = 0;
            // 
            // AnioEspecialidadTextBox
            // 
            AnioEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            AnioEspecialidadTextBox.ForeColor = SystemColors.Menu;
            AnioEspecialidadTextBox.Location = new Point(124, 100);
            AnioEspecialidadTextBox.Name = "AnioEspecialidadTextBox";
            AnioEspecialidadTextBox.Size = new Size(245, 23);
            AnioEspecialidadTextBox.TabIndex = 1;
            // 
            // AnioEspecialidadLabel
            // 
            AnioEspecialidadLabel.AutoSize = true;
            AnioEspecialidadLabel.Location = new Point(13, 103);
            AnioEspecialidadLabel.Name = "AnioEspecialidadLabel";
            AnioEspecialidadLabel.Size = new Size(100, 15);
            AnioEspecialidadLabel.TabIndex = 6;
            AnioEspecialidadLabel.Text = "Año Especialidad:";
            // 
            // PlanLabel
            // 
            PlanLabel.AutoSize = true;
            PlanLabel.Location = new Point(80, 138);
            PlanLabel.Name = "PlanLabel";
            PlanLabel.Size = new Size(33, 15);
            PlanLabel.TabIndex = 5;
            PlanLabel.Text = "Plan:";
            // 
            // PlanComboBox
            // 
            PlanComboBox.BackColor = SystemColors.GrayText;
            PlanComboBox.ForeColor = SystemColors.Window;
            PlanComboBox.FormattingEnabled = true;
            PlanComboBox.Location = new Point(124, 136);
            PlanComboBox.Name = "PlanComboBox";
            PlanComboBox.Size = new Size(245, 23);
            PlanComboBox.TabIndex = 2;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(79, 181);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 4;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(221, 181);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 3;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // ComisionUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 218);
            Controls.Add(TituloLabel);
            Controls.Add(DescripcionLabel);
            Controls.Add(DescripcionTextBox);
            Controls.Add(AnioEspecialidadLabel);
            Controls.Add(AnioEspecialidadTextBox);
            Controls.Add(PlanLabel);
            Controls.Add(PlanComboBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ComisionUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label DescripcionLabel;
        private TextBox DescripcionTextBox;
        private Label AnioEspecialidadLabel;
        private TextBox AnioEspecialidadTextBox;
        private Label PlanLabel;
        private ComboBox PlanComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}