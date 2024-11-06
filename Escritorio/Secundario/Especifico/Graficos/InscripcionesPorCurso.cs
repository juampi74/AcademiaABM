namespace Escritorio
{
    using OxyPlot;
    using OxyPlot.Series;
    using OxyPlot.Axes;

    public partial class InscripcionesPorCurso : Form
    {
        private Dictionary<string, int> inscripcionesPorCurso;

        public InscripcionesPorCurso(Dictionary<string, int> inscripcionesPorCurso)
        {
            InitializeComponent();
            
            this.inscripcionesPorCurso = inscripcionesPorCurso;
            
            InicializarGrafico();
        }

        private void InicializarGrafico()
        {
            var plotModel = new PlotModel
            {
                Background = OxyColor.FromArgb(255, 240, 240, 240)
            };

            var categoryAxis = new CategoryAxis
            {
                Position = AxisPosition.Left,
                Title = "Cursos"
            };
            categoryAxis.Labels.AddRange(this.inscripcionesPorCurso.Keys.ToArray());
            plotModel.Axes.Add(categoryAxis);

            var valueAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Cantidad de Inscripciones",
                MajorStep = 1,
                Minimum = 0,
                StringFormat = "0"
            };
            plotModel.Axes.Add(valueAxis);

            var barSeries = new BarSeries
            {
                Title = "Cantidad de Inscripciones:",
                ItemsSource = this.inscripcionesPorCurso.Select(insCur => new BarItem { Value = insCur.Value }).ToList(),
                FillColor = OxyColor.FromArgb(220, 7, 22, 60)
            };

            plotModel.Series.Add(barSeries);
            plot.Model = plotModel;
        }
    }
}