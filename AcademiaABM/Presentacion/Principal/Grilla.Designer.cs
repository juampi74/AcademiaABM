﻿namespace AcademiaABM.Presentacion.Principal
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
            btnSalir = new Button();
            btnActualizar = new Button();
            fLPBotonesOpciones = new FlowLayoutPanel();
            btnMostrarPersonas = new Button();
            btnMostrarComisiones = new Button();
            btnMostrarCursos = new Button();
            tsSysacad = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbEliminar = new ToolStripButton();
            tsbOrdenarAscendente = new ToolStripButton();
            tsbOrdenarDescendente = new ToolStripButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            tlSysacad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSysacad).BeginInit();
            fLPBotonesOpciones.SuspendLayout();
            tsSysacad.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
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
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 9F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 178F));
            tlSysacad.Controls.Add(dgvSysacad, 0, 0);
            tlSysacad.Controls.Add(fLPBotonesOpciones, 0, 1);
            tlSysacad.Controls.Add(flowLayoutPanel1, 5, 1);
            tlSysacad.Dock = DockStyle.Fill;
            tlSysacad.Location = new Point(0, 0);
            tlSysacad.Name = "tlSysacad";
            tlSysacad.RowCount = 2;
            tlSysacad.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlSysacad.RowStyles.Add(new RowStyle());
            tlSysacad.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
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
            dgvSysacad.Size = new Size(794, 383);
            dgvSysacad.TabIndex = 0;
            dgvSysacad.SelectionChanged += dgvSysacad_SelectionChanged;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.Location = new Point(89, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(80, 23);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(3, 3);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(80, 23);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // fLPBotonesOpciones
            // 
            fLPBotonesOpciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fLPBotonesOpciones.Controls.Add(btnMostrarPersonas);
            fLPBotonesOpciones.Controls.Add(btnMostrarComisiones);
            fLPBotonesOpciones.Controls.Add(btnMostrarCursos);
            fLPBotonesOpciones.Location = new Point(3, 393);
            fLPBotonesOpciones.Name = "fLPBotonesOpciones";
            fLPBotonesOpciones.Size = new Size(258, 29);
            fLPBotonesOpciones.TabIndex = 5;
            // 
            // btnMostrarPersonas
            // 
            btnMostrarPersonas.Location = new Point(3, 3);
            btnMostrarPersonas.Name = "btnMostrarPersonas";
            btnMostrarPersonas.Size = new Size(80, 23);
            btnMostrarPersonas.TabIndex = 0;
            btnMostrarPersonas.Text = "Personas";
            btnMostrarPersonas.UseVisualStyleBackColor = true;
            btnMostrarPersonas.Click += btnMostrarPersonas_Click;
            // 
            // btnMostrarComisiones
            // 
            btnMostrarComisiones.Location = new Point(89, 3);
            btnMostrarComisiones.Name = "btnMostrarComisiones";
            btnMostrarComisiones.Size = new Size(80, 23);
            btnMostrarComisiones.TabIndex = 1;
            btnMostrarComisiones.Text = "Comisiones";
            btnMostrarComisiones.UseVisualStyleBackColor = true;
            btnMostrarComisiones.Click += btnMostrarComisiones_Click;
            // 
            // btnMostrarCursos
            // 
            btnMostrarCursos.Location = new Point(175, 3);
            btnMostrarCursos.Name = "btnMostrarCursos";
            btnMostrarCursos.Size = new Size(80, 23);
            btnMostrarCursos.TabIndex = 2;
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
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnActualizar);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(625, 392);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(172, 30);
            flowLayoutPanel1.TabIndex = 6;
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
            fLPBotonesOpciones.ResumeLayout(false);
            tsSysacad.ResumeLayout(false);
            tsSysacad.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ToolStripContainer toolStripContainer1;
        private ToolStrip tsSysacad;
        private TableLayoutPanel tlSysacad;
        private DataGridView dgvSysacad;
        private Button btnActualizar;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbEditar;
        private ToolStripButton tsbEliminar;
        private ToolStripButton tsbOrdenarAscendente;
        private ToolStripButton tsbOrdenarDescendente;
        private Button btnMostrarPersonas;
        private Button btnMostrarComisiones;
        private Button btnMostrarCursos;
        private Button btnSalir;
        private FlowLayoutPanel fLPBotonesOpciones;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
