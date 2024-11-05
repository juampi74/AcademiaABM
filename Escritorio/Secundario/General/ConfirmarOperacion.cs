namespace Escritorio
{
    public partial class ConfirmarOperacion : Form
    {
        public ConfirmarOperacion()
        {
            InitializeComponent();
        }

        private void ConfirmarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}