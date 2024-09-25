namespace Servicios
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Datos;
    using Entidades;

    [ApiController]
    [Route("api/[controller]")]
    public class PlanController : ControllerBase
    {
        private readonly UniversidadContext _context;

        public PlanController(UniversidadContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetPlan")]
        public ActionResult<IEnumerable<Plan>> GetAll()
        {
            return _context.Planes
                .Include(plan => plan.Especialidad)
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Plan> GetById(int id)
        {
            var Plan = _context.Planes.Find(id);

            if (Plan == null)
            {
                return NotFound();
            }

            return Plan;
        }

        [HttpPost]
        public ActionResult<Plan> Create(PlanDTO planDTO)
        {
            Plan nuevoPlan = new Plan(planDTO.Desc_plan, planDTO.Id_especialidad);

            _context.Planes.Add(nuevoPlan);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new { id = nuevoPlan.Id_plan }, nuevoPlan);
        }

        [HttpPatch("{id}")]
        public ActionResult<Plan> Update(int id, [FromBody] PlanDTO planDTO)
        {
            var Plan = _context.Planes.Find(id);

            if (Plan == null)
            {
                return NotFound();
            }

            Plan.Desc_plan = planDTO.Desc_plan;
            Plan.Id_especialidad = planDTO.Id_especialidad;

            _context.Entry(Plan).State = EntityState.Modified;
            _context.SaveChanges();

            return Plan;
        }


        [HttpDelete("{id}")]
        public ActionResult<Plan> Delete(int id)
        {
            var Plan = _context.Planes.Find(id);
            if (Plan == null)
            {
                return NotFound();
            }

            _context.Planes.Remove(Plan);
            _context.SaveChanges();

            return Plan;
        }

    }
}