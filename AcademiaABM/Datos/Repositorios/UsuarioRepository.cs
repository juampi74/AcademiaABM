namespace AcademiaABM.Datos.Repositorios
{
    using AcademiaABM.Datos.Context;
    using AcademiaABM.Negocio.Entidades;

    public class UsuarioRepository
    {
        private readonly UniversidadContext _context;

        public UsuarioRepository()
        {
            _context = new UniversidadContext();
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return _context.Usuarios.ToList();
        }
    }
}
