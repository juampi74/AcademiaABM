namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class PlanUI : Form
    {
        public Plan Plan { get; set; }

        private List<(int Id, string Descripcion)> Especialidades;

        public PlanUI(List<(int Id, string Descripcion)> especialidades)
        {
            InitializeComponent();

            TituloLabel.Text = "Nuevo Plan";
            GuardarButton.Text = "Crear";

            this.Especialidades = especialidades;

            List<string> listadoEspecialidades = ListadoNombresEspecialidades();

            EspecialidadComboBox.DataSource = listadoEspecialidades;
        }

        public PlanUI(List<(int Id, string Descripcion)> especialidades, Plan planAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Plan";
            GuardarButton.Text = "Modificar";

            this.Especialidades = especialidades;

            this.Plan = planAModificar;

            EspecialidadComboBox.Enabled = false;

            DescPlanTextBox.Text = planAModificar.Desc_plan;

            EspecialidadComboBox.DataSource = ListadoNombresEspecialidades();

            foreach (var especialidad in this.Especialidades)
            {
                if (especialidad.Id == planAModificar.Id_especialidad)
                {
                    EspecialidadComboBox.SelectedItem = especialidad.Descripcion;
                }
            }
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatosIngresados())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    PlanDTO planModificado = EstablecerDatosPlanAModificar();

                    var response = await PlanNegocio.Update(Plan.Id_plan, planModificado);

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
                    Plan nuevoPlan = EstablecerDatosNuevoPlan();

                    var response = await PlanNegocio.Add(nuevoPlan);

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
            if (DescPlanTextBox.Text.Length < 5)
            {
                MessageBox.Show($"La descripción debe tener más de 5 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }

            return true;
        }

        private PlanDTO EstablecerDatosPlanAModificar()
        {
            int idEspecialidadSeleccionada = ObtenerIdEspecialidadSeleccionada();

            PlanDTO plan = new PlanDTO();

            plan.Desc_plan = DescPlanTextBox.Text;
            plan.Id_especialidad = idEspecialidadSeleccionada;

            return plan;
        }

        private Plan EstablecerDatosNuevoPlan()
        {
            int idEspecialidadSeleccionada = ObtenerIdEspecialidadSeleccionada();

            Plan plan = new Plan(DescPlanTextBox.Text, idEspecialidadSeleccionada);

            return plan;
        }

        private int ObtenerIdEspecialidadSeleccionada()
        {
            int idEspecialidadSeleccionada = 0;

            foreach (var especialidad in this.Especialidades)
            {
                if (especialidad.Descripcion == EspecialidadComboBox.SelectedValue.ToString())
                {
                    idEspecialidadSeleccionada = especialidad.Id;
                }
            }

            return idEspecialidadSeleccionada;
        }

        private List<string> ListadoNombresEspecialidades()
        {
            List<string> listadoNombresEspecialidades = this.Especialidades.Select(plan => plan.Descripcion).ToList();

            listadoNombresEspecialidades.Sort();

            return listadoNombresEspecialidades;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}