namespace AcademiaABM
{
    partial class Usuarios
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            toolStripContainer1 = new ToolStripContainer();
            tlAlumnos = new TableLayoutPanel();
            dgvUsuarios = new DataGridView();
            btnActualizar = new Button();
            btnSalir = new Button();
            tsUsuarios = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbEliminar = new ToolStripButton();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            tlAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tsUsuarios.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(tlAlumnos);
            toolStripContainer1.ContentPanel.Size = new Size(800, 425);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(800, 450);
            toolStripContainer1.TabIndex = 0;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(tsUsuarios);
            // 
            // tlAlumnos
            // 
            tlAlumnos.ColumnCount = 2;
            tlAlumnos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlAlumnos.ColumnStyles.Add(new ColumnStyle());
            tlAlumnos.Controls.Add(dgvUsuarios, 0, 0);
            tlAlumnos.Controls.Add(btnActualizar, 0, 1);
            tlAlumnos.Controls.Add(btnSalir, 1, 1);
            tlAlumnos.Dock = DockStyle.Fill;
            tlAlumnos.Location = new Point(0, 0);
            tlAlumnos.Name = "tlAlumnos";
            tlAlumnos.RowCount = 2;
            tlAlumnos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlAlumnos.RowStyles.Add(new RowStyle());
            tlAlumnos.Size = new Size(800, 425);
            tlAlumnos.TabIndex = 0;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlAlumnos.SetColumnSpan(dgvUsuarios, 2);
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(3, 3);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.Size = new Size(794, 390);
            dgvUsuarios.TabIndex = 0;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(641, 399);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(722, 399);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // tsUsuarios
            // 
            tsUsuarios.Dock = DockStyle.None;
            tsUsuarios.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbEditar, tsbEliminar });
            tsUsuarios.Location = new Point(3, 0);
            tsUsuarios.Name = "tsUsuarios";
            tsUsuarios.Size = new Size(81, 25);
            tsUsuarios.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(23, 22);
            tsbNuevo.Text = "Nuevo";
            // 
            // tsbEditar
            // 
            tsbEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(23, 22);
            tsbEditar.Text = "Editar";
            // 
            // tsbEliminar
            // 
            tsbEliminar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEliminar.ImageTransparentColor = Color.Magenta;
            tsbEliminar.Name = "tsbEliminar";
            tsbEliminar.Size = new Size(23, 22);
            tsbEliminar.Text = "Eliminar";
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStripContainer1);
            Name = "Usuarios";
            Text = "Usuarios";
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            tlAlumnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tsUsuarios.ResumeLayout(false);
            tsUsuarios.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private ToolStrip tsUsuarios;
        private TableLayoutPanel tlAlumnos;
        private DataGridView dgvUsuarios;
        private Button btnActualizar;
        private Button btnSalir;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbEditar;
        private ToolStripButton tsbEliminar;
    }
}
