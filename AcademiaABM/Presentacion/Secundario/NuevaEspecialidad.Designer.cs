namespace AcademiaABM.Presentacion
{
    partial class NuevaEspecialidad
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
            NuevaEspecialidadLabel = new Label();
            DescEspecialidadLabel = new Label();
            DescEspecialidadTextBox = new TextBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // NuevaEspecialidadLabel
            // 
            NuevaEspecialidadLabel.AutoSize = true;
            NuevaEspecialidadLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NuevaEspecialidadLabel.Location = new Point(9, 12);
            NuevaEspecialidadLabel.Name = "NuevaEspecialidadLabel";
            NuevaEspecialidadLabel.Size = new Size(307, 46);
            NuevaEspecialidadLabel.TabIndex = 10;
            NuevaEspecialidadLabel.Text = "Nueva Especialidad";
            // 
            // DescEspecialidadLabel
            // 
            DescEspecialidadLabel.AutoSize = true;
            DescEspecialidadLabel.Location = new Point(36, 88);
            DescEspecialidadLabel.Name = "DescEspecialidadLabel";
            DescEspecialidadLabel.Size = new Size(90, 20);
            DescEspecialidadLabel.TabIndex = 9;
            DescEspecialidadLabel.Text = "Descripción:";
            // 
            // DescEspecialidadTextBox
            // 
            DescEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            DescEspecialidadTextBox.ForeColor = SystemColors.Menu;
            DescEspecialidadTextBox.Location = new Point(145, 84);
            DescEspecialidadTextBox.Margin = new Padding(3, 4, 3, 4);
            DescEspecialidadTextBox.Name = "DescEspecialidadTextBox";
            DescEspecialidadTextBox.Size = new Size(148, 27);
            DescEspecialidadTextBox.TabIndex = 0;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(36, 140);
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
            GuardarButton.Location = new Point(198, 140);
            GuardarButton.Margin = new Padding(3, 4, 3, 4);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(86, 31);
            GuardarButton.TabIndex = 4;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // NuevaEspecialidad
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 191);
            Controls.Add(NuevaEspecialidadLabel);
            Controls.Add(DescEspecialidadLabel);
            Controls.Add(DescEspecialidadTextBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "NuevaEspecialidad";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NuevaEspecialidadLabel;
        private Label DescEspecialidadLabel;
        private TextBox DescEspecialidadTextBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}