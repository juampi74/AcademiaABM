namespace Escritorio
{
    partial class MateriaUI
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
            HsSemanalesLabel = new Label();
            HsSemanalesTextBox = new TextBox();
            HsTotalesLabel = new Label();
            HsTotalesTextBox = new TextBox();
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
            TituloLabel.Location = new Point(86, 9);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(108, 37);
            TituloLabel.TabIndex = 10;
            TituloLabel.Text = "Materia";
            // 
            // DescripcionLabel
            // 
            DescripcionLabel.AutoSize = true;
            DescripcionLabel.Location = new Point(36, 66);
            DescripcionLabel.Name = "DescripcionLabel";
            DescripcionLabel.Size = new Size(72, 15);
            DescripcionLabel.TabIndex = 9;
            DescripcionLabel.Text = "Descripcion:";
            // 
            // DescripcionTextBox
            // 
            DescripcionTextBox.BackColor = SystemColors.ControlDarkDark;
            DescripcionTextBox.ForeColor = SystemColors.Menu;
            DescripcionTextBox.Location = new Point(120, 64);
            DescripcionTextBox.Name = "DescripcionTextBox";
            DescripcionTextBox.Size = new Size(250, 23);
            DescripcionTextBox.TabIndex = 0;
            // 
            // HsSemanalesLabel
            // 
            HsSemanalesLabel.AutoSize = true;
            HsSemanalesLabel.Location = new Point(8, 106);
            HsSemanalesLabel.Name = "HsSemanalesLabel";
            HsSemanalesLabel.Size = new Size(100, 15);
            HsSemanalesLabel.TabIndex = 8;
            HsSemanalesLabel.Text = "Horas Semanales:";
            // 
            // HsSemanalesTextBox
            // 
            HsSemanalesTextBox.BackColor = SystemColors.ControlDarkDark;
            HsSemanalesTextBox.ForeColor = SystemColors.Menu;
            HsSemanalesTextBox.Location = new Point(119, 103);
            HsSemanalesTextBox.Name = "HsSemanalesTextBox";
            HsSemanalesTextBox.Size = new Size(250, 23);
            HsSemanalesTextBox.TabIndex = 1;
            // 
            // HsTotalesLabel
            // 
            HsTotalesLabel.AutoSize = true;
            HsTotalesLabel.Location = new Point(28, 143);
            HsTotalesLabel.Name = "HsTotalesLabel";
            HsTotalesLabel.Size = new Size(80, 15);
            HsTotalesLabel.TabIndex = 7;
            HsTotalesLabel.Text = "Horas Totales:";
            // 
            // HsTotalesTextBox
            // 
            HsTotalesTextBox.BackColor = SystemColors.ControlDarkDark;
            HsTotalesTextBox.ForeColor = SystemColors.Menu;
            HsTotalesTextBox.Location = new Point(119, 139);
            HsTotalesTextBox.Name = "HsTotalesTextBox";
            HsTotalesTextBox.Size = new Size(250, 23);
            HsTotalesTextBox.TabIndex = 2;
            // 
            // PlanLabel
            // 
            PlanLabel.AutoSize = true;
            PlanLabel.Location = new Point(74, 176);
            PlanLabel.Name = "PlanLabel";
            PlanLabel.Size = new Size(33, 15);
            PlanLabel.TabIndex = 6;
            PlanLabel.Text = "Plan:";
            // 
            // PlanComboBox
            // 
            PlanComboBox.BackColor = SystemColors.GrayText;
            PlanComboBox.ForeColor = SystemColors.Window;
            PlanComboBox.FormattingEnabled = true;
            PlanComboBox.Location = new Point(119, 173);
            PlanComboBox.Name = "PlanComboBox";
            PlanComboBox.Size = new Size(248, 23);
            PlanComboBox.TabIndex = 3;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(75, 215);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 5;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // GuardarButton
            // 
            GuardarButton.BackColor = Color.SteelBlue;
            GuardarButton.ForeColor = Color.Cornsilk;
            GuardarButton.Location = new Point(217, 215);
            GuardarButton.Name = "GuardarButton";
            GuardarButton.Size = new Size(75, 23);
            GuardarButton.TabIndex = 4;
            GuardarButton.Text = "Guardar";
            GuardarButton.UseVisualStyleBackColor = false;
            GuardarButton.Click += GuardarButton_Click;
            // 
            // MateriaUI
            // 
            AcceptButton = GuardarButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 256);
            Controls.Add(TituloLabel);
            Controls.Add(DescripcionLabel);
            Controls.Add(DescripcionTextBox);
            Controls.Add(HsSemanalesLabel);
            Controls.Add(HsSemanalesTextBox);
            Controls.Add(HsTotalesLabel);
            Controls.Add(HsTotalesTextBox);
            Controls.Add(PlanLabel);
            Controls.Add(PlanComboBox);
            Controls.Add(CancelarButton);
            Controls.Add(GuardarButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MateriaUI";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private Label DescripcionLabel;
        private TextBox DescripcionTextBox;
        private Label HsSemanalesLabel;
        private TextBox HsSemanalesTextBox;
        private Label HsTotalesLabel;
        private TextBox HsTotalesTextBox;
        private Label PlanLabel;
        private ComboBox PlanComboBox;
        private Button CancelarButton;
        private Button GuardarButton;
    }
}