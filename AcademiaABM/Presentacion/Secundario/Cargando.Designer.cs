namespace AcademiaABM.Presentacion
{
    partial class Cargando
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
            label1 = new Label();
            SuspendLayout();
            // 
            // OperacionCompletadaLabel
            // 
            OperacionCompletadaLabel.AutoSize = true;
            OperacionCompletadaLabel.Font = new Font("Segoe UI", 15F);
            OperacionCompletadaLabel.Location = new Point(12, 9);
            OperacionCompletadaLabel.Name = "OperacionCompletadaLabel";
            OperacionCompletadaLabel.Size = new Size(292, 28);
            OperacionCompletadaLabel.TabIndex = 2;
            OperacionCompletadaLabel.Text = "Conectando a la Base de Datos...";
            OperacionCompletadaLabel.UseWaitCursor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(23, 48);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 3;
            label1.Text = "Por favor, espere.";
            label1.UseWaitCursor = true;
            // 
            // Cargando
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 83);
            Controls.Add(label1);
            Controls.Add(OperacionCompletadaLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Cargando";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cargando...";
            TopMost = true;
            UseWaitCursor = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OperacionCompletadaLabel;
        private Label label1;
    }
}