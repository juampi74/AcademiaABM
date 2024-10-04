namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Datos;
    using Entidades;
    using System.Linq.Expressions;

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
            return _context.Cursos
                .Include(cur => cur.Comision)
                .Include(cur => cur.Materia)
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Curso> GetById(int id)
        {
            var Curso = _context.Cursos.Find(id);

            if (Curso == null)
            {
                return NotFound();
            }

            return Curso;
        }

        [HttpPost]
        public ActionResult<Curso> Create(CursoDTO cursoDTO)
        {
            Curso nuevoCurso = new Curso(cursoDTO.Anio_calendario, cursoDTO.Cupo, cursoDTO.Id_comision, cursoDTO.Id_materia);

            _context.Cursos.Add(nuevoCurso);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = nuevoCurso.Id_curso }, nuevoCurso);
        }

        [HttpPatch("{id}")]
        public ActionResult<Curso> Update(int id, [FromBody] CursoDTO cursoDTO)
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
                return BadRequest();
            }
        }
    }
}