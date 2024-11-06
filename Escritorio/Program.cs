namespace Escritorio
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Login login = new Login();

            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Grilla(login.usuarioAutenticado));
            }
        }
    }
}