namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class EditarPersona : Form
    {
        public Persona PersonaAEditar { get; set; }

        public EditarPersona(Persona personaAEditar)
        {
            InitializeComponent();
            
            this.PersonaAEditar = personaAEditar;
            
            EstablecerValoresIniciales();
        }

        private void EstablecerValoresIniciales()
        {
            NombreTextBox.Text = PersonaAEditar.Nombre;
            ApellidoTextBox.Text = PersonaAEditar.Apellido;
            DireccionTextBox.Text = PersonaAEditar.Direccion;
            EmailTextBox.Text = PersonaAEditar.Email;
            TelefonoTextBox.Text = PersonaAEditar.Telefono;
            FechaNacimientoTextBox.Text = PersonaAEditar.Fecha_nac.ToString();
            LegajoTextBox.Text = PersonaAEditar.Legajo.ToString();
            TipoPersonaTextBox.Text = PersonaAEditar.Tipo_persona.ToString();
            IdPlanTextBox.Text = PersonaAEditar.Id_plan.ToString();
        }

        private void EditarGuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                ActualizarDatosPersona();

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

        private void ActualizarDatosPersona()
        {
            PersonaAEditar.Nombre = NombreTextBox.Text;
            PersonaAEditar.Apellido = ApellidoTextBox.Text;
            PersonaAEditar.Direccion = DireccionTextBox.Text;
            PersonaAEditar.Email = EmailTextBox.Text;
            PersonaAEditar.Telefono = TelefonoTextBox.Text;
            PersonaAEditar.Fecha_nac = DateTime.Parse(FechaNacimientoTextBox.Text);
            PersonaAEditar.Legajo = Int32.Parse(LegajoTextBox.Text);
            PersonaAEditar.Tipo_persona = Int32.Parse(TipoPersonaTextBox.Text);
            PersonaAEditar.Id_plan = Int32.Parse(IdPlanTextBox.Text);
        }


        private void EditarCancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
