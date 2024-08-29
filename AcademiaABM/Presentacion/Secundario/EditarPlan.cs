namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class EditarPlan : Form
    {
        private Plan planAEditar;

        public EditarPlan(Plan planAEditar)
        {
            InitializeComponent();

            this.planAEditar = planAEditar;

            EstablecerValoresIniciales();
        }

        private void EstablecerValoresIniciales()
        {
            DescPlanTextBox.Text = planAEditar.Desc_plan;
            IdEspecialidadTextBox.Text = planAEditar.Id_especialidad.ToString();
        }

        private void EditarGuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                ActualizarDatosPlan();

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

        private void ActualizarDatosPlan()
        {
            planAEditar.Desc_plan = DescPlanTextBox.Text;
            planAEditar.Id_especialidad = Int32.Parse(IdEspecialidadTextBox.Text);
        }


        private void EditarCancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Plan PlanAEditar
        {
            get { return planAEditar; }
            set { planAEditar = value; }
        }
    }
}