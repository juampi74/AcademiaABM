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
            return _context.Docentes_cursos.ToList();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Docente_Curso> GetById(int id)
        {
            var Dictado = _context.Docentes_cursos.Find(id);

            if (Dictado == null)
            {
                return NotFound();
            }

            return Dictado;
        }

        [HttpPost]
        public ActionResult<Docente_Curso> Create(Docente_CursoDTO dictadoDTO)
        {
            Docente_Curso nuevoDictado = new Docente_Curso(dictadoDTO.Cargo, dictadoDTO.Id_docente, dictadoDTO.Id_curso);

            _context.Docentes_cursos.Add(nuevoDictado);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = nuevoDictado.Id_dictado }, nuevoDictado);
        }

        [HttpPatch("{id}")]
        public ActionResult<Docente_Curso> Update(int id, [FromBody] Docente_CursoDTO dictadoDTO)
        {
            var Dictado = _context.Docentes_cursos.Find(id);

            if (Dictado  == null)
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


        [HttpDelete("{id}")]
        public ActionResult<Docente_Curso> Delete(int id)
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

    }
}