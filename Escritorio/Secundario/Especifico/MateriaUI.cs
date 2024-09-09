namespace Escritorio
{
    using Entidades;
    using Negocio;

    public partial class MateriaUI : Form
    {
        public Materia Materia { get; set; }

        private List<(int Id, string Descripcion)> Planes;

        public MateriaUI(List<(int Id, string Descripcion)> planes)
        {
            InitializeComponent();

            TituloLabel.Text = "Nueva Materia";
            GuardarButton.Text = "Crear";

            this.Planes = planes;

            List<string> listadoPlanes = ListadoNombresPlanes();

            PlanComboBox.DataSource = listadoPlanes;
        }

        public MateriaUI(List<(int Id, string Descripcion)> planes, Materia materiaAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Materia";
            GuardarButton.Text = "Modificar";

            this.Planes = planes;
            
            this.Materia = materiaAModificar;

            DescripcionTextBox.Text = materiaAModificar.Desc_materia;
            HsSemanalesTextBox.Text = materiaAModificar.Hs_semanales.ToString();
            HsTotalesTextBox.Text = materiaAModificar.Hs_totales.ToString();
            
            PlanComboBox.DataSource = ListadoNombresPlanes();

            foreach (var plan in this.Planes)
            {
                if (plan.Id == materiaAModificar.Id_plan)
                {
                    PlanComboBox.SelectedItem = plan.Descripcion;
                }
            }
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    MateriaDTO materiaModificada = EstablecerDatosMateriaAModificar();

                    await MateriaNegocio.Update(Materia.Id_materia, materiaModificada);
                }
                else
                {
                    Materia nuevaMateria = EstablecerDatosNuevaMateria();

                    await MateriaNegocio.Add(nuevaMateria);
                }

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

        private MateriaDTO EstablecerDatosMateriaAModificar()
        {
            int idPlanSeleccionado = ObtenerIdPlanSeleccionado();

            MateriaDTO materia = new MateriaDTO();

            materia.Desc_materia = DescripcionTextBox.Text;
            materia.Hs_semanales = Int32.Parse(HsSemanalesTextBox.Text);
            materia.Hs_totales = Int32.Parse(HsTotalesTextBox.Text);
            materia.Id_plan = idPlanSeleccionado;

            return materia;
        }

        private Materia EstablecerDatosNuevaMateria()
        {
            int idPlanSeleccionado = ObtenerIdPlanSeleccionado();

            Materia materia = new Materia(DescripcionTextBox.Text, Int32.Parse(HsSemanalesTextBox.Text), Int32.Parse(HsTotalesTextBox.Text), idPlanSeleccionado);

            return materia;
        }

        private int ObtenerIdPlanSeleccionado()
        {
            int idPlanSeleccionado = 0;

            // Buscar el Id del Plan que coincida con la Descripcion seleccionada
            foreach (var plan in this.Planes)
            {
                if (plan.Descripcion == PlanComboBox.SelectedValue.ToString())
                {
                    idPlanSeleccionado = plan.Id;
                }
            }

            return idPlanSeleccionado;
        }

        private List<string> ListadoNombresPlanes()
        {
            // Obtener solo los nombres de los planes
            List<string> listadoNombresPlanes = this.Planes.Select(plan => plan.Descripcion).ToList();

            // Ordenar la lista de nombres de los planes según su descripción
            listadoNombresPlanes.Sort();

            return listadoNombresPlanes;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}