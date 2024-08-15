namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class NuevaComision : Form
    {
        public Comision Comision { get; set; }

        private List<(int Id, string Descripcion)> Planes;

        public NuevaComision(List<(int Id, string Descripcion)> planes)
        {
            InitializeComponent();

            this.Planes = planes;

            // Obtener solo los nombres de los planes
            List<string> listadoNombresPlanes = this.Planes.Select(plan => plan.Descripcion).ToList();

            // Ordenar las lista de nombres de los planes según su descripción
            listadoNombresPlanes.Sort();

            // Asignar los nombres de los planes al ComboBox de Plan
            PlanComboBox.DataSource = listadoNombresPlanes;

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                EstablecerDatosComision();

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

        private void EstablecerDatosComision()
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

            Comision = new Comision(DescripcionTextBox.Text, int.Parse(AnioEspecialidadTextBox.Text), idPlanSeleccionado);
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
