namespace AcademiaABM.Presentacion.Principal
{
    using AcademiaABM.Negocio.Entidades;
    using AcademiaABM.Negocio.Servicios;
    using System.ComponentModel;

    public partial class Login : Form
    {
        private UsuarioService _usuarioService;

        private int cantidadDeIntentosErroneos = 0;
     
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            if (ComprobarCamposRequeridos())
            {
                if (cantidadDeIntentosErroneos < 1)
                {
                    EstablecerConexion();
                }
                else
                {
                    ConexionYaEstablecida();
                }
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

        private void EstablecerConexion()
        {

            Cargando cargando = new Cargando();
            cargando.Show(this);

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                try
                {
                    InitializeService();

                    e.Result = _usuarioService.ObtenerTodosLosUsuarios();
                }
                catch
                {
                    cargando.Invoke((Action)(() => cargando.Close()));
                    this.Invoke((Action)(() => MessageBox.Show($"Error al conectar a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
                    this.DialogResult = DialogResult.Cancel;
                }
            };

            worker.RunWorkerCompleted += (sender, e) =>
            {
                cargando.Close();

                if (e.Result != null)
                {
                    List<Usuario> listadoUsuarios = (List<Usuario>) e.Result;
                    ComprobarUsuarioIngresado(listadoUsuarios);
                }
            };

            worker.RunWorkerAsync();
        }

        private void InitializeService()
        {
            if (_usuarioService == null)
            {
                _usuarioService = new UsuarioService();
            }
        }

        private void ConexionYaEstablecida()
        {
            List<Usuario> listadoUsuarios = _usuarioService.ObtenerTodosLosUsuarios();
            ComprobarUsuarioIngresado(listadoUsuarios);
        }

        private void ComprobarUsuarioIngresado(List<Usuario> listadoUsuarios)
        {
            bool usuarioEncontrado = _usuarioService.ComprobarUsuarioIngresado(listadoUsuarios, NombreDeUsuarioTextBox.Text, ContraseniaTextBox.Text);

            if (usuarioEncontrado)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                cantidadDeIntentosErroneos++;

                MessageBox.Show($"Usuario y/o contraseña incorrectos. Le queda(n) {3 - cantidadDeIntentosErroneos} intento(s).", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (cantidadDeIntentosErroneos == 3)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}