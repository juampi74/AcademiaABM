namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class EditarEspecialidad : Form
    {
        private Especialidad especialidadAEditar;

        public EditarEspecialidad(Especialidad especialidadAEditar)
        {
            InitializeComponent();

            this.especialidadAEditar = especialidadAEditar;

            EstablecerValoresIniciales();
        }

        private void EstablecerValoresIniciales()
        {
            DescEspecialidadTextBox.Text = especialidadAEditar.Desc_especialidad;
        }

        private void EditarGuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                ActualizarDatosEspecialidad();

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

        private void ActualizarDatosEspecialidad()
        {
            especialidadAEditar.Desc_especialidad = DescEspecialidadTextBox.Text;
        }


        private void EditarCancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Especialidad EspecialidadAEditar
        {
            get { return especialidadAEditar; }
            set { especialidadAEditar = value; }
        }
    }
}