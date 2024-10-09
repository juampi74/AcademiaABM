namespace Escritorio
{
    partial class ErrorBaseDeDatos
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
            ErrorEliminacionLabel = new Label();
            CerrarButton = new Button();
            SuspendLayout();
            // 
            // ErrorEliminacionLabel
            // 
            ErrorEliminacionLabel.AutoSize = true;
            ErrorEliminacionLabel.Font = new Font("Segoe UI", 15F);
            ErrorEliminacionLabel.Location = new Point(12, 9);
            ErrorEliminacionLabel.Name = "ErrorEliminacionLabel";
            ErrorEliminacionLabel.Size = new Size(78, 28);
            ErrorEliminacionLabel.TabIndex = 1;
            ErrorEliminacionLabel.Text = "${error}";
            // 
            // CerrarButton
            // 
            CerrarButton.BackColor = SystemColors.ActiveBorder;
            CerrarButton.Location = new Point(513, 53);
            CerrarButton.Name = "CerrarButton";
            CerrarButton.Size = new Size(75, 23);
            CerrarButton.TabIndex = 0;
            CerrarButton.Text = "Cerrar";
            CerrarButton.UseVisualStyleBackColor = false;
            CerrarButton.Click += CerrarButton_Click;
            // 
            // ErrorEliminacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 87);
            Controls.Add(CerrarButton);
            Controls.Add(ErrorEliminacionLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ErrorEliminacion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Error";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label ErrorEliminacionLabel;
        private Button CerrarButton;
    }
}