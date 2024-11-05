namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Datos;
    using Entidades;

    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UniversidadContext _context;
        private readonly ILogger<UsuarioController> _logger; // Logger para el controlador

        public UsuarioController(UniversidadContext context, ILogger<UsuarioController> logger)
        {
            _context = context;
            _logger = logger;
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
                _logger.LogInformation("Valor de usuarioDTO.Id_persona: {IdPersona}", usuarioDTO.Id_persona);

                Usuario nuevoUsuario;

                if (usuarioDTO.Id_persona == 0 || usuarioDTO.Id_persona == null)
                {
                    // Se le asigna Rol 2 (Administrador)
                    nuevoUsuario = new Usuario(usuarioDTO.Nombre_usuario, usuarioDTO.Clave, usuarioDTO.Habilitado, usuarioDTO.Cambia_clave, 2);

                } else
                {
                    // Corresponde a un Alumno o a un Docente, y se le asigna el rol correpsondiente al Tipo_persona de la Persona asociada al Usuario
                    Persona persona = _context.Personas.Find(usuarioDTO.Id_persona);

                    nuevoUsuario = new Usuario(usuarioDTO.Nombre_usuario, usuarioDTO.Clave, usuarioDTO.Habilitado, usuarioDTO.Cambia_clave, persona.Tipo_persona, persona.Id_persona);
                }

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

                if (usuarioDTO.Id_persona != 0 && usuarioDTO.Id_persona != null)
                {
                    Usuario.Id_persona = usuarioDTO.Id_persona;
                }

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