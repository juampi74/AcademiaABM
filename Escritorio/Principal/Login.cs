﻿namespace Escritorio
{
    using Entidades;
    using Negocio;
    using System.Collections.Generic;

    public partial class Login : Form
    {
        private int cantidadDeIntentosErroneos = 0;

        public Login()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                Cargando cargando = new Cargando();
                cargando.Show(this);

                try
                {
                    Task<IEnumerable<Usuario>> task = new Task<IEnumerable<Usuario>>(LeerUsuarios);
                    task.Start();

                    IEnumerable<Usuario> listadoUsuarios = await task;

                    ComprobarUsuarioIngresado(listadoUsuarios);
                }
                catch (Exception ex)
                {
                    cargando.Close();
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                }
                finally
                {
                    cargando.Close();
                }

            }
        }

        private bool ComprobarCamposRequeridos()
        {
            foreach (Control control in Controls.Cast<Control>().OrderBy(c => c.TabIndex))
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

        private IEnumerable<Usuario> LeerUsuarios()
        {
            return UsuarioNegocio.GetAll().Result;
        }

        private void ComprobarUsuarioIngresado(IEnumerable<Usuario> listadoUsuarios)
        {
            bool usuarioEncontrado = UsuarioNegocio.ComprobarUsuarioIngresado(listadoUsuarios, NombreDeUsuarioTextBox.Text, ClaveTextBox.Text);

            if (usuarioEncontrado)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                cantidadDeIntentosErroneos++;

                MessageBox.Show($"Usuario y/o clave incorrectos. Le queda(n) {3 - cantidadDeIntentosErroneos} intento(s).", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (cantidadDeIntentosErroneos == 3)
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}