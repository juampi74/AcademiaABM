﻿namespace Escritorio
{
    using Entidades;
    using Negocio;

    public partial class PlanUI : Form
    {
        public Plan Plan { get; set; }

        private List<(int Id, string Descripcion)> Especialidades;

        public PlanUI(List<(int Id, string Descripcion)> especialidades)
        {
            InitializeComponent();

            TituloLabel.Text = "Nuevo Plan";
            GuardarButton.Text = "Crear";

            this.Especialidades = especialidades;

            List<string> listadoEspecialidades = ListadoNombresEspecialidades();

            EspecialidadComboBox.DataSource = listadoEspecialidades;
        }

        public PlanUI(List<(int Id, string Descripcion)> especialidades, Plan planAModificar)
        {
            InitializeComponent();

            TituloLabel.Text = "Editar Plan";
            GuardarButton.Text = "Modificar";

            this.Especialidades = especialidades;

            this.Plan = planAModificar;

            DescPlanTextBox.Text = planAModificar.Desc_plan;

            EspecialidadComboBox.DataSource = ListadoNombresEspecialidades();

            foreach (var especialidad in this.Especialidades)
            {
                if (especialidad.Id == planAModificar.Id_especialidad)
                {
                    EspecialidadComboBox.SelectedItem = especialidad.Descripcion;
                }
            }
        }

        private async void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ComprobarCamposRequeridos())
            {
                if (GuardarButton.Text == "Modificar")
                {
                    PlanDTO planModificado = EstablecerDatosPlanAModificar();

                    await PlanNegocio.Update(Plan.Id_plan, planModificado);
                }
                else
                {
                    Plan nuevoPlan = EstablecerDatosNuevoPlan();

                    await PlanNegocio.Add(nuevoPlan);
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

        private PlanDTO EstablecerDatosPlanAModificar()
        {
            int idEspecialidadSeleccionada = ObtenerIdEspecialidadSeleccionada();

            PlanDTO plan = new PlanDTO();

            plan.Desc_plan = DescPlanTextBox.Text;
            plan.Id_especialidad = idEspecialidadSeleccionada;

            return plan;
        }

        private Plan EstablecerDatosNuevoPlan()
        {
            int idEspecialidadSeleccionada = ObtenerIdEspecialidadSeleccionada();

            Plan plan = new Plan(DescPlanTextBox.Text, idEspecialidadSeleccionada);

            return plan;
        }

        private int ObtenerIdEspecialidadSeleccionada()
        {
            int idEspecialidadSeleccionada = 0;

            // Buscar el Id de la Especialidad que coincida con la Descripcion seleccionada
            foreach (var especialidad in this.Especialidades)
            {
                if (especialidad.Descripcion == EspecialidadComboBox.SelectedValue.ToString())
                {
                    idEspecialidadSeleccionada = especialidad.Id;
                }
            }

            return idEspecialidadSeleccionada;
        }

        private List<string> ListadoNombresEspecialidades()
        {
            // Obtener solo los nombres de las especialidades
            List<string> listadoNombresEspecialidades = this.Especialidades.Select(plan => plan.Descripcion).ToList();

            // Ordenar la lista de nombres de las especialidades según su descripción
            listadoNombresEspecialidades.Sort();

            return listadoNombresEspecialidades;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}