namespace AcademiaABM.Presentacion
{
    partial class OperacionExitosa
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
            OperacionCompletadaLabel = new Label();
            CerrarButton = new Button();
            SuspendLayout();
            // 
            // OperacionCompletadaLabel
            // 
            OperacionCompletadaLabel.AutoSize = true;
            OperacionCompletadaLabel.Font = new Font("Segoe UI", 15F);
            OperacionCompletadaLabel.Location = new Point(12, 11);
            OperacionCompletadaLabel.Name = "OperacionCompletadaLabel";
            OperacionCompletadaLabel.Size = new Size(373, 28);
            OperacionCompletadaLabel.TabIndex = 1;
            OperacionCompletadaLabel.Text = "La operación se completó correctamente!";
            // 
            // CerrarButton
            // 
            CerrarButton.BackColor = SystemColors.ActiveBorder;
            CerrarButton.Location = new Point(355, 54);
            CerrarButton.Name = "CerrarButton";
            CerrarButton.Size = new Size(75, 23);
            CerrarButton.TabIndex = 0;
            CerrarButton.Text = "Cerrar";
            CerrarButton.UseVisualStyleBackColor = false;
            CerrarButton.Click += CerrarButton_Click;
            // 
            // OperacionExitosa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 91);
            Controls.Add(CerrarButton);
            Controls.Add(OperacionCompletadaLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "OperacionExitosa";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Operación Exitosa!";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OperacionCompletadaLabel;
        private Button CerrarButton;
    }
}