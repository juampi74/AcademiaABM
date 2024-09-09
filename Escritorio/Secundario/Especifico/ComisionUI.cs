namespace Escritorio
{
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

            // Asignar los nombres de los planes al ComboBox de Plan
            PlanComboBox.DataSource = listadoPlanes;
        }

        public ComisionUI(List<(int Id, string Descripcion)> planes, Comision comisionAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Comision";
            GuardarButton.Text = "Modificar";

            this.Planes = planes;
            
            this.Comision = comisionAModificar;

            DescripcionTextBox.Text = comisionAModificar.Desc_comision;
            AnioEspecialidadTextBox.Text = comisionAModificar.Anio_especialidad.ToString();
            
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
            if (ComprobarCamposRequeridos())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    ComisionDTO comisionModificada = EstablecerDatosComisionAModificar();

                    await ComisionNegocio.Update(Comision.Id_comision, comisionModificada);
                }
                else
                {
                    Comision nuevaComision = EstablecerDatosNuevaComision();

                    await ComisionNegocio.Add(nuevaComision);
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

            // Buscar el Id del Plan que coincida con la Descripcion seleccionada
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
            // Obtener solo los nombres de los planes
            List<string> listadoNombresPlanes = this.Planes.Select(plan => plan.Descripcion).ToList();

            // Ordenar la lista de nombres de los planes según su descripción
            listadoNombresPlanes.Sort();

            return listadoNombresPlanes;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}