namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class DictadoUI : Form
    {
        public Docente_Curso Dictado { get; set; }

        private List<(int Id, string ApellidoYNombre)> Docentes;
        private List<(int Id, string MateriaYComision)> Cursos;

        public DictadoUI(List<(int Id, string ApellidoYNombre)> docentes, List<(int Id, string MateriaYComision)> cursos)
        {
            InitializeComponent();

            TituloLabel.Text = "Nuevo Dictado";
            GuardarButton.Text = "Crear";

            this.Docentes = docentes;
            this.Cursos = cursos;
            
            DocenteComboBox.DataSource = ListadoNombresDocentes();
            CursoComboBox.DataSource = ListadoNombresCursos();
        }

        public DictadoUI(List<(int Id, string ApellidoYNombre)> docentes, List<(int Id, string MateriaYComision)> cursos, Docente_Curso dictadoAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Dictado";
            GuardarButton.Text = "Modificar";

            this.Docentes = docentes;
            this.Cursos = cursos;

            this.Dictado = dictadoAModificar;

            CargoTextBox.Text = dictadoAModificar.Cargo;

            DocenteComboBox.DataSource = ListadoNombresDocentes();

            foreach (var docente in this.Docentes)
            {
                if (docente.Id == dictadoAModificar.Id_docente)
                {
                    DocenteComboBox.SelectedItem = docente.ApellidoYNombre;
                }
            }

            CursoComboBox.DataSource = ListadoNombresCursos();
            
            foreach (var curso in this.Cursos)
            {
                if (curso.Id == dictadoAModificar.Id_curso)
                {
                    CursoComboBox.SelectedItem = curso.MateriaYComision;
                }
            }      
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatosIngresados())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    Docente_CursoDTO dictadoModificado = EstablecerDatosDictadoAModificar();

                    var response = await DictadoNegocio.Update(Dictado.Id_dictado, dictadoModificado);

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
                    Docente_Curso nuevoDictado = EstablecerDatosNuevoDictado();

                    var response = await DictadoNegocio.Add(nuevoDictado);

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
            if (CargoTextBox.Text.Length < 10)
            {
                MessageBox.Show($"El cargo debe tener más de 10 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }

            return true;
        }

        private Docente_CursoDTO EstablecerDatosDictadoAModificar()
        {
            int idDocenteSeleccionado = ObtenerIdDocenteSeleccionado();
            int idCursoSeleccionado = ObtenerIdCursoSeleccionado();

            Docente_CursoDTO dictado = new Docente_CursoDTO();

            dictado.Cargo = CargoTextBox.Text;
            dictado.Id_docente = idDocenteSeleccionado;
            dictado.Id_curso = idCursoSeleccionado;

            return dictado;
        }

        private Docente_Curso EstablecerDatosNuevoDictado()
        {
            int idDocenteSeleccionado = ObtenerIdDocenteSeleccionado();
            int idCursoSeleccionado = ObtenerIdCursoSeleccionado();

            Docente_Curso dictado = new Docente_Curso(CargoTextBox.Text, idDocenteSeleccionado, idCursoSeleccionado);

            return dictado;
        }

        private int ObtenerIdDocenteSeleccionado()
        {
            int idDocenteSeleccionado = 0;

            foreach (var docente in this.Docentes)
            {
                if (docente.ApellidoYNombre == DocenteComboBox.SelectedValue.ToString())
                {
                    idDocenteSeleccionado = docente.Id;
                }
            }

            return idDocenteSeleccionado;
        }

        private int ObtenerIdCursoSeleccionado()
        {
            int idCursoSeleccionado = 0;

            foreach (var curso in this.Cursos)
            {
                if (curso.MateriaYComision == CursoComboBox.SelectedValue.ToString())
                {
                    idCursoSeleccionado = curso.Id;
                }
            }

            return idCursoSeleccionado;
        }

        private List<string> ListadoNombresDocentes()
        {
            List<string> listadoNombresDocentes = this.Docentes.Select(docente => docente.ApellidoYNombre).ToList();

            listadoNombresDocentes.Sort();

            return listadoNombresDocentes;
        }
        
        private List<string> ListadoNombresCursos()
        {
            List<string> listadoNombresCursos = this.Cursos.Select(curso => curso.MateriaYComision).ToList();

            listadoNombresCursos.Sort();

            return listadoNombresCursos;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}