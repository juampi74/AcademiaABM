namespace Clases
{
    public class Usuario
    {
        private int dni;
        private string nombreApellido;
        private string fechaNacimiento;

        public Usuario(int dni, string nombreApellido, string fechaNacimiento)
        {
            this.dni = dni;
            this.nombreApellido = nombreApellido;
            this.fechaNacimiento = fechaNacimiento;
        }
        public int Dni
        {
            get { return dni; }
            set { this.dni = value; }
        }
        public string NombreApellido
        {
            get { return nombreApellido; }
            set { this.nombreApellido = value; }
        }
        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { this.fechaNacimiento = value; }
        }
    }
}
