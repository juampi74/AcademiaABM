namespace AcademiaABM.Presentacion
{
    partial class EditarComision
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
            EditarComisionLabel = new Label();
            DescComisionLabel = new Label();
            DescComisionTextBox = new TextBox();
            AnioEspecialidadLabel = new Label();
            AnioEspecialidadTextBox = new TextBox();
            IdPlanLabel = new Label();
            IdPlanTextBox = new TextBox();
            GuardarButton = new Button();
            CancelarButton = new Button();
            SuspendLayout();
            // 
            // EditarComisionLabel
            // 
            EditarComisionLabel.AutoSize = true;
            EditarComisionLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EditarComisionLabel.Location = new Point(28, 9);
            EditarComisionLabel.Name = "EditarComisionLabel";
            EditarComisionLabel.Size = new Size(205, 37);
            EditarComisionLabel.TabIndex = 20;
            EditarComisionLabel.Text = "Editar Comision";
            // 
            // DescComisionLabel
            // 
            DescComisionLabel.AutoSize = true;
            DescComisionLabel.Location = new Point(37, 60);
            DescComisionLabel.Name = "DescComisionLabel";
            DescComisionLabel.Size = new Size(72, 15);
            DescComisionLabel.TabIndex = 12;
            DescComisionLabel.Text = "Descripción:";
            // 
            // DescComisionTextBox
            // 
            DescComisionTextBox.BackColor = SystemColors.ControlDarkDark;
            DescComisionTextBox.ForeColor = SystemColors.Menu;
            DescComisionTextBox.Location = new Point(124, 57);
            DescComisionTextBox.Name = "DescComisionTextBox";
            DescComisionTextBox.Size = new Size(129, 23);
            DescComisionTextBox.TabIndex = 7;
            // 
            // AnioEspecialidadLabel
            // 
            AnioEspecialidadLabel.AutoSize = true;
            AnioEspecialidadLabel.Location = new Point(9, 99);
            AnioEspecialidadLabel.Name = "AnioEspecialidadLabel";
            AnioEspecialidadLabel.Size = new Size(100, 15);
            AnioEspecialidadLabel.TabIndex = 14;
            AnioEspecialidadLabel.Text = "Año Especialidad:";
            // 
            // AnioEspecialidadTextBox
            // 
            AnioEspecialidadTextBox.BackColor = SystemColors.ControlDarkDark;
            AnioEspecialidadTextBox.ForeColor = SystemColors.Menu;
            AnioEspecialidadTextBox.Location = new Point(124, 96);
            AnioEspecialidadTextBox.Name = "AnioEspecialidadTextBox";
            AnioEspecialidadTextBox.Size = new Size(129, 23);
            AnioEspecialidadTextBox.TabIndex = 5;
            // 
            // IdPlanLabel
            // 
            IdPlanLabel.AutoSize = true;
            IdPlanLabel.Location = new Point(76, 138);
            IdPlanLabel.Name = "IdPlanLabel";
            IdPlanLabel.Size = new Size(33, 15);
            IdPlanLabel.TabIndex = 11;
            IdPlanLabel.Text = "Plan:";
            // 
            // IdPlanTextBox
            // 
            IdPlanTextBox.BackColor = SystemColors.ControlDarkDark;
            IdPlanTextBox.ForeColor = SystemColors.Menu;
            IdPlanTextBox.Location = new Point(124, 135);
            IdPlanTextBox.Name = "IdPlanTextBox";
            IdPlanTextBox.Size = new Size(129, 23);
            IdPlanTextBox.TabIndex = 8;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(167, 187);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 9;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += EditarGuardarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(20, 187);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 10;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += EditarCancelarButton_Click;
            // 
            // EditarComision
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 220);
            Controls.Add(EditarComisionLabel);
            Controls.Add(DescComisionLabel);
            Controls.Add(DescComisionTextBox);
            Controls.Add(AnioEspecialidadLabel);
            Controls.Add(AnioEspecialidadTextBox);
            Controls.Add(IdPlanLabel);
            Controls.Add(IdPlanTextBox);
            Controls.Add(GuardarButton);
            Controls.Add(CancelarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditarComision";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label EditarComisionLabel;
        private Label DescComisionLabel;
        private TextBox DescComisionTextBox;
        private Label AnioEspecialidadLabel;
        private TextBox AnioEspecialidadTextBox;
        private Label IdPlanLabel;
        private TextBox IdPlanTextBox;
        private Button GuardarButton;
        private Button CancelarButton;
    }
}