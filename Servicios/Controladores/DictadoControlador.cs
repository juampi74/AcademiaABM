namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class DictadoController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public DictadoController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetDictado")]
        public ActionResult<IEnumerable<Docente_Curso>> GetAll()
        {
            try
            {
                return _context.Docentes_cursos
                    .Include(dic => dic.Docente)
                    .Include(dic => dic.Curso)
                        .ThenInclude(dic => dic.Comision)
                    .Include(dic => dic.Curso)
                        .ThenInclude(dic => dic.Materia)
                    .ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Docente_Curso> GetById(int id)
        {
            try
            {
                var Dictado = _context.Docentes_cursos.Find(id);

                if (Dictado == null)
                {
                    return NotFound();
                }

                return Dictado;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost]
        public ActionResult<Docente_Curso> Create(Docente_CursoDTO dictadoDTO)
        {
            try
            {
                Docente_Curso nuevoDictado = new Docente_Curso(dictadoDTO.Cargo, dictadoDTO.Id_docente, dictadoDTO.Id_curso);

                var existeDictado = _context.Docentes_cursos
                    .Any(dic => dic.Id_docente == nuevoDictado.Id_docente
                             && dic.Id_curso == nuevoDictado.Id_curso);

                if (existeDictado)
                {
                    return StatusCode(StatusCodes.Status409Conflict, "El docente ya fue asignado al curso");
                }

                _context.Docentes_cursos.Add(nuevoDictado);
                _context.SaveChanges();

                return CreatedAtAction("GetById", new { id = nuevoDictado.Id_dictado }, nuevoDictado);

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
        public ActionResult<Docente_Curso> Update(int id, [FromBody] Docente_CursoDTO dictadoDTO)
        {
            try
            {
                var Dictado = _context.Docentes_cursos.Find(id);

                if (Dictado == null)
                {
                    return NotFound();
                }

                Dictado.Cargo = dictadoDTO.Cargo;
                Dictado.Id_docente = dictadoDTO.Id_docente;
                Dictado.Id_curso = dictadoDTO.Id_curso;

                _context.Entry(Dictado).State = EntityState.Modified;
                _context.SaveChanges();

                return Dictado;

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
        public ActionResult<Docente_Curso> Delete(int id)
        {
            try
            {
                var Dictado = _context.Docentes_cursos.Find(id);
                if (Dictado == null)
                {
                    return NotFound();
                }

                _context.Docentes_cursos.Remove(Dictado);
                _context.SaveChanges();

                return Dictado;
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