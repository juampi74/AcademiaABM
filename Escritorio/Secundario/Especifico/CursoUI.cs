namespace Escritorio
{
    using Entidades;
    using Negocio;

    public partial class CursoUI : Form
    {
        public Curso Curso { get; set; }

        private List<(int Id, string Descripcion)> Comisiones;
        private List<(int Id, string Descripcion)> Materias;

        public CursoUI(List<(int Id, string Descripcion)> comisiones, List<(int Id, string Descripcion)> materias)
        {
            InitializeComponent();

            TituloLabel.Text = "Nuevo Curso";
            GuardarButton.Text = "Crear";

            this.Comisiones = comisiones;
            this.Materias = materias;

            List<string> listadoComisiones = ListadoNombresComisiones();
            List<string> listadoMaterias = ListadoNombresMaterias();

            ComisionComboBox.DataSource = listadoComisiones;
            MateriaComboBox.DataSource = listadoMaterias;
        }

        public CursoUI(List<(int Id, string Descripcion)> comisiones, List<(int Id, string Descripcion)> materias, Curso cursoAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Curso";
            GuardarButton.Text = "Modificar";

            this.Comisiones = comisiones;
            this.Materias = materias;
            
            this.Curso = cursoAModificar;

            AnioCalendarioTextBox.Text = cursoAModificar.Anio_calendario.ToString();
            CupoTextBox.Text = cursoAModificar.Cupo.ToString();

            ComisionComboBox.DataSource = ListadoNombresComisiones();

            foreach (var comision in this.Comisiones)
            {
                if (comision.Id == cursoAModificar.Id_comision)
                {
                    ComisionComboBox.SelectedItem = comision.Descripcion;
                }
            }
            
            MateriaComboBox.DataSource = ListadoNombresMaterias();

            foreach (var materia in this.Materias)
            {
                if (materia.Id == cursoAModificar.Id_materia)
                {
                    MateriaComboBox.SelectedItem = materia.Descripcion;
                }
            }
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    CursoDTO cursoModificado = EstablecerDatosCursoAModificar();

                    await CursoNegocio.Update(Curso.Id_curso, cursoModificado);
                }
                else
                {
                    Curso nuevoCurso = EstablecerDatosNuevoCurso();

                    await CursoNegocio.Add(nuevoCurso);
                }

                DialogResult = DialogResult.OK;
            }
        }

        private bool ComprobarCamposRequeridos()
        {
            foreach (Control control in this.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        CampoRequerido campoRequerido = new CampoRequerido();
                        campoRequerido.CampoRequeridoLabel.Text = campoRequerido.CampoRequeridoLabel.Text.Replace("${campo}", textBox.Name.Replace("TextBox", ""));
                        campoRequerido.ShowDialog(this);

                        DialogResult = DialogResult.None;
                        return false;
                    }
                }
            }

            return true;

        }

        private CursoDTO EstablecerDatosCursoAModificar()
        {
            int idComisionSeleccionada = ObtenerIdComisionSeleccionada();
            int idMateriaSeleccionada = ObtenerIdMateriaSeleccionada();

            CursoDTO curso = new CursoDTO();

            curso.Anio_calendario = Int32.Parse(AnioCalendarioTextBox.Text);
            curso.Cupo = Int32.Parse(CupoTextBox.Text);
            curso.Id_comision = idComisionSeleccionada;
            curso.Id_materia = idMateriaSeleccionada;

            return curso;
        }

        private Curso EstablecerDatosNuevoCurso()
        {
            int idComisionSeleccionada = ObtenerIdComisionSeleccionada();
            int idMateriaSeleccionada = ObtenerIdMateriaSeleccionada();

            Curso curso = new Curso(Int32.Parse(AnioCalendarioTextBox.Text), Int32.Parse(CupoTextBox.Text), idComisionSeleccionada, idMateriaSeleccionada);

            return curso;
        }

        private int ObtenerIdComisionSeleccionada()
        {
            int idComisionSeleccionada = 0;

            // Buscar el Id de la Comision que coincida con la Descripcion seleccionada
            foreach (var comision in this.Comisiones)
            {
                if (comision.Descripcion == ComisionComboBox.SelectedValue.ToString())
                {
                    idComisionSeleccionada = comision.Id;
                }
            }

            return idComisionSeleccionada;
        }

        private int ObtenerIdMateriaSeleccionada()
        {
            int idMateriaSeleccionada = 0;

            // Buscar el Id de la Materia que coincida con la Descripcion seleccionada
            foreach (var materia in this.Materias)
            {
                if (materia.Descripcion == MateriaComboBox.SelectedValue.ToString())
                {
                    idMateriaSeleccionada = materia.Id;
                }
            }

            return idMateriaSeleccionada;
        }

        private List<string> ListadoNombresComisiones()
        {
            // Obtener solo los nombres de las comisiones
            List<string> listadoNombresComisiones = this.Comisiones.Select(comision => comision.Descripcion).ToList();

            // Ordenar la lista de nombres de las comisiones según su descripción
            listadoNombresComisiones.Sort();

            return listadoNombresComisiones;
        }
        
        private List<string> ListadoNombresMaterias()
        {
            // Obtener solo los nombres de las materias
            List<string> listadoNombresMaterias = this.Materias.Select(materia => materia.Descripcion).ToList();

            // Ordenar la lista de nombres de las materias según su descripción
            listadoNombresMaterias.Sort();

            return listadoNombresMaterias;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}