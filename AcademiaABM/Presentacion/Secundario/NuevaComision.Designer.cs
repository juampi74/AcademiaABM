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
            NuevaComisionLabel.Location = new Point(26, 9);
            NuevaComisionLabel.Name = "NuevaComisionLabel";
            NuevaComisionLabel.Size = new Size(212, 37);
            NuevaComisionLabel.TabIndex = 8;
            NuevaComisionLabel.Text = "Nueva Comision";
            // 
            // DescripcionLabel
            // 
            DescripcionLabel.AutoSize = true;
            DescripcionLabel.Location = new Point(36, 66);
            DescripcionLabel.Name = "DescripcionLabel";
            DescripcionLabel.Size = new Size(72, 15);
            DescripcionLabel.TabIndex = 7;
            DescripcionLabel.Text = "Descripcion:";
            // 
            // DescripcionTextBox
            // 
            DescripcionTextBox.BackColor = SystemColors.ControlDarkDark;
            DescripcionTextBox.ForeColor = SystemColors.Menu;
            DescripcionTextBox.Location = new Point(111, 63);
            DescripcionTextBox.Name = "DescripcionTextBox";
            DescripcionTextBox.Size = new Size(129, 23);
            DescripcionTextBox.TabIndex = 0;
            // 
            // AnioEspecialidadTextBox
            // 
            AnioEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            AnioEspecialidadTextBox.ForeColor = SystemColors.Menu;
            AnioEspecialidadTextBox.Location = new Point(111, 100);
            AnioEspecialidadTextBox.Name = "AnioEspecialidadTextBox";
            AnioEspecialidadTextBox.Size = new Size(129, 23);
            AnioEspecialidadTextBox.TabIndex = 1;
            // 
            // AnioEspecialidadLabel
            // 
            AnioEspecialidadLabel.AutoSize = true;
            AnioEspecialidadLabel.Location = new Point(9, 103);
            AnioEspecialidadLabel.Name = "AnioEspecialidadLabel";
            AnioEspecialidadLabel.Size = new Size(100, 15);
            AnioEspecialidadLabel.TabIndex = 6;
            AnioEspecialidadLabel.Text = "Año Especialidad:";
            // 
            // PlanLabel
            // 
            PlanLabel.AutoSize = true;
            PlanLabel.Location = new Point(75, 143);
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
            PlanComboBox.Location = new Point(111, 139);
            PlanComboBox.Name = "PlanComboBox";
            PlanComboBox.Size = new Size(127, 23);
            PlanComboBox.TabIndex = 2;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(22, 181);
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
            GuardarButton.Location = new Point(164, 181);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 3;
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
            Controls.Add(PlanLabel);
            Controls.Add(PlanComboBox);
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
        private Label AnioEspecialidadLabel;
        private TextBox AnioEspecialidadTextBox;
        private Label PlanLabel;
        private ComboBox PlanComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}