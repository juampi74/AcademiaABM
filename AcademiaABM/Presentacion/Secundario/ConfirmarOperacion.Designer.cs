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
            ConfirmarOperacionLabel.Location = new Point(12, 9);
            ConfirmarOperacionLabel.Name = "ConfirmarOperacionLabel";
            ConfirmarOperacionLabel.Size = new Size(430, 28);
            ConfirmarOperacionLabel.TabIndex = 2;
            ConfirmarOperacionLabel.Text = "¿Está seguro que quiere confirmar la operación?";
            // 
            // ConfirmarButton
            // 
            ConfirmarButton.BackColor = Color.SteelBlue;
            ConfirmarButton.ForeColor = Color.Cornsilk;
            ConfirmarButton.Location = new Point(358, 55);
            ConfirmarButton.Name = "ConfirmarButton";
            ConfirmarButton.Size = new Size(75, 23);
            ConfirmarButton.TabIndex = 0;
            ConfirmarButton.Text = "Confirmar";
            ConfirmarButton.UseVisualStyleBackColor = false;
            ConfirmarButton.Click += ConfirmarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.BackColor = Color.DarkRed;
            CancelarButton.ForeColor = Color.Cornsilk;
            CancelarButton.Location = new Point(273, 55);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(75, 23);
            CancelarButton.TabIndex = 1;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = false;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // ConfirmarOperacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 91);
            Controls.Add(ConfirmarButton);
            Controls.Add(CancelarButton);
            Controls.Add(ConfirmarOperacionLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
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