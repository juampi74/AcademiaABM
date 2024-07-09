namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class EditarAlumno : Form
    {
        public Alumno AlumnoAEditar { get; set; }

        public EditarAlumno(Alumno alumnoAEditar)
        {
            InitializeComponent();
            
            this.AlumnoAEditar = alumnoAEditar;
            
            EstablecerValoresIniciales();
        }

        private void EstablecerValoresIniciales()
        {
            ApellidoTextBox.Text = AlumnoAEditar.Apellido;
            NombreTextBox.Text = AlumnoAEditar.Nombre;
            LegajoTextBox.Text = AlumnoAEditar.Legajo.ToString();
            DireccionTextBox.Text = AlumnoAEditar.Direccion;
            TelefonoTextBox.Text = AlumnoAEditar.Telefono;
        }

        private void EditarGuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                ActualizarDatosAlumno();

                DialogResult = DialogResult.OK;
            }
        }


        private bool ComprobarCamposRequeridos()
        {
            foreach (Control control in this.Controls.Cast<Control>().OrderBy(c => c.TabIndex))
            {
                if (control is TextBox textBox && textBox.Name != "TelefonoTextBox")
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

        private void ActualizarDatosAlumno()
        {
            AlumnoAEditar.Apellido = ApellidoTextBox.Text;
            AlumnoAEditar.Nombre = NombreTextBox.Text;
            AlumnoAEditar.Legajo = Int32.Parse(LegajoTextBox.Text);
            AlumnoAEditar.Direccion = DireccionTextBox.Text;
            AlumnoAEditar.Telefono = TelefonoTextBox.Text;

            AlumnoAEditar.Telefono = string.IsNullOrEmpty(TelefonoTextBox.Text) ? null : TelefonoTextBox.Text;
        }


        private void EditarCancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

    }
}
