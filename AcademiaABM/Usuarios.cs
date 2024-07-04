namespace AcademiaABM
{
    using Clases;
    using System.Windows.Forms;

    public partial class Usuarios : Form
    {

        List<Usuario> listadoUsuarios = new List<Usuario>();

        public Usuarios()
        {
            InitializeComponent();
            Listar();
        }

        public void Listar()
        {
            listadoUsuarios.Add(new Usuario(45638464, "Nahuel Berli", "22/04/2004"));
            listadoUsuarios.Add(new Usuario(45656433, "Juan Pablo Jaca", "07/04/2004"));
            listadoUsuarios.Add(new Usuario(43842278, "Marcos Godoy", "09/08/2002"));
            listadoUsuarios.Add(new Usuario(46787213, "Juan Perez", "21/02/2005"));

            dgvUsuarios.AutoGenerateColumns = true;
            dgvUsuarios.DataSource = listadoUsuarios;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
