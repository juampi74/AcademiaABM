namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class MateriaUI : Form
    {
        public Materia Materia { get; set; }

        private List<(int Id, string Descripcion)> Planes;

        public MateriaUI(List<(int Id, string Descripcion)> planes)
        {
            InitializeComponent();

            TituloLabel.Text = "Nueva Materia";
            GuardarButton.Text = "Crear";

            this.Planes = planes;

            List<string> listadoPlanes = ListadoNombresPlanes();

            PlanComboBox.DataSource = listadoPlanes;
        }

        public MateriaUI(List<(int Id, string Descripcion)> planes, Materia materiaAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Materia";
            GuardarButton.Text = "Modificar";

            this.Planes = planes;
            
            this.Materia = materiaAModificar;

            PlanComboBox.Enabled = false;

            DescripcionTextBox.Text = materiaAModificar.Desc_materia;
            HsSemanalesTextBox.Text = materiaAModificar.Hs_semanales.ToString();
            HsTotalesTextBox.Text = materiaAModificar.Hs_totales.ToString();
            
            PlanComboBox.DataSource = ListadoNombresPlanes();

            foreach (var plan in this.Planes)
            {
                if (plan.Id == materiaAModificar.Id_plan)
                {
                    PlanComboBox.SelectedItem = plan.Descripcion;
                }
            }
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatosIngresados())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    MateriaDTO materiaModificada = EstablecerDatosMateriaAModificar();

                    var response = await MateriaNegocio.Update(Materia.Id_materia, materiaModificada);

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
                    Materia nuevaMateria = EstablecerDatosNuevaMateria();

                    var response = await MateriaNegocio.Add(nuevaMateria);

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
            if (DescripcionTextBox.Text.Length < 10)
            {
                MessageBox.Show($"La descripción debe tener más de 10 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;

            }

            if (int.TryParse(HsSemanalesTextBox.Text, out int hsSemanales))
            {
                if (hsSemanales < 3 || hsSemanales > 6)
                {
                    MessageBox.Show($"La cantidad de horas semanales debe ser un número entre 3 y 6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"La cantidad de horas semanales debe ser un número entre 3 y 6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }

            if (int.TryParse(HsTotalesTextBox.Text, out int hsTotales))
            {
                if (hsTotales < 100 || hsTotales > 250)
                {
                    MessageBox.Show($"La cantidad de horas totales debe ser un número entre 100 y 250", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show($"La cantidad de horas totales debe ser un número entre 100 y 250", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }
        }

        private MateriaDTO EstablecerDatosMateriaAModificar()
        {
            int idPlanSeleccionado = ObtenerIdPlanSeleccionado();

            MateriaDTO materia = new MateriaDTO();

            materia.Desc_materia = DescripcionTextBox.Text;
            materia.Hs_semanales = Int32.Parse(HsSemanalesTextBox.Text);
            materia.Hs_totales = Int32.Parse(HsTotalesTextBox.Text);
            materia.Id_plan = idPlanSeleccionado;

            return materia;
        }

        private Materia EstablecerDatosNuevaMateria()
        {
            int idPlanSeleccionado = ObtenerIdPlanSeleccionado();

            Materia materia = new Materia(DescripcionTextBox.Text, Int32.Parse(HsSemanalesTextBox.Text), Int32.Parse(HsTotalesTextBox.Text), idPlanSeleccionado);

            return materia;
        }

        private int ObtenerIdPlanSeleccionado()
        {
            int idPlanSeleccionado = 0;

            foreach (var plan in this.Planes)
            {
                if (plan.Descripcion == PlanComboBox.SelectedValue.ToString())
                {
                    idPlanSeleccionado = plan.Id;
                }
            }
            return idPlanSeleccionado;
        }

        private List<string> ListadoNombresPlanes()
        {
            List<string> listadoNombresPlanes = this.Planes.Select(plan => plan.Descripcion).ToList();

            listadoNombresPlanes.Sort();

            return listadoNombresPlanes;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}