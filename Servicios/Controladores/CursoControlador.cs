namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public CursoController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetCurso")]
        public ActionResult<IEnumerable<Curso>> GetAll()
        {
            try
            {
                return _context.Cursos
                    .Include(cur => cur.Comision)
                    .Include(cur => cur.Materia)
                    .ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Curso> GetById(int id)
        {
            try
            {
                var Curso = _context.Cursos.Find(id);

                if (Curso == null)
                {
                    return NotFound();
                }

                return Curso;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost]
        public ActionResult<Curso> Create(CursoDTO cursoDTO)
        {
            try
            {
                Curso nuevoCurso = new Curso(cursoDTO.Anio_calendario, cursoDTO.Cupo, cursoDTO.Id_comision, cursoDTO.Id_materia);

                _context.Cursos.Add(nuevoCurso);
                _context.SaveChanges();

                return CreatedAtAction("GetById", new { id = nuevoCurso.Id_curso }, nuevoCurso);
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
        public ActionResult<Curso> Update(int id, [FromBody] CursoDTO cursoDTO)
        {
            try
            {
                var Curso = _context.Cursos.Find(id);

                if (Curso == null)
                {
                    return NotFound();
                }

                Curso.Anio_calendario = cursoDTO.Anio_calendario;
                Curso.Cupo = cursoDTO.Cupo;
                Curso.Id_comision = cursoDTO.Id_comision;
                Curso.Id_materia = cursoDTO.Id_materia;

                _context.Entry(Curso).State = EntityState.Modified;
                _context.SaveChanges();

                return Curso;
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
        public ActionResult<Curso> Delete(int id)
        {
            try
            {
                var Curso = _context.Cursos.Find(id);
                if (Curso == null)
                {
                    return NotFound();
                }

                _context.Cursos.Remove(Curso);
                _context.SaveChanges();

                return Curso;
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

        [HttpGet("Persona/{id_persona}")]
        public ActionResult<IEnumerable<Curso>> GetCursosParaPersona(string id_persona)
        {
            try
            {
                int id_persona_int = int.Parse(id_persona);

                int id_plan = _context.Personas.Find(id_persona_int).Id_plan;

                return _context.Cursos
                           .Include(cur => cur.Comision)
                           .Include(cur => cur.Materia)
                           .Where(cur => cur.Comision.Id_plan == id_plan)
                           .ToList();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}