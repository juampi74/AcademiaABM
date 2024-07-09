namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class NuevoAlumno : Form
    {
        public Alumno Alumno { get; set; }

        public NuevoAlumno()
        {
            InitializeComponent();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                EstablecerDatosAlumno();

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

        private void EstablecerDatosAlumno()
        {
            Alumno = new Alumno(ApellidoTextBox.Text, NombreTextBox.Text, int.Parse(LegajoTextBox.Text), DireccionTextBox.Text, TelefonoTextBox.Text);
            Alumno.Telefono = string.IsNullOrEmpty(TelefonoTextBox.Text) ? null : TelefonoTextBox.Text;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


    }
}
