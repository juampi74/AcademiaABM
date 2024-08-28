namespace AcademiaABM.Presentacion
{
    using AcademiaABM.Negocio.Entidades;

    public partial class NuevoCurso : Form
    {
        public Curso Curso { get; set; }

        private List<(int Id, string Descripcion)> Comisiones;
        private List<(int Id, string Descripcion)> Materias;


        public NuevoCurso(List<(int Id, string Descripcion)> comisiones, List<(int Id, string Descripcion)> materias)
        {
            InitializeComponent();

            this.Comisiones = comisiones;
            this.Materias = materias;

            // Obtener solo los nombres de las comisiones y materias
            List<string> listadoNombresComisiones = this.Comisiones.Select(comision => comision.Descripcion).ToList();
            List<string> listadoNombresMaterias = this.Materias.Select(materia => materia.Descripcion).ToList();

            // Ordenar las listas de nombres de las comisiones y materias según su descripción
            listadoNombresComisiones.Sort();
            listadoNombresMaterias.Sort();

            // Asignar los nombres de las comisiones y materias a los ComboBox
            ComisionComboBox.DataSource = listadoNombresComisiones;
            MateriaComboBox.DataSource = listadoNombresMaterias;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                EstablecerDatosCurso();

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

        private void EstablecerDatosCurso()
        {

            int idComisionSeleccionada = 0;
            int idMateriaSeleccionada = 0;

            // Buscar el Id de la Comision que coincida con la Descripcion seleccionada
            foreach (var comision in this.Comisiones)
            {
                if (comision.Descripcion == ComisionComboBox.SelectedValue.ToString())
                {
                    idComisionSeleccionada = comision.Id;
                }
            }

            // Buscar el Id de la Materia que coincida con la Descripcion seleccionada
            foreach (var materia in this.Materias)
            {
                if (materia.Descripcion == MateriaComboBox.SelectedValue.ToString())
                {
                    idMateriaSeleccionada = materia.Id;
                }
            }

            Curso = new Curso(int.Parse(AnioCalendarioTextBox.Text), int.Parse(CupoTextBox.Text), idComisionSeleccionada, idMateriaSeleccionada);
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}