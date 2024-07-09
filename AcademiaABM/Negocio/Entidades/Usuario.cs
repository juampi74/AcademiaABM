namespace AcademiaABM.Negocio.Entidades
{
    public class Usuario
    {
        private int id;
        private string nombre_usuario;
        private string contrasenia_usuario;

        public Usuario(string nombre_usuario, string contrasenia_usuario)
        {
            this.nombre_usuario = nombre_usuario;
            this.contrasenia_usuario = contrasenia_usuario;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre_usuario
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }
        public string Contrasenia_usuario
        {
            get { return contrasenia_usuario; }
            set { contrasenia_usuario = value; }
        }
    }
}