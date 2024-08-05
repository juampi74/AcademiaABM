namespace AcademiaABM.Negocio.Entidades
{
    public class Alumno
    {
        private int id;
        private string apellido;
        private string nombre;
        private int legajo;
        private string direccion;
        private string telefono;

        public Alumno(string apellido, string nombre, int legajo, string direccion, string telefono)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.legajo = legajo;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }
}