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
            return _context.Alumnos_Inscripciones
                .Include(insc => insc.Alumno)
                .Include(insc => insc.Curso)
                    .ThenInclude(cur => cur.Comision)
                .Include(insc => insc.Curso)
                    .ThenInclude(cur => cur.Materia)
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Alumno_Inscripcion> GetById(int id)
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

        [HttpPost]
        public ActionResult<Alumno_Inscripcion> Create(Alumno_InscripcionDTO inscripcionDTO)
        {
            Alumno_Inscripcion nuevaInscripcion = new Alumno_Inscripcion(inscripcionDTO.Condicion, inscripcionDTO.Nota, inscripcionDTO.Id_alumno, inscripcionDTO.Id_curso);

            _context.Alumnos_Inscripciones.Add(nuevaInscripcion);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = nuevaInscripcion.Id_inscripcion }, nuevaInscripcion);
        }

        [HttpPatch("{id}")]
        public ActionResult<Alumno_Inscripcion> Update(int id, [FromBody] Alumno_InscripcionDTO inscripcionDTO)
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
                return BadRequest();
            }
        }
    }
}