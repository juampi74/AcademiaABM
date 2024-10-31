namespace Escritorio
{
    using System.Net;
    using System.Text.RegularExpressions;

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

            PlanComboBox.DataSource = listadoPlanes;

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
            if (ValidarDatosIngresados())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    PersonaDTO personaModificada = EstablecerDatosPersonaAModificar();

                    var response = await PersonaNegocio.Update(Persona.Id_persona, personaModificada);

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
                    Persona nuevaPersona = EstablecerDatosNuevaPersona();

                    var response = await PersonaNegocio.Add(nuevaPersona);

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
            if (NombreTextBox.Text.Length < 2 || NombreTextBox.Text.Length > 30)
            {
                MessageBox.Show($"El nombre debe tener entre de 2 y 30 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;

            }

            if (ApellidoTextBox.Text.Length < 2 || ApellidoTextBox.Text.Length > 50)
            {
                MessageBox.Show($"El apellido debe tener entre de 2 y 50 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;

            }

            if (DireccionTextBox.Text.Length < 5 || ApellidoTextBox.Text.Length > 30)
            {
                MessageBox.Show($"La dirección debe tener entre de 5 y 30 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;

            }

            if (!Regex.IsMatch(EmailTextBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show($"El email ingresado es inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;

            }

            if (!Regex.IsMatch(TelefonoTextBox.Text, @"^\d{10,20}$"))
            {
                MessageBox.Show($"El teléfono debe estar conformado por entre 10 y 20 números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;

            }

            if (DateTime.TryParse(FechaNacimientoDatePicker.Value.ToString(), out DateTime fechaNacimiento))
            {
                if (fechaNacimiento >= DateTime.Today || fechaNacimiento < new DateTime(1900, 1, 1))
                {
                    MessageBox.Show($"La fecha de nacimiento debe ser mayor o igual al año 1900 y menor a la actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    DialogResult = DialogResult.None;
                    return false;
                }
            }
            else
            {
                MessageBox.Show($"La fecha de nacimiento debe ser mayor o igual al año 1900 y menor a la actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }

            if (int.TryParse(LegajoTextBox.Text, out int legajo))
            {
                if (!Regex.IsMatch(legajo.ToString(), @"^\d{5,6}$"))
                {
                    MessageBox.Show($"El legajo debe estar conformado por 5 o 6 números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show($"El legajo debe estar conformado por 5 o 6 números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }
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