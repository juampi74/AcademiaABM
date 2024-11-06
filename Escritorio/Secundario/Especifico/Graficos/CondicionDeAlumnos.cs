namespace Escritorio
{
    using OxyPlot;
    using OxyPlot.Series;
    
    public partial class CondicionDeAlumnos : Form
    {
        private Dictionary<string, int> condicionAlumnos;

        public CondicionDeAlumnos(Dictionary<string, int> condicionAlumnos)
        {
            InitializeComponent();
            
            this.condicionAlumnos = condicionAlumnos;

            InicializarGrafico();
        }

        private void InicializarGrafico()
        {
            var plotModel = new PlotModel
            {
                Background = OxyColor.FromArgb(255, 240, 240, 240)
            };

            var pieSeries = new PieSeries
            {
                InsideLabelPosition = 0.55,
                StrokeThickness = 1,
                Stroke = OxyColors.Black,
            };

            List<OxyColor> colores = new List<OxyColor>
            {
                OxyColor.FromArgb(210, 8, 23, 61),
                OxyColor.FromArgb(210, 15, 32, 97),
                OxyColor.FromArgb(210, 25, 21, 88),
                OxyColor.FromArgb(210, 45, 11, 78),
                OxyColor.FromArgb(210, 57, 6, 71),
                OxyColor.FromArgb(210, 57, 5, 70),
                OxyColor.FromArgb(210, 58, 6, 71)
            };

            var datos = new List<(string condicion, int cant_inscripciones)>();

            foreach (var item in this.condicionAlumnos)
            {
                datos.Add((item.Key, item.Value));
            }

            for (int i = 0; i < datos.Count; i++)
            {
                pieSeries.Slices.Add(new PieSlice(datos[i].condicion, datos[i].cant_inscripciones)
                {
                    Fill = colores[i % colores.Count]
                });
            }

            plotModel.Series.Add(pieSeries);
            plot.Model = plotModel;
        }
    }
}