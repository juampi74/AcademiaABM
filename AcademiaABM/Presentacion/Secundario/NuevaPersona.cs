namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class NuevaPersona : Form
    {
        public Persona Persona { get; set; }

        public NuevaPersona()
        {
            InitializeComponent();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                EstablecerDatosPersona();

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

        private void EstablecerDatosPersona()
        {
            Persona = new Persona(NombreTextBox.Text, ApellidoTextBox.Text, DireccionTextBox.Text, EmailTextBox.Text, TelefonoTextBox.Text, DateTime.Parse(FechaNacimientoTextBox.Text), int.Parse(LegajoTextBox.Text), int.Parse(TipoPersonaTextBox.Text), int.Parse(IdPlanTextBox.Text));
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
