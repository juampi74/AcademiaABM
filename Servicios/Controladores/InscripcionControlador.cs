namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class InscripcionController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public InscripcionController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetInscripcion")]
        public ActionResult<IEnumerable<Alumno_Inscripcion>> GetAll()
        {
            try
            {
                return _context.Alumnos_Inscripciones
                    .Include(insc => insc.Alumno)
                    .Include(insc => insc.Curso)
                        .ThenInclude(cur => cur.Comision)
                    .Include(insc => insc.Curso)
                        .ThenInclude(cur => cur.Materia)
                    .ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Alumno_Inscripcion> GetById(int id)
        {
            try
            {
                var Inscripcion = _context.Alumnos_Inscripciones
                                .Include(i => i.Alumno)
                                .Include(i => i.Curso)
                                .FirstOrDefault(i => i.Id_inscripcion == id);

                if (Inscripcion == null)
                {
                    return NotFound();
                }

                return Inscripcion;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpPost]
        public ActionResult<Alumno_Inscripcion> Create(Alumno_InscripcionDTO inscripcionDTO)
        {
            try
            {
                Alumno_Inscripcion nuevaInscripcion = new Alumno_Inscripcion(inscripcionDTO.Condicion, inscripcionDTO.Nota, inscripcionDTO.Id_alumno, inscripcionDTO.Id_curso);

                var id_materia = _context.Cursos
                    .Include(cur => cur.Materia)
                    .FirstOrDefault(cur => cur.Id_curso == nuevaInscripcion.Id_curso)?.Materia.Id_materia;

                var existeInscripcion = _context.Alumnos_Inscripciones
                    .Include(ins => ins.Curso)
                        .ThenInclude(curso => curso.Materia)
                    .Any(ins => ins.Id_alumno == nuevaInscripcion.Id_alumno
                             && ins.Curso.Materia.Id_materia == id_materia
                             && ins.Condicion != "Libre");


                if (existeInscripcion)
                {
                    return StatusCode(StatusCodes.Status409Conflict, "El alumno ya se inscribió a la materia");
                }

                var Curso = _context.Cursos.Find(nuevaInscripcion.Id_curso);

                if (Curso == null || Curso.Cupo == 0)
                {
                    return StatusCode(StatusCodes.Status409Conflict, "El curso no tiene más cupos disponibles");
                }

                Curso.Cupo = Curso.Cupo - 1;

                _context.Alumnos_Inscripciones.Add(nuevaInscripcion);
                _context.Entry(Curso).State = EntityState.Modified;

                _context.SaveChanges();

                return CreatedAtAction("GetById", new { id = nuevaInscripcion.Id_inscripcion }, nuevaInscripcion);

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
        public ActionResult<Alumno_Inscripcion> Update(int id, [FromBody] Alumno_InscripcionDTO inscripcionDTO)
        {
            try
            {
                var Inscripcion = _context.Alumnos_Inscripciones.Find(id);

                if (Inscripcion == null)
                {
                    return NotFound();
                }

                Inscripcion.Condicion = inscripcionDTO.Condicion;
                Inscripcion.Nota = inscripcionDTO.Nota;
                Inscripcion.Id_alumno = inscripcionDTO.Id_alumno;
                Inscripcion.Id_curso = inscripcionDTO.Id_curso;

                _context.Entry(Inscripcion).State = EntityState.Modified;
                _context.SaveChanges();

                return Inscripcion;
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
        public ActionResult<Alumno_Inscripcion> Delete(int id)
        {
            try
            {
                var Inscripcion = _context.Alumnos_Inscripciones.Find(id);
                if (Inscripcion == null)
                {
                    return NotFound();
                }

                _context.Alumnos_Inscripciones.Remove(Inscripcion);
                _context.SaveChanges();

                return Inscripcion;
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

        [HttpGet("Alumno/{id_persona}")]
        public ActionResult<IEnumerable<Alumno_Inscripcion>> GetInscripcionesPorAlumno(string id_persona)
        {
            try
            {
                int id_persona_int = int.Parse(id_persona);

                return _context.Alumnos_Inscripciones
                            .Include(ins => ins.Alumno)
                            .Include(ins => ins.Curso)
                                .ThenInclude(cur => cur.Comision)
                            .Include(ins => ins.Curso)
                                .ThenInclude(cur => cur.Materia)
                            .Where(ins => ins.Id_alumno == id_persona_int)
                            .ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }

        [HttpGet("Docente/{id_persona}")]
        public ActionResult<IEnumerable<Alumno_Inscripcion>> GetInscripcionesCursosDocente(string id_persona)
        {
            try
            {
                int id_persona_int = int.Parse(id_persona);

                var dictadosDocente = _context.Docentes_cursos
                                          .Include(dic => dic.Curso)
                                          .Where(dic => dic.Id_docente == id_persona_int)
                                          .ToList();

                var cursosDocenteIDs = dictadosDocente.Select(dic => dic.Curso.Id_curso).ToList();

                return _context.Alumnos_Inscripciones
                            .Include(ins => ins.Alumno)
                            .Include(ins => ins.Curso)
                                .ThenInclude(cur => cur.Comision)
                            .Include(ins => ins.Curso)
                                .ThenInclude(cur => cur.Materia)
                            .Where(ins => cursosDocenteIDs.Contains(ins.Curso.Id_curso))
                            .ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}