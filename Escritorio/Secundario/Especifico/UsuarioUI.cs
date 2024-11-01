namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class UsuarioUI : Form
    {
        public Usuario Usuario { get; set; }

        private List<(int Id, string ApellidoYNombre)> Personas;

        public UsuarioUI(List<(int Id, string ApellidoYNombre)> personas)
        {
            InitializeComponent();

            TituloLabel.Text = "Nuevo Usuario";
            GuardarButton.Text = "Crear";

            this.Personas = personas;

            PersonaComboBox.Visible = !AdministradorCheckBox.Checked;

            List<string> listadoPersonas = ListadoNombresPersonas();

            HabilitadoComboBox.DataSource = new List<string>() { "Si", "No" };
            CambiaClaveComboBox.DataSource = new List<string>() { "No", "Si" };

            PersonaComboBox.DataSource = listadoPersonas;
        }

        public UsuarioUI(List<(int Id, string ApellidoYNombre)> personas, Usuario usuarioAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Usuario";
            GuardarButton.Text = "Modificar";

            this.Personas = personas;

            this.Usuario = usuarioAModificar;

            NombreUsuarioTextBox.Enabled = false;
            NombreUsuarioTextBox.BackColor = Color.WhiteSmoke;

            // Marco el checkbox si el rol es 2 (Administrador)
            AdministradorCheckBox.Checked = usuarioAModificar.Rol == 2;

            // Deshabilito el checkbox
            AdministradorCheckBox.Enabled = false;

            // Oculto el ComboBox de Persona si no está marcado el CheckBox de Administrador
            PersonaComboBox.Visible = !AdministradorCheckBox.Checked;
            PersonaComboBox.Enabled = false;

            if (usuarioAModificar.Rol == 2)
            {
                AdministradorCheckBox.Enabled = false;
            }

            AdministradorCheckBox.Visible = usuarioAModificar.Id_persona == null;

            NombreUsuarioTextBox.Text = usuarioAModificar.Nombre_usuario;
            ClaveTextBox.Text = usuarioAModificar.Clave;

            HabilitadoComboBox.DataSource = new List<string>() { "Si", "No" };
            CambiaClaveComboBox.DataSource = new List<string>() { "No", "Si" };

            PersonaComboBox.DataSource = ListadoNombresPersonas();

            if (usuarioAModificar.Habilitado == 1)
            {
                HabilitadoComboBox.SelectedIndex = 0;
            }
            else
            {
                HabilitadoComboBox.SelectedIndex = 1;
            }

            if (usuarioAModificar.Cambia_clave == 0)
            {
                CambiaClaveComboBox.SelectedIndex = 0;
            }
            else
            {
                CambiaClaveComboBox.SelectedIndex = 1;
            }

            foreach (var persona in this.Personas)
            {
                if (persona.Id == usuarioAModificar.Id_persona)
                {
                    PersonaComboBox.SelectedItem = persona.ApellidoYNombre;
                }
            }
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatosIngresados())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    UsuarioDTO usuarioModificado = EstablecerDatosUsuarioAModificar();

                    var response = await UsuarioNegocio.Update(Usuario.Id_usuario, usuarioModificado);

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
                    Usuario nuevoUsuario = EstablecerDatosNuevoUsuario();

                    var response = await UsuarioNegocio.Add(nuevoUsuario);

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
            if (NombreUsuarioTextBox.Text.Length < 5 || NombreUsuarioTextBox.Text.Length > 20)
            {
                MessageBox.Show($"El nombre de usuario debe tener entre de 5 y 20 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }

            if (ClaveTextBox.Text.Length < 5 || ClaveTextBox.Text.Length > 15)
            {
                MessageBox.Show($"La clave debe tener entre de 5 y 15 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return false;
            }

            return true;
        }

        private UsuarioDTO EstablecerDatosUsuarioAModificar()
        {
            UsuarioDTO usuario = new UsuarioDTO();

            usuario.Nombre_usuario = this.Usuario.Nombre_usuario;
            usuario.Clave = ClaveTextBox.Text;
            usuario.Habilitado = HabilitadoComboBox.SelectedValue.ToString() == "Si" ? 1 : 0;
            usuario.Cambia_clave = CambiaClaveComboBox.SelectedValue.ToString() == "Si" ? 1 : 0;
            usuario.Rol = this.Usuario.Rol;
            usuario.Id_persona = this.Usuario.Id_persona;

            return usuario;
        }

        private Usuario EstablecerDatosNuevoUsuario()
        {
            Usuario usuario;
            int idPersonaSeleccionada = 0;

            if (AdministradorCheckBox.Checked == false)
            {
                idPersonaSeleccionada = ObtenerIdPersonaSeleccionada();
                
                usuario = new Usuario(NombreUsuarioTextBox.Text, ClaveTextBox.Text, HabilitadoComboBox.SelectedValue.ToString() == "Si" ? 1 : 0, CambiaClaveComboBox.SelectedValue.ToString() == "Si" ? 1 : 0, -1, idPersonaSeleccionada);
            
            }
            else
            {
                usuario = new Usuario(NombreUsuarioTextBox.Text, ClaveTextBox.Text, HabilitadoComboBox.SelectedValue.ToString() == "Si" ? 1 : 0, CambiaClaveComboBox.SelectedValue.ToString() == "Si" ? 1 : 0, 0);
            }


            return usuario;
        }

        private int ObtenerIdPersonaSeleccionada()
        {
            int idPersonaSeleccionada = 0;

            foreach (var persona in this.Personas)
            {
                if (persona.ApellidoYNombre == PersonaComboBox.SelectedValue.ToString())
                {
                    idPersonaSeleccionada = persona.Id;
                }
            }

            return idPersonaSeleccionada;
        }

        private List<string> ListadoNombresPersonas()
        {
            List<string> ListadoNombresPersonas = this.Personas.Select(persona => persona.ApellidoYNombre).ToList();

            ListadoNombresPersonas.Sort();

            return ListadoNombresPersonas;
        }

        private void AdministradorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AdministradorCheckBox.Checked)
            {
                PersonaLabel.Visible = false;
                PersonaComboBox.Visible = false;
            }
            else
            {
                PersonaLabel.Visible = true;
                PersonaComboBox.Visible = true;
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}