namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class CursoUI : Form
    {
        public Curso Curso { get; set; }

        private List<(int Id, string Descripcion)> Comisiones;
        private List<(int Id, string Descripcion)> Materias;

        private bool _suspendComboBoxEvent = false;

        public CursoUI(List<(int Id, string Descripcion)> comisiones)
        {
            InitializeComponent();

            TituloLabel.Text = "Nuevo Curso";
            GuardarButton.Text = "Crear";

            this.Comisiones = comisiones;

            ComisionComboBox.DataSource = ListadoNombresComisiones();

            this.Curso = new Curso();

            Curso.Id_comision = ObtenerIdComisionSeleccionada();

            ComisionComboBox.SelectedIndexChanged += ComisionComboBox_SelectedIndexChanged;

            this.Load += async (sender, e) => await CargarMateriasAsync();
        }

        public CursoUI(List<(int Id, string Descripcion)> comisiones, List<(int Id, string Descripcion)> materias, Curso cursoAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Curso";
            GuardarButton.Text = "Modificar";

            this.Comisiones = comisiones;
            this.Materias = materias;
            
            this.Curso = cursoAModificar;

            ComisionComboBox.Enabled = false;
            MateriaComboBox.Enabled = false;

            AnioCalendarioTextBox.Text = cursoAModificar.Anio_calendario.ToString();
            AnioCalendarioTextBox.BackColor = Color.WhiteSmoke;
            AnioCalendarioTextBox.Enabled = false;

            CupoTextBox.Text = cursoAModificar.Cupo.ToString();

            ComisionComboBox.DataSource = ListadoNombresComisiones();

            foreach (var comision in this.Comisiones)
            {
                if (comision.Id == cursoAModificar.Id_comision)
                {
                    ComisionComboBox.SelectedItem = comision.Descripcion;
                }
            }
            
            MateriaComboBox.DataSource = ListadoNombresMateriasModificacion();

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
            if (ValidarDatosIngresados())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    CursoDTO cursoModificado = EstablecerDatosCursoAModificar();

                    var response = await CursoNegocio.Update(Curso.Id_curso, cursoModificado);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    Curso nuevoCurso = EstablecerDatosNuevoCurso();

                    var response = await CursoNegocio.Add(nuevoCurso);

                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                }
            }
        }

        private bool ValidarDatosIngresados()
        {
            if (int.TryParse(AnioCalendarioTextBox.Text, out int anio))
            {
                int anioActual = DateTime.Now.Year;

                if (anio != anioActual && anio != (anioActual + 1))
                {
                    MessageBox.Show($"El año debe corresponder al actual o al siguiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"El año debe corresponder al actual o al siguiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }

            if (int.TryParse(CupoTextBox.Text, out int cupo))
            {
                if (cupo < 1 || cupo > 100)
                {
                    MessageBox.Show($"El cupo debe ser un número entre 1 y 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show($"El cupo debe ser un número entre 1 y 100", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }
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
            List<string> listadoNombresComisiones = this.Comisiones.Select(comision => comision.Descripcion).ToList();

            listadoNombresComisiones.Sort();

            return listadoNombresComisiones;
        }

        private async Task CargarMateriasAsync()
        {
            MateriaComboBox.DataSource = await ListadoNombresMateriasCreacion();
        }

        private async Task<List<string>> ListadoNombresMateriasCreacion()
        {
            var materias_comision_plan = (List<Materia>) await MateriaNegocio.GetMateriasParaComision(Curso.Id_comision.ToString());

            this.Materias = materias_comision_plan.Select(materia => (materia.Id_materia, materia.Desc_materia)).ToList();

            if (materias_comision_plan.Any())
            {
                materias_comision_plan = materias_comision_plan.OrderBy(mat => mat.Desc_materia).ToList();
            }

            return materias_comision_plan.Select(materia => (materia.Desc_materia)).ToList();
        }

        private List<string> ListadoNombresMateriasModificacion()
        {
            List<string> listadoNombresMaterias = this.Materias.Select(materia => materia.Descripcion).ToList();

            listadoNombresMaterias.Sort();

            return listadoNombresMaterias;
        }

        private async void ComisionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suspendComboBoxEvent) return;

            _suspendComboBoxEvent = true;

            Curso.Id_comision = ObtenerIdComisionSeleccionada();

            MateriaComboBox.DataSource = await ListadoNombresMateriasCreacion();

            _suspendComboBoxEvent = false;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}