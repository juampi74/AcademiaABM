namespace Escritorio
{
    using System.Net;

    using Entidades;
    using Negocio;

    public partial class EspecialidadUI : Form
    {

        private Especialidad Especialidad;

        public EspecialidadUI()
        {
            InitializeComponent();
            TituloLabel.Text = "Nueva Especialidad";
            GuardarButton.Text = "Crear";

        }

        public EspecialidadUI(Especialidad especialidadAModificar)
        {
            InitializeComponent();
            TituloLabel.Text = "Editar Especialidad";
            GuardarButton.Text = "Modificar";

            this.Especialidad = especialidadAModificar;

            DescEspecialidadTextBox.Text = Especialidad.Desc_especialidad;
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    EspecialidadDTO especialidadModificada = EstablecerDatosEspecialidadAModificar();

                    var response = await EspecialidadNegocio.Update(Especialidad.Id_especialidad, especialidadModificada);

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
                    Especialidad nuevaEspecialidad = EstablecerDatosNuevaEspecialidad();

                    var response = await EspecialidadNegocio.Add(nuevaEspecialidad);

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

        private EspecialidadDTO EstablecerDatosEspecialidadAModificar()
        {
            EspecialidadDTO especialidad = new EspecialidadDTO();

            especialidad.Desc_especialidad = DescEspecialidadTextBox.Text;

            return especialidad;
        }

        private Especialidad EstablecerDatosNuevaEspecialidad()
        {
            Especialidad especialidad = new Especialidad(DescEspecialidadTextBox.Text);

            return especialidad;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}