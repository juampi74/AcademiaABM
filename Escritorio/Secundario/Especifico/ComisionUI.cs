namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class ComisionUI : Form
    {
        public Comision Comision{ get; set; }

        private List<(int Id, string Descripcion)> Planes;

        public ComisionUI(List<(int Id, string Descripcion)> planes)
        {
            InitializeComponent();

            TituloLabel.Text = "Nueva Comision";
            GuardarButton.Text = "Crear";

            this.Planes = planes;

            List<string> listadoPlanes = ListadoNombresPlanes();

            PlanComboBox.DataSource = listadoPlanes;
        }

        public ComisionUI(List<(int Id, string Descripcion)> planes, Comision comisionAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Comision";
            GuardarButton.Text = "Modificar";

            this.Planes = planes;
            
            this.Comision = comisionAModificar;

            PlanComboBox.Enabled = false;

            AnioEspecialidadTextBox.Text = comisionAModificar.Anio_especialidad.ToString();
            AnioEspecialidadTextBox.BackColor = Color.WhiteSmoke;
            AnioEspecialidadTextBox.Enabled = false;

            DescripcionTextBox.Text = comisionAModificar.Desc_comision;
            
            PlanComboBox.DataSource = ListadoNombresPlanes();

            foreach (var plan in this.Planes)
            {
                if (plan.Id == comisionAModificar.Id_plan)
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
                    ComisionDTO comisionModificada = EstablecerDatosComisionAModificar();

                    var response = await ComisionNegocio.Update(Comision.Id_comision, comisionModificada);

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
                    Comision nuevaComision = EstablecerDatosNuevaComision();

                    var response = await ComisionNegocio.Add(nuevaComision);

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

            if (AnioEspecialidadTextBox.Text.Length == 0)
            {
                MessageBox.Show($"El año de la especialidad es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }

            if (int.TryParse(AnioEspecialidadTextBox.Text, out int anio))
            {
                if (anio < 1 || anio > 6)
                {
                    MessageBox.Show($"El año de la especialidad debe ser un número entre 1 y 6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show($"El año de la especialidad debe ser un número entre 1 y 6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }
        }

        private ComisionDTO EstablecerDatosComisionAModificar()
        {
            int idPlanSeleccionado = ObtenerIdPlanSeleccionado();

            ComisionDTO comision = new ComisionDTO();

            comision.Desc_comision = DescripcionTextBox.Text;
            comision.Anio_especialidad = Int32.Parse(AnioEspecialidadTextBox.Text);
            comision.Id_plan = idPlanSeleccionado;

            return comision;
        }

        private Comision EstablecerDatosNuevaComision()
        {
            int idPlanSeleccionado = ObtenerIdPlanSeleccionado();

            Comision comision = new Comision(DescripcionTextBox.Text, Int32.Parse(AnioEspecialidadTextBox.Text), idPlanSeleccionado);

            return comision;
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