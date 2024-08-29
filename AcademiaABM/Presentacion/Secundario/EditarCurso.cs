namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class EditarCurso : Form
    {
        private Curso cursoAEditar;

        public EditarCurso(Curso cursoAEditar)
        {
            InitializeComponent();

            this.cursoAEditar = cursoAEditar;

            EstablecerValoresIniciales();
        }

        private void EstablecerValoresIniciales()
        {
            AnioCalendarioTextBox.Text = cursoAEditar.Anio_calendario.ToString();
            CupoTextBox.Text = cursoAEditar.Cupo.ToString();
            IdComisionTextBox.Text = cursoAEditar.Id_comision.ToString();
            IdMateriaTextBox.Text = cursoAEditar.Id_materia.ToString();
        }

        private void EditarGuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                ActualizarDatosCurso();

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

        private void ActualizarDatosCurso()
        {
            cursoAEditar.Anio_calendario = Int32.Parse(AnioCalendarioTextBox.Text);
            cursoAEditar.Cupo = Int32.Parse(CupoTextBox.Text);
            cursoAEditar.Id_comision = Int32.Parse(IdComisionTextBox.Text);
            cursoAEditar.Id_materia = Int32.Parse(IdMateriaTextBox.Text);
        }


        private void EditarCancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public Curso CursoAEditar
        {
            get { return cursoAEditar; }
            set { cursoAEditar = value; }
        }
    }
}