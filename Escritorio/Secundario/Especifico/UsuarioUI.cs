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
            int idPersonaSeleccionada = ObtenerIdPersonaSeleccionada();

            UsuarioDTO usuario = new UsuarioDTO();

            usuario.Nombre_usuario = NombreUsuarioTextBox.Text;
            usuario.Clave = ClaveTextBox.Text;
            usuario.Habilitado = HabilitadoComboBox.SelectedValue.ToString() == "Si" ? 1 : 0;
            usuario.Cambia_clave = CambiaClaveComboBox.SelectedValue.ToString() == "Si" ? 1 : 0;
            usuario.Id_persona = idPersonaSeleccionada;

            return usuario;
        }

        private Usuario EstablecerDatosNuevoUsuario()
        {
            int idPersonaSeleccionada = ObtenerIdPersonaSeleccionada();

            Usuario usuario = new Usuario(NombreUsuarioTextBox.Text, ClaveTextBox.Text, HabilitadoComboBox.SelectedValue.ToString() == "Si" ? 1 : 0, CambiaClaveComboBox.SelectedValue.ToString() == "Si" ? 1 : 0, idPersonaSeleccionada);

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

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}