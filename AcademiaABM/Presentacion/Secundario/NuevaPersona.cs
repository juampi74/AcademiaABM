namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class NuevaPersona : Form
    {
        public Persona Persona { get; set; }

        private List<(int Id, string Descripcion)> Planes;

        public NuevaPersona(List<(int Id, string Descripcion)> planes)
        {
            InitializeComponent();

            this.Planes = planes;

            // Obtener solo los nombres de los planes
            List<string> listadoNombresPlanes = this.Planes.Select(plan => plan.Descripcion).ToList();

            // Ordenar la lista de nombres de los planes según su descripción
            listadoNombresPlanes.Sort();

            // Asignar los nombres de los planes al ComboBox de Plan
            PlanComboBox.DataSource = listadoNombresPlanes;

            // Dar opciones para el ComboBox de TipoPersona
            TipoPersonaComboBox.DataSource = new List<string>() {"Alumno", "Docente"};
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                EstablecerDatosPersona();

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

        private void EstablecerDatosPersona()
        {
            int idPlanSeleccionado = 0;
            int numeroTipoPersona = 0;

            // Buscar el Id del Plan que coincida con la Descripcion seleccionada
            foreach (var plan in this.Planes)
            {
                if (plan.Descripcion == PlanComboBox.SelectedValue.ToString())
                {
                    idPlanSeleccionado = plan.Id;
                }
            }

            // Asigna un número a numeroTipoPersona según lo seleccionada en el ComboBox
            if (TipoPersonaComboBox.SelectedValue.ToString() == "Alumno")
            {
                numeroTipoPersona = 0;
            } else
            {
                numeroTipoPersona = 1;
            }

            Persona = new Persona(NombreTextBox.Text, ApellidoTextBox.Text, DireccionTextBox.Text, EmailTextBox.Text, TelefonoTextBox.Text, DateTime.Parse(FechaNacimientoTextBox.Text), int.Parse(LegajoTextBox.Text), numeroTipoPersona, idPlanSeleccionado);
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
