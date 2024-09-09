namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public MateriaController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetMateria")]
        public ActionResult<IEnumerable<Materia>> GetAll()
        {
            return _context.Materias.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Materia> GetById(int id)
        {
            var Materia = _context.Materias.Find(id);

            if (Materia == null)
            {
                return NotFound();
            }

            return Materia;
        }

        [HttpPost]
        public ActionResult<Materia> Create(MateriaDTO materiaDTO)
        {
            Materia nuevaMateria = new Materia(materiaDTO.Desc_materia, materiaDTO.Hs_semanales, materiaDTO.Hs_totales, materiaDTO.Id_plan);

            _context.Materias.Add(nuevaMateria);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = nuevaMateria.Id_materia }, nuevaMateria);
        }

        [HttpPatch("{id}")]
        public ActionResult<Materia> Update(int id, [FromBody] MateriaDTO materiaDTO)
        {
            var Materia = _context.Materias.Find(id);

            if (Materia == null)
            {
                return NotFound();
            }

            Materia.Desc_materia = materiaDTO.Desc_materia;
            Materia.Hs_semanales = materiaDTO.Hs_semanales;
            Materia.Hs_totales = materiaDTO.Hs_totales;
            Materia.Id_plan = materiaDTO.Id_plan;

            _context.Entry(Materia).State = EntityState.Modified;
            _context.SaveChanges();

            return Materia;
        }


        [HttpDelete("{id}")]
        public ActionResult<Materia> Delete(int id)
        {
            var Materia = _context.Materias.Find(id);
            if (Materia == null)
            {
                return NotFound();
            }

            _context.Materias.Remove(Materia);
            _context.SaveChanges();

            return Materia;
        }

    }
}