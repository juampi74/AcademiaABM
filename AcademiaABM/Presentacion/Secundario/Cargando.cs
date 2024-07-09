namespace AcademiaABM.Presentacion
{
    public partial class Cargando : Form
    {
        public Cargando()
        {
            InitializeComponent();
        }

        public void Show(Form parent)
        {
            base.Show(parent);
            this.CenterToParent();
        }
    }
}
