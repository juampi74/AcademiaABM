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
            try
            {
                return _context.Usuarios
                    .Include(usu => usu.Persona)
                    .ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            try
            {
                var Usuario = _context.Usuarios.Find(id);

                if (Usuario == null)
                {
                    return NotFound();
                }

                return Usuario;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost]
        public ActionResult<Usuario> Create(UsuarioDTO usuarioDTO)
        {
            try
            {
                Usuario nuevoUsuario = new Usuario(usuarioDTO.Nombre_usuario, usuarioDTO.Clave, usuarioDTO.Habilitado, usuarioDTO.Cambia_clave, usuarioDTO.Id_persona);

                _context.Usuarios.Add(nuevoUsuario);
                _context.SaveChanges();

                return CreatedAtAction("GetById", new { id = nuevoUsuario.Id_usuario }, nuevoUsuario);

            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPatch("{id}")]
        public ActionResult<Usuario> Update(int id, [FromBody] UsuarioDTO usuarioDTO)
        {
            try
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
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Usuario> Delete(int id)
        {
            try
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
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}