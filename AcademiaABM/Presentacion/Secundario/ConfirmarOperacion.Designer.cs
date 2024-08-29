namespace AcademiaABM.Presentacion
{
    partial class ConfirmarOperacion
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
            ConfirmarOperacionLabel = new Label();
            ConfirmarButton = new Button();
            CancelarButton = new Button();
            SuspendLayout();
            // 
            // ConfirmarOperacionLabel
            // 
            ConfirmarOperacionLabel.AutoSize = true;
            ConfirmarOperacionLabel.Font = new Font("Segoe UI", 15F);
            ConfirmarOperacionLabel.Location = new Point(14, 12);
            ConfirmarOperacionLabel.Name = "ConfirmarOperacionLabel";
            ConfirmarOperacionLabel.Size = new Size(552, 35);
            ConfirmarOperacionLabel.TabIndex = 2;
            ConfirmarOperacionLabel.Text = "¿Está seguro que quiere confirmar la operación?";
            // 
            // ConfirmarButton
            // 
            ConfirmarButton.BackColor = Color.SteelBlue;
            ConfirmarButton.ForeColor = Color.Cornsilk;
            ConfirmarButton.Location = new Point(483, 73);
            ConfirmarButton.Margin = new Padding(3, 4, 3, 4);
            ConfirmarButton.Name = "ConfirmarButton";
            ConfirmarButton.Size = new Size(86, 31);
            ConfirmarButton.TabIndex = 0;
            ConfirmarButton.Text = "Confirmar";
            ConfirmarButton.UseVisualStyleBackColor = false;
            ConfirmarButton.Click += ConfirmarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(391, 73);
            CancelarButton.Margin = new Padding(3, 4, 3, 4);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(86, 31);
            CancelarButton.TabIndex = 1;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // ConfirmarOperacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 121);
            Controls.Add(ConfirmarButton);
            Controls.Add(CancelarButton);
            Controls.Add(ConfirmarOperacionLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ConfirmarOperacion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirmación";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ConfirmarOperacionLabel;
        private Button ConfirmarButton;
        private Button CancelarButton;
    }
}