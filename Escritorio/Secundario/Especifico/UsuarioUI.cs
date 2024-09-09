﻿namespace Escritorio
{
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
            HabilitadoTextBox.Text = usuarioAModificar.Habilitado.ToString();
            CambiaClaveTextbox.Text = usuarioAModificar.Cambia_clave.ToString();
            
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
            if (ComprobarCamposRequeridos())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    UsuarioDTO usuarioModificado = EstablecerDatosUsuarioAModificar();

                    await UsuarioNegocio.Update(Usuario.Id_usuario, usuarioModificado);
                }
                else
                {
                    Usuario nuevoUsuario = EstablecerDatosNuevoUsuario();

                    await UsuarioNegocio.Add(nuevoUsuario);
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

        private UsuarioDTO EstablecerDatosUsuarioAModificar()
        {
            int idPersonaSeleccionada = ObtenerIdPersonaSeleccionada();

            UsuarioDTO usuario = new UsuarioDTO();

            usuario.Nombre_usuario = NombreUsuarioTextBox.Text;
            usuario.Clave = ClaveTextBox.Text;
            usuario.Habilitado = Int32.Parse(HabilitadoTextBox.Text);
            usuario.Cambia_clave = Int32.Parse(CambiaClaveTextbox.Text);
            usuario.Id_persona = idPersonaSeleccionada;

            return usuario;
        }

        private Usuario EstablecerDatosNuevoUsuario()
        {
            int idPersonaSeleccionada = ObtenerIdPersonaSeleccionada();

            Usuario usuario = new Usuario(NombreUsuarioTextBox.Text, ClaveTextBox.Text, Int32.Parse(HabilitadoTextBox.Text), Int32.Parse(CambiaClaveTextbox.Text), idPersonaSeleccionada);

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