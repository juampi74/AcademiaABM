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
            PlanLabel = new Label();
            PlanComboBox = new ComboBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // NuevaComisionLabel
            // 
            NuevaComisionLabel.AutoSize = true;
            NuevaComisionLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NuevaComisionLabel.Location = new Point(30, 12);
            NuevaComisionLabel.Name = "NuevaComisionLabel";
            NuevaComisionLabel.Size = new Size(263, 46);
            NuevaComisionLabel.TabIndex = 8;
            NuevaComisionLabel.Text = "Nueva Comision";
            // 
            // DescripcionLabel
            // 
            DescripcionLabel.AutoSize = true;
            DescripcionLabel.Location = new Point(41, 88);
            DescripcionLabel.Name = "DescripcionLabel";
            DescripcionLabel.Size = new Size(90, 20);
            DescripcionLabel.TabIndex = 7;
            DescripcionLabel.Text = "Descripcion:";
            // 
            // DescripcionTextBox
            // 
            DescripcionTextBox.BackColor = SystemColors.ControlDarkDark;
            DescripcionTextBox.ForeColor = SystemColors.Menu;
            DescripcionTextBox.Location = new Point(137, 85);
            DescripcionTextBox.Margin = new Padding(3, 4, 3, 4);
            DescripcionTextBox.Name = "DescripcionTextBox";
            DescripcionTextBox.Size = new Size(147, 27);
            DescripcionTextBox.TabIndex = 0;
            // 
            // AnioEspecialidadTextBox
            // 
            AnioEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            AnioEspecialidadTextBox.ForeColor = SystemColors.Menu;
            AnioEspecialidadTextBox.Location = new Point(140, 134);
            AnioEspecialidadTextBox.Margin = new Padding(3, 4, 3, 4);
            AnioEspecialidadTextBox.Name = "AnioEspecialidadTextBox";
            AnioEspecialidadTextBox.Size = new Size(147, 27);
            AnioEspecialidadTextBox.TabIndex = 1;
            // 
            // AnioEspecialidadLabel
            // 
            AnioEspecialidadLabel.AutoSize = true;
            AnioEspecialidadLabel.Location = new Point(10, 137);
            AnioEspecialidadLabel.Name = "AnioEspecialidadLabel";
            AnioEspecialidadLabel.Size = new Size(127, 20);
            AnioEspecialidadLabel.TabIndex = 6;
            AnioEspecialidadLabel.Text = "Año Especialidad:";
            // 
            // PlanLabel
            // 
            PlanLabel.AutoSize = true;
            PlanLabel.Location = new Point(91, 186);
            PlanLabel.Name = "PlanLabel";
            PlanLabel.Size = new Size(40, 20);
            PlanLabel.TabIndex = 5;
            PlanLabel.Text = "Plan:";
            // 
            // PlanComboBox
            // 
            PlanComboBox.BackColor = SystemColors.GrayText;
            PlanComboBox.ForeColor = SystemColors.Window;
            PlanComboBox.FormattingEnabled = true;
            PlanComboBox.Location = new Point(142, 183);
            PlanComboBox.Margin = new Padding(3, 4, 3, 4);
            PlanComboBox.Name = "PlanComboBox";
            PlanComboBox.Size = new Size(145, 28);
            PlanComboBox.TabIndex = 2;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(25, 241);
            CancelarButton.Margin = new Padding(3, 4, 3, 4);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(86, 31);
            CancelarButton.TabIndex = 4;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(187, 241);
            GuardarButton.Margin = new Padding(3, 4, 3, 4);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(86, 31);
            GuardarButton.TabIndex = 3;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // NuevaComision
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 291);
            Controls.Add(NuevaComisionLabel);
            Controls.Add(DescripcionLabel);
            Controls.Add(DescripcionTextBox);
            Controls.Add(AnioEspecialidadLabel);
            Controls.Add(AnioEspecialidadTextBox);
            Controls.Add(PlanLabel);
            Controls.Add(PlanComboBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
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
        private Label AnioEspecialidadLabel;
        private TextBox AnioEspecialidadTextBox;
        private Label PlanLabel;
        private ComboBox PlanComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}