namespace Escritorio
{
    using Entidades;
    using Negocio;

    public partial class PersonaUI : Form
    {
        public Persona Persona { get; set; }

        private List<(int Id, string Descripcion)> Planes;

        public PersonaUI(List<(int Id, string Descripcion)> planes)
        {
            InitializeComponent();

            TituloLabel.Text = "Nueva Persona";
            GuardarButton.Text = "Crear";

            this.Planes = planes;

            List<string> listadoPlanes = ListadoNombresPlanes();

            // Asignar los nombres de los planes al ComboBox de Plan
            PlanComboBox.DataSource = listadoPlanes;

            // Dar opciones para el ComboBox de TipoPersona
            TipoPersonaComboBox.DataSource = new List<string>() { "Alumno", "Docente" };
        }

        public PersonaUI(List<(int Id, string Descripcion)> planes, Persona personaAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Persona";
            GuardarButton.Text = "Modificar";

            this.Planes = planes;
            this.Persona = personaAModificar;

            NombreTextBox.Text = personaAModificar.Nombre;
            ApellidoTextBox.Text = personaAModificar.Apellido;
            DireccionTextBox.Text = personaAModificar.Direccion;
            EmailTextBox.Text = personaAModificar.Email;
            TelefonoTextBox.Text = personaAModificar.Telefono;

            FechaNacimientoDatePicker.Value = personaAModificar.Fecha_nac;
                        
            LegajoTextBox.Text = personaAModificar.Legajo.ToString();
            
            TipoPersonaComboBox.DataSource = new List<string>() { "Alumno", "Docente" };
            
            if(personaAModificar.Tipo_persona == 0)
            {
                TipoPersonaComboBox.SelectedIndex = 0;
            }
            else
            {
                TipoPersonaComboBox.SelectedIndex = 1;
            }

            PlanComboBox.DataSource = ListadoNombresPlanes();

            foreach (var plan in this.Planes)
            {
                if (plan.Id == personaAModificar.Id_plan)
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
                    PersonaDTO personaModificada = EstablecerDatosPersonaAModificar();

                    await PersonaNegocio.Update(Persona.Id_persona, personaModificada);
                }
                else
                {
                    Persona nuevaPersona = EstablecerDatosNuevaPersona();

                    await PersonaNegocio.Add(nuevaPersona);
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

        private PersonaDTO EstablecerDatosPersonaAModificar()
        {
            int idPlanSeleccionado = ObtenerIdPlanSeleccionado();
            int numeroTipoPersona = ObtenerNumeroTipoPersona();

            PersonaDTO persona = new PersonaDTO();

            persona.Nombre = NombreTextBox.Text;
            persona.Apellido = ApellidoTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.Email = EmailTextBox.Text;
            persona.Telefono = TelefonoTextBox.Text;
            persona.Fecha_nac = FechaNacimientoDatePicker.Value;
            persona.Legajo = Int32.Parse(LegajoTextBox.Text);
            persona.Tipo_persona = numeroTipoPersona;
            persona.Id_plan = idPlanSeleccionado;

            return persona;
        }

        private Persona EstablecerDatosNuevaPersona()
        {
            int idPlanSeleccionado = ObtenerIdPlanSeleccionado();
            int numeroTipoPersona = ObtenerNumeroTipoPersona();

            Persona persona = new Persona(NombreTextBox.Text, ApellidoTextBox.Text, DireccionTextBox.Text, EmailTextBox.Text, TelefonoTextBox.Text, FechaNacimientoDatePicker.Value, Int32.Parse(LegajoTextBox.Text), numeroTipoPersona, idPlanSeleccionado);

            return persona;
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

        private int ObtenerNumeroTipoPersona()
        {
            int numeroTipoPersona = 0;

            // Asigna un número a numeroTipoPersona según lo seleccionada en el ComboBox
            if (TipoPersonaComboBox.SelectedValue.ToString() == "Alumno")
            {
                numeroTipoPersona = 0;
            }
            else
            {
                numeroTipoPersona = 1;
            }

            return numeroTipoPersona;
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