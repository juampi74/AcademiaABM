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
            fLPBotonesOpciones = new FlowLayoutPanel();
            btnMostrarPersonas = new Button();
            btnMostrarComisiones = new Button();
            btnMostrarCursos = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnActualizar = new Button();
            btnSalir = new Button();
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
            fLPBotonesOpciones.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tsSysacad.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(tlSysacad);
            toolStripContainer1.ContentPanel.Margin = new Padding(3, 4, 3, 4);
            toolStripContainer1.ContentPanel.Size = new Size(914, 573);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Margin = new Padding(3, 4, 3, 4);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.Size = new Size(914, 600);
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
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 11F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 203F));
            tlSysacad.Controls.Add(dgvSysacad, 0, 0);
            tlSysacad.Controls.Add(fLPBotonesOpciones, 0, 1);
            tlSysacad.Controls.Add(flowLayoutPanel1, 5, 1);
            tlSysacad.Dock = DockStyle.Fill;
            tlSysacad.Location = new Point(0, 0);
            tlSysacad.Margin = new Padding(3, 4, 3, 4);
            tlSysacad.Name = "tlSysacad";
            tlSysacad.RowCount = 2;
            tlSysacad.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlSysacad.RowStyles.Add(new RowStyle());
            tlSysacad.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlSysacad.Size = new Size(914, 573);
            tlSysacad.TabIndex = 0;
            // 
            // dgvSysacad
            // 
            dgvSysacad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSysacad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlSysacad.SetColumnSpan(dgvSysacad, 6);
            dgvSysacad.Dock = DockStyle.Fill;
            dgvSysacad.Location = new Point(3, 4);
            dgvSysacad.Margin = new Padding(3, 4, 3, 4);
            dgvSysacad.Name = "dgvSysacad";
            dgvSysacad.RowHeadersWidth = 51;
            dgvSysacad.Size = new Size(908, 517);
            dgvSysacad.TabIndex = 0;
            dgvSysacad.SelectionChanged += dgvSysacad_SelectionChanged;
            // 
            // fLPBotonesOpciones
            // 
            fLPBotonesOpciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fLPBotonesOpciones.Controls.Add(btnMostrarPersonas);
            fLPBotonesOpciones.Controls.Add(btnMostrarComisiones);
            fLPBotonesOpciones.Controls.Add(btnMostrarCursos);
            fLPBotonesOpciones.Location = new Point(3, 530);
            fLPBotonesOpciones.Margin = new Padding(3, 4, 3, 4);
            fLPBotonesOpciones.Name = "fLPBotonesOpciones";
            fLPBotonesOpciones.Size = new Size(295, 39);
            fLPBotonesOpciones.TabIndex = 5;
            // 
            // btnMostrarPersonas
            // 
            btnMostrarPersonas.Location = new Point(3, 4);
            btnMostrarPersonas.Margin = new Padding(3, 4, 3, 4);
            btnMostrarPersonas.Name = "btnMostrarPersonas";
            btnMostrarPersonas.Size = new Size(91, 31);
            btnMostrarPersonas.TabIndex = 0;
            btnMostrarPersonas.Text = "Personas";
            btnMostrarPersonas.UseVisualStyleBackColor = true;
            btnMostrarPersonas.Click += btnMostrarPersonas_Click;
            // 
            // btnMostrarComisiones
            // 
            btnMostrarComisiones.Location = new Point(100, 4);
            btnMostrarComisiones.Margin = new Padding(3, 4, 3, 4);
            btnMostrarComisiones.Name = "btnMostrarComisiones";
            btnMostrarComisiones.Size = new Size(101, 31);
            btnMostrarComisiones.TabIndex = 1;
            btnMostrarComisiones.Text = "Comisiones";
            btnMostrarComisiones.UseVisualStyleBackColor = true;
            btnMostrarComisiones.Click += btnMostrarComisiones_Click;
            // 
            // btnMostrarCursos
            // 
            btnMostrarCursos.Location = new Point(207, 4);
            btnMostrarCursos.Margin = new Padding(3, 4, 3, 4);
            btnMostrarCursos.Name = "btnMostrarCursos";
            btnMostrarCursos.Size = new Size(75, 31);
            btnMostrarCursos.TabIndex = 2;
            btnMostrarCursos.Text = "Cursos";
            btnMostrarCursos.UseVisualStyleBackColor = true;
            btnMostrarCursos.Click += btnMostrarCursos_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnActualizar);
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(714, 529);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(197, 40);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // btnActualizar
            // 
            btnActualizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnActualizar.Location = new Point(3, 4);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(91, 31);
            btnActualizar.TabIndex = 3;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.Location = new Point(100, 4);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(91, 31);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // tsSysacad
            // 
            tsSysacad.Dock = DockStyle.None;
            tsSysacad.ImageScalingSize = new Size(20, 20);
            tsSysacad.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbEditar, tsbEliminar, tsbOrdenarAscendente, tsbOrdenarDescendente });
            tsSysacad.Location = new Point(4, 0);
            tsSysacad.Name = "tsSysacad";
            tsSysacad.Size = new Size(158, 27);
            tsSysacad.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNuevo.Image = (Image)resources.GetObject("tsbNuevo.Image");
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(29, 24);
            tsbNuevo.Text = "Nuevo";
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEditar.Image = (Image)resources.GetObject("tsbEditar.Image");
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(29, 24);
            tsbEditar.Text = "Editar";
            tsbEditar.Click += tsbEditar_Click;
            // 
            // tsbEliminar
            // 
            tsbEliminar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEliminar.Image = (Image)resources.GetObject("tsbEliminar.Image");
            tsbEliminar.ImageTransparentColor = Color.Magenta;
            tsbEliminar.Name = "tsbEliminar";
            tsbEliminar.Size = new Size(29, 24);
            tsbEliminar.Text = "Eliminar";
            tsbEliminar.Click += tsbEliminar_Click;
            // 
            // tsbOrdenarAscendente
            // 
            tsbOrdenarAscendente.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbOrdenarAscendente.Image = (Image)resources.GetObject("tsbOrdenarAscendente.Image");
            tsbOrdenarAscendente.ImageTransparentColor = Color.Magenta;
            tsbOrdenarAscendente.Name = "tsbOrdenarAscendente";
            tsbOrdenarAscendente.Size = new Size(29, 24);
            tsbOrdenarAscendente.Text = "OrdenarAscendente";
            tsbOrdenarAscendente.Click += tsbOrdenarAscendente_Click;
            // 
            // tsbOrdenarDescendente
            // 
            tsbOrdenarDescendente.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbOrdenarDescendente.Image = (Image)resources.GetObject("tsbOrdenarDescendente.Image");
            tsbOrdenarDescendente.ImageTransparentColor = Color.Magenta;
            tsbOrdenarDescendente.Name = "tsbOrdenarDescendente";
            tsbOrdenarDescendente.Size = new Size(29, 24);
            tsbOrdenarDescendente.Text = "OrdenarDescendente";
            tsbOrdenarDescendente.Click += tsbOrdenarDescendente_Click;
            // 
            // Grilla
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(toolStripContainer1);
            Margin = new Padding(3, 4, 3, 4);
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
            flowLayoutPanel1.ResumeLayout(false);
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

