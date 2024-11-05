namespace Escritorio
{
    partial class CampoRequerido
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
            CampoRequeridoLabel = new Label();
            CerrarButton = new Button();
            SuspendLayout();
            // 
            // CampoRequeridoLabel
            // 
            CampoRequeridoLabel.AutoSize = true;
            CampoRequeridoLabel.Font = new Font("Segoe UI", 15F);
            CampoRequeridoLabel.Location = new Point(12, 9);
            CampoRequeridoLabel.Name = "CampoRequeridoLabel";
            CampoRequeridoLabel.Size = new Size(300, 28);
            CampoRequeridoLabel.TabIndex = 1;
            CampoRequeridoLabel.Text = "El campo ${campo} es requerido!";
            // 
            // CerrarButton
            // 
            CerrarButton.BackColor = SystemColors.ActiveBorder;
            CerrarButton.Location = new Point(362, 53);
            CerrarButton.Name = "CerrarButton";
            CerrarButton.Size = new Size(75, 23);
            CerrarButton.TabIndex = 0;
            CerrarButton.Text = "Cerrar";
            CerrarButton.UseVisualStyleBackColor = false;
            CerrarButton.Click += CerrarButton_Click;
            // 
            // CampoRequerido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 88);
            Controls.Add(CerrarButton);
            Controls.Add(CampoRequeridoLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "CampoRequerido";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Campo Requerido";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label CampoRequeridoLabel;
        private Button CerrarButton;
    }
}