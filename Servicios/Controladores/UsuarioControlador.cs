namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public UsuarioController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetUsuario")]
        public ActionResult<IEnumerable<Usuario>> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var Usuario = _context.Usuarios.Find(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> Create(UsuarioDTO usuarioDTO)
        {
            Usuario nuevoUsuario = new Usuario(usuarioDTO.Nombre_usuario, usuarioDTO.Clave, usuarioDTO.Habilitado, usuarioDTO.Cambia_clave, usuarioDTO.Id_persona);

            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = nuevoUsuario.Id_usuario }, nuevoUsuario);
        }

        [HttpPatch("{id}")]
        public ActionResult<Usuario> Update(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            var Usuario = _context.Usuarios.Find(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            Usuario.Nombre_usuario = usuarioDTO.Nombre_usuario;
            Usuario.Clave = usuarioDTO.Clave;
            Usuario.Habilitado = usuarioDTO.Habilitado;
            Usuario.Cambia_clave = usuarioDTO.Cambia_clave;
            Usuario.Id_persona = usuarioDTO.Id_persona;

            _context.Entry(Usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return Usuario;
        }


        [HttpDelete("{id}")]
        public ActionResult<Usuario> Delete(int id)
        {
            var Usuario = _context.Usuarios.Find(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(Usuario);
            _context.SaveChanges();

            return Usuario;
        }

    }
}