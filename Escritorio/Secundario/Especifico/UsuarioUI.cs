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

            if(personas == null || personas.Count == 0)
            {
                PersonaComboBox.Visible = true;
                AdministradorCheckBox.Checked = true;
                AdministradorCheckBox.Enabled = false;
            }
            else
            {
                List<string> listadoPersonas = ListadoNombresPersonas();
                PersonaComboBox.DataSource = listadoPersonas;
            }
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

            PersonaComboBox.DataSource = ListadoNombresPersonas();

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
                
                usuario = new Usuario(NombreUsuarioTextBox.Text, ClaveTextBox.Text, -1, idPersonaSeleccionada);
            
            }
            else
            {
                usuario = new Usuario(NombreUsuarioTextBox.Text, ClaveTextBox.Text, 0);
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