namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class EditarComision : Form
    {
        private Comision comisionAEditar;

        public EditarComision(Comision comisionAEditar)
        {
            InitializeComponent();

            this.comisionAEditar = comisionAEditar;

            EstablecerValoresIniciales();
        }

        private void EstablecerValoresIniciales()
        {
            DescComisionTextBox.Text = comisionAEditar.Desc_comision;
            AnioEspecialidadTextBox.Text = comisionAEditar.Anio_especialidad.ToString();
            IdPlanTextBox.Text = comisionAEditar.Id_plan.ToString();
        }

        private void EditarGuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                ActualizarDatosComision();

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

        private void ActualizarDatosComision()
        {
            comisionAEditar.Desc_comision = DescComisionTextBox.Text;
            comisionAEditar.Anio_especialidad = Int32.Parse(AnioEspecialidadTextBox.Text);
            comisionAEditar.Id_plan = Int32.Parse(IdPlanTextBox.Text);
        }


        private void EditarCancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Comision ComisionAEditar
        {
            get { return comisionAEditar; }
            set { comisionAEditar = value; }
        }

    }
}
