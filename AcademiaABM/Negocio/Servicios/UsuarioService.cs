namespace AcademiaABM.Negocio.Servicios
{
    using AcademiaABM.Datos.Repositorios;
    using AcademiaABM.Negocio.Entidades;

    public class UsuarioService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return _usuarioRepository.ObtenerTodosLosUsuarios();
        }

        public bool ComprobarUsuarioIngresado(List<Usuario> listadoUsuarios, string nombreUsuario, string contrasenia)
        {
            foreach (var usuario in listadoUsuarios)
            {
                if (usuario.Nombre_usuario == nombreUsuario && usuario.Contrasenia_usuario == contrasenia)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
