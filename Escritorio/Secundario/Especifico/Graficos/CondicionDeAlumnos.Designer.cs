namespace Escritorio
{
    partial class CondicionDeAlumnos
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
            plot = new OxyPlot.WindowsForms.PlotView();
            SuspendLayout();
            // 
            // TituloLabel
            // 
            TituloLabel.AutoSize = true;
            TituloLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TituloLabel.Location = new Point(322, 14);
            TituloLabel.Name = "TituloLabel";
            TituloLabel.Size = new Size(286, 37);
            TituloLabel.TabIndex = 13;
            TituloLabel.Text = "Condicion de Alumnos";
            // 
            // plot
            // 
            plot.Location = new Point(12, 54);
            plot.Name = "plot";
            plot.PanCursor = Cursors.Hand;
            plot.Size = new Size(910, 392);
            plot.TabIndex = 14;
            plot.Text = "AlumnosPorPlan";
            plot.ZoomHorizontalCursor = Cursors.SizeWE;
            plot.ZoomRectangleCursor = Cursors.SizeNWSE;
            plot.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // CondicionDeAlumnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(934, 461);
            Controls.Add(plot);
            Controls.Add(TituloLabel);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "CondicionDeAlumnos";
            StartPosition = FormStartPosition.CenterParent;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TituloLabel;
        private OxyPlot.WindowsForms.PlotView plot;
    }
}