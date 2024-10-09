namespace Escritorio
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
            btnMostrarEspecialidades = new Button();
            btnMostrarMaterias = new Button();
            btnMostrarPlanes = new Button();
            btnMostrarUsuarios = new Button();
            btnMostrarDictados = new Button();
            btnMostrarInscripciones = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSalir = new Button();
            tsSysacad = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tsbEliminar = new ToolStripButton();
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
            toolStripContainer1.ContentPanel.Size = new Size(800, 423);
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
            tlSysacad.ColumnCount = 2;
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle());
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 545F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 207F));
            tlSysacad.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 178F));
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
            tlSysacad.Size = new Size(800, 423);
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
            dgvSysacad.RowHeadersWidth = 51;
            dgvSysacad.Size = new Size(794, 381);
            dgvSysacad.TabIndex = 0;
            // 
            // fLPBotonesOpciones
            // 
            fLPBotonesOpciones.Controls.Add(btnMostrarComisiones);
            fLPBotonesOpciones.Controls.Add(btnMostrarCursos);
            fLPBotonesOpciones.Controls.Add(btnMostrarDictados);
            fLPBotonesOpciones.Controls.Add(btnMostrarEspecialidades);
            fLPBotonesOpciones.Controls.Add(btnMostrarInscripciones);
            fLPBotonesOpciones.Controls.Add(btnMostrarMaterias);
            fLPBotonesOpciones.Controls.Add(btnMostrarPersonas);
            fLPBotonesOpciones.Controls.Add(btnMostrarPlanes);
            fLPBotonesOpciones.Controls.Add(btnMostrarUsuarios);
            fLPBotonesOpciones.Location = new Point(3, 390);
            fLPBotonesOpciones.Name = "fLPBotonesOpciones";
            fLPBotonesOpciones.Size = new Size(672, 29);
            fLPBotonesOpciones.TabIndex = 5;
            // 
            // btnMostrarPersonas
            // 
            btnMostrarPersonas.Location = new Point(482, 3);
            btnMostrarPersonas.Name = "btnMostrarPersonas";
            btnMostrarPersonas.Size = new Size(62, 23);
            btnMostrarPersonas.TabIndex = 0;
            btnMostrarPersonas.Text = "Personas";
            btnMostrarPersonas.UseVisualStyleBackColor = true;
            btnMostrarPersonas.Click += btnMostrarPersonas_Click;
            // 
            // btnMostrarComisiones
            // 
            btnMostrarComisiones.Location = new Point(3, 3);
            btnMostrarComisiones.Name = "btnMostrarComisiones";
            btnMostrarComisiones.Size = new Size(77, 23);
            btnMostrarComisiones.TabIndex = 1;
            btnMostrarComisiones.Text = "Comisiones";
            btnMostrarComisiones.UseVisualStyleBackColor = true;
            btnMostrarComisiones.Click += btnMostrarComisiones_Click;
            // 
            // btnMostrarCursos
            // 
            btnMostrarCursos.Location = new Point(86, 3);
            btnMostrarCursos.Name = "btnMostrarCursos";
            btnMostrarCursos.Size = new Size(54, 23);
            btnMostrarCursos.TabIndex = 2;
            btnMostrarCursos.Text = "Cursos";
            btnMostrarCursos.UseVisualStyleBackColor = true;
            btnMostrarCursos.Click += btnMostrarCursos_Click;
            // 
            // btnMostrarEspecialidades
            // 
            btnMostrarEspecialidades.Location = new Point(214, 3);
            btnMostrarEspecialidades.Name = "btnMostrarEspecialidades";
            btnMostrarEspecialidades.Size = new Size(95, 23);
            btnMostrarEspecialidades.TabIndex = 3;
            btnMostrarEspecialidades.Text = "Especialidades";
            btnMostrarEspecialidades.UseVisualStyleBackColor = true;
            btnMostrarEspecialidades.Click += btnMostrarEspecialidades_Click;
            // 
            // btnMostrarMaterias
            // 
            btnMostrarMaterias.Location = new Point(408, 3);
            btnMostrarMaterias.Name = "btnMostrarMaterias";
            btnMostrarMaterias.Size = new Size(68, 23);
            btnMostrarMaterias.TabIndex = 5;
            btnMostrarMaterias.Text = "Materias";
            btnMostrarMaterias.UseVisualStyleBackColor = true;
            btnMostrarMaterias.Click += btnMostrarMaterias_Click;
            // 
            // btnMostrarPlanes
            // 
            btnMostrarPlanes.Location = new Point(550, 3);
            btnMostrarPlanes.Name = "btnMostrarPlanes";
            btnMostrarPlanes.Size = new Size(53, 23);
            btnMostrarPlanes.TabIndex = 4;
            btnMostrarPlanes.Text = "Planes";
            btnMostrarPlanes.UseVisualStyleBackColor = true;
            btnMostrarPlanes.Click += btnMostrarPlanes_Click;
            // 
            // btnMostrarUsuarios
            // 
            btnMostrarUsuarios.Location = new Point(609, 3);
            btnMostrarUsuarios.Name = "btnMostrarUsuarios";
            btnMostrarUsuarios.Size = new Size(60, 23);
            btnMostrarUsuarios.TabIndex = 6;
            btnMostrarUsuarios.Text = "Usuarios";
            btnMostrarUsuarios.UseVisualStyleBackColor = true;
            btnMostrarUsuarios.Click += btnMostrarUsuarios_Click;
            // 
            // btnMostrarDictados
            // 
            btnMostrarDictados.Location = new Point(146, 3);
            btnMostrarDictados.Name = "btnMostrarDictados";
            btnMostrarDictados.Size = new Size(62, 23);
            btnMostrarDictados.TabIndex = 7;
            btnMostrarDictados.Text = "Dictados";
            btnMostrarDictados.UseVisualStyleBackColor = true;
            btnMostrarDictados.Click += btnMostrarDictados_Click;
            // 
            // btnMostrarInscripciones
            // 
            btnMostrarInscripciones.Location = new Point(315, 3);
            btnMostrarInscripciones.Name = "btnMostrarInscripciones";
            btnMostrarInscripciones.Size = new Size(87, 23);
            btnMostrarInscripciones.TabIndex = 8;
            btnMostrarInscripciones.Text = "Inscripciones";
            btnMostrarInscripciones.UseVisualStyleBackColor = true;
            btnMostrarInscripciones.Click += btnMostrarInscripciones_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(btnSalir);
            flowLayoutPanel1.Location = new Point(731, 390);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(66, 30);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.Location = new Point(3, 3);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(59, 23);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // tsSysacad
            // 
            tsSysacad.Dock = DockStyle.None;
            tsSysacad.ImageScalingSize = new Size(20, 20);
            tsSysacad.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbEditar, tsbEliminar });
            tsSysacad.Location = new Point(4, 0);
            tsSysacad.Name = "tsSysacad";
            tsSysacad.Size = new Size(84, 27);
            tsSysacad.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            tsbNuevo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbNuevo.Image = (Image)resources.GetObject("tsbNuevo.Image");
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(24, 24);
            tsbNuevo.Text = "Nuevo";
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEditar.Image = (Image)resources.GetObject("tsbEditar.Image");
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(24, 24);
            tsbEditar.Text = "Editar";
            tsbEditar.Click += tsbEditar_Click;
            // 
            // tsbEliminar
            // 
            tsbEliminar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEliminar.Image = (Image)resources.GetObject("tsbEliminar.Image");
            tsbEliminar.ImageTransparentColor = Color.Magenta;
            tsbEliminar.Name = "tsbEliminar";
            tsbEliminar.Size = new Size(24, 24);
            tsbEliminar.Text = "Eliminar";
            tsbEliminar.Click += tsbEliminar_Click;
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
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbEditar;
        private ToolStripButton tsbEliminar;
        private Button btnMostrarPersonas;
        private Button btnMostrarComisiones;
        private Button btnMostrarCursos;
        private Button btnMostrarDictados;
        private Button btnMostrarEspecialidades;
        private Button btnMostrarInscripciones;
        private Button btnMostrarMaterias;
        private Button btnMostrarPlanes;
        private Button btnMostrarUsuarios;
        private Button btnSalir;
        private FlowLayoutPanel fLPBotonesOpciones;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}

