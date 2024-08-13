using System.Windows.Forms;

namespace AcademiaABM.Presentacion.Principal
{
    partial class Grilla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grilla));
            toolStripContainer1 = new ToolStripContainer();
            tlSysacad = new TableLayoutPanel();
            dgvSysacad = new DataGridView();
            btnMostrarPersonas = new Button();
            btnMostrarComisiones = new Button();
            btnSalir = new Button();
            btnActualizar = new Button();
            btnMostrarCursos = new Button();
            tsSysacad = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbEliminar = new ToolStripButton();
            tsbOrdenarAscendente = new ToolStripButton();
            tsbOrdenarDescendente = new ToolStripButton();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            tlSysacad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSysacad).BeginInit();
            tsSysacad.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(tlSysacad);
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
            toolStripContainer1.TopToolStripPanel.Controls.Add(tsSysacad);
            // 
            // tlSysacad
            // 
            tlSysacad.ColumnCount = 6;
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle());
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 87F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 365F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 86F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 89F));
            tlSysacad.Controls.Add(dgvSysacad, 0, 0);
            tlSysacad.Controls.Add(btnMostrarPersonas, 0, 1);
            tlSysacad.Controls.Add(btnMostrarComisiones, 1, 1);
            tlSysacad.Controls.Add(btnSalir, 5, 1);
            tlSysacad.Controls.Add(btnActualizar, 4, 1);
            tlSysacad.Controls.Add(btnMostrarCursos, 2, 1);
            tlSysacad.Dock = DockStyle.Fill;
            tlSysacad.Location = new Point(0, 0);
            tlSysacad.Name = "tlSysacad";
            tlSysacad.RowCount = 2;
            tlSysacad.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlSysacad.RowStyles.Add(new RowStyle());
            tlSysacad.Size = new Size(800, 425);
            tlSysacad.TabIndex = 0;
            // 
            // dgvSysacad
            // 
            dgvSysacad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSysacad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlSysacad.SetColumnSpan(dgvSysacad, 6);
            dgvSysacad.Dock = DockStyle.Fill;
            dgvSysacad.Location = new Point(3, 3);
            dgvSysacad.Name = "dgvSysacad";
            dgvSysacad.Size = new Size(794, 390);
            dgvSysacad.TabIndex = 0;
            dgvSysacad.SelectionChanged += dgvSysacad_SelectionChanged;
            // 
            // btnMostrarPersonas
            // 
            btnMostrarPersonas.Location = new Point(3, 399);
            btnMostrarPersonas.Name = "btnMostrarPersonas";
            btnMostrarPersonas.Size = new Size(80, 23);
            btnMostrarPersonas.TabIndex = 3;
            btnMostrarPersonas.Text = "Personas";
            btnMostrarPersonas.UseVisualStyleBackColor = true;
            btnMostrarPersonas.Click += btnMostrarPersonas_Click;
            // 
            // btnMostrarComisiones
            // 
            btnMostrarComisiones.Anchor = AnchorStyles.Left;
            btnMostrarComisiones.Location = new Point(90, 399);
            btnMostrarComisiones.Name = "btnMostrarComisiones";
            btnMostrarComisiones.Size = new Size(80, 23);
            btnMostrarComisiones.TabIndex = 4;
            btnMostrarComisiones.Text = "Comisiones";
            btnMostrarComisiones.UseVisualStyleBackColor = true;
            btnMostrarComisiones.Click += btnMostrarComisiones_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.Location = new Point(717, 399);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(80, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(628, 399);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(80, 23);
            btnActualizar.TabIndex = 1;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnMostrarCursos
            // 
            btnMostrarCursos.Anchor = AnchorStyles.Left;
            btnMostrarCursos.Location = new Point(176, 399);
            btnMostrarCursos.Name = "btnMostrarCursos";
            btnMostrarCursos.Size = new Size(80, 23);
            btnMostrarCursos.TabIndex = 5;
            btnMostrarCursos.Text = "Cursos";
            btnMostrarCursos.UseVisualStyleBackColor = true;
            btnMostrarCursos.Click += btnMostrarCursos_Click;
            // 
            // tsSysacad
            // 
            tsSysacad.Dock = DockStyle.None;
            tsSysacad.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbEditar, tsbEliminar, tsbOrdenarAscendente, tsbOrdenarDescendente });
            tsSysacad.Location = new Point(3, 0);
            tsSysacad.Name = "tsSysacad";
            tsSysacad.Size = new Size(127, 25);
            tsSysacad.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNuevo.Image = (Image)resources.GetObject("tsbNuevo.Image");
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(23, 22);
            tsbNuevo.Text = "Nuevo";
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEditar.Image = (Image)resources.GetObject("tsbEditar.Image");
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(23, 22);
            tsbEditar.Text = "Editar";
            tsbEditar.Click += tsbEditar_Click;
            // 
            // tsbEliminar
            // 
            tsbEliminar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEliminar.Image = (Image)resources.GetObject("tsbEliminar.Image");
            tsbEliminar.ImageTransparentColor = Color.Magenta;
            tsbEliminar.Name = "tsbEliminar";
            tsbEliminar.Size = new Size(23, 22);
            tsbEliminar.Text = "Eliminar";
            tsbEliminar.Click += tsbEliminar_Click;
            // 
            // tsbOrdenarAscendente
            // 
            tsbOrdenarAscendente.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbOrdenarAscendente.Image = (Image)resources.GetObject("tsbOrdenarAscendente.Image");
            tsbOrdenarAscendente.ImageTransparentColor = Color.Magenta;
            tsbOrdenarAscendente.Name = "tsbOrdenarAscendente";
            tsbOrdenarAscendente.Size = new Size(23, 22);
            tsbOrdenarAscendente.Text = "OrdenarAscendente";
            tsbOrdenarAscendente.Click += tsbOrdenarAscendente_Click;
            // 
            // tsbOrdenarDescendente
            // 
            tsbOrdenarDescendente.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbOrdenarDescendente.Image = (Image)resources.GetObject("tsbOrdenarDescendente.Image");
            tsbOrdenarDescendente.ImageTransparentColor = Color.Magenta;
            tsbOrdenarDescendente.Name = "tsbOrdenarDescendente";
            tsbOrdenarDescendente.Size = new Size(23, 22);
            tsbOrdenarDescendente.Text = "OrdenarDescendente";
            tsbOrdenarDescendente.Click += tsbOrdenarDescendente_Click;
            // 
            // Grilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStripContainer1);
            Name = "Grilla";
            Text = "Grilla";
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            tlSysacad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSysacad).EndInit();
            tsSysacad.ResumeLayout(false);
            tsSysacad.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private ToolStrip tsSysacad;
        private TableLayoutPanel tlSysacad;
        private DataGridView dgvSysacad;
        private Button btnActualizar;
        private Button btnSalir;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbEditar;
        private ToolStripButton tsbEliminar;
        private ToolStripButton tsbOrdenarAscendente;
        private ToolStripButton tsbOrdenarDescendente;
        private Button btnMostrarPersonas;
        private Button btnMostrarComisiones;
        private Button btnMostrarCursos;
    }
}
