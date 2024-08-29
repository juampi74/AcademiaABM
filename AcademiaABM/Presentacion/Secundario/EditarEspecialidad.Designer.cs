namespace AcademiaABM.Presentacion
{
    partial class EditarEspecialidad
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
            EditarEspecialidadLabel = new Label();
            DescEspecialidadLabel = new Label();
            DescEspecialidadTextBox = new TextBox();
            GuardarButton = new Button();
            CancelarButton = new Button();
            SuspendLayout();
            // 
            // EditarEspecialidadLabel
            // 
            EditarEspecialidadLabel.AutoSize = true;
            EditarEspecialidadLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditarEspecialidadLabel.Location = new Point(15, 12);
            EditarEspecialidadLabel.Name = "EditarEspecialidadLabel";
            EditarEspecialidadLabel.Size = new Size(298, 46);
            EditarEspecialidadLabel.TabIndex = 20;
            EditarEspecialidadLabel.Text = "Editar Especialidad";
            // 
            // DescEspecialidadLabel
            // 
            DescEspecialidadLabel.AutoSize = true;
            DescEspecialidadLabel.Location = new Point(42, 88);
            DescEspecialidadLabel.Name = "DescEspecialidadLabel";
            DescEspecialidadLabel.Size = new Size(90, 20);
            DescEspecialidadLabel.TabIndex = 12;
            DescEspecialidadLabel.Text = "Descripción:";
            // 
            // DescEspecialidadTextBox
            // 
            DescEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            DescEspecialidadTextBox.ForeColor = SystemColors.Menu;
            DescEspecialidadTextBox.Location = new Point(152, 85);
            DescEspecialidadTextBox.Margin = new Padding(3, 4, 3, 4);
            DescEspecialidadTextBox.Name = "DescEspecialidadTextBox";
            DescEspecialidadTextBox.Size = new Size(147, 27);
            DescEspecialidadTextBox.TabIndex = 7;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(201, 137);
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
            CancelarButton.Location = new Point(38, 137);
            CancelarButton.Margin = new Padding(3, 4, 3, 4);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(86, 31);
            CancelarButton.TabIndex = 10;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += EditarCancelarButton_Click;
            // 
            // EditarEspecialidad
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 197);
            Controls.Add(EditarEspecialidadLabel);
            Controls.Add(DescEspecialidadLabel);
            Controls.Add(DescEspecialidadTextBox);
            Controls.Add(GuardarButton);
            Controls.Add(CancelarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "EditarEspecialidad";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label EditarEspecialidadLabel;
        private Label DescEspecialidadLabel;
        private TextBox DescEspecialidadTextBox;
        private Button GuardarButton;
        private Button CancelarButton;
    }
}