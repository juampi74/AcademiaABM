namespace Escritorio
{
    partial class EspecialidadUI
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
            DescEspecialidadLabel = new Label();
            DescEspecialidadTextBox = new TextBox();
            CancelarButton = new Button();
            GuardarButton = new Button();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(57, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(165, 37);
            TituloLabel.TabIndex = 4;
            TituloLabel.Text = "Especialidad";
            // 
            // DescEspecialidadLabel
            // 
            DescEspecialidadLabel.AutoSize = true;
            DescEspecialidadLabel.Location = new Point(46, 67);
            DescEspecialidadLabel.Name = "DescEspecialidadLabel";
            DescEspecialidadLabel.Size = new Size(72, 15);
            DescEspecialidadLabel.TabIndex = 3;
            DescEspecialidadLabel.Text = "Descripción:";
            // 
            // DescEspecialidadTextBox
            // 
            DescEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            DescEspecialidadTextBox.ForeColor = SystemColors.Menu;
            DescEspecialidadTextBox.Location = new Point(127, 64);
            DescEspecialidadTextBox.Name = "DescEspecialidadTextBox";
            DescEspecialidadTextBox.Size = new Size(169, 23);
            DescEspecialidadTextBox.TabIndex = 0;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(63, 104);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 2;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(204, 104);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 1;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // EspecialidadUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 143);
            Controls.Add(TituloLabel);
            Controls.Add(DescEspecialidadLabel);
            Controls.Add(DescEspecialidadTextBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EspecialidadUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label DescEspecialidadLabel;
        private TextBox DescEspecialidadTextBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}