namespace AcademiaABM.Datos.Repositorios
{
    using AcademiaABM.Datos.Context;
    using AcademiaABM.Negocio.Entidades;

    public class PlanRepository
    {
        private readonly UniversidadContext _context;

        public PlanRepository()
        {
            _context = new UniversidadContext();
        }

        public List<Plan> ObtenerTodosLosPlanes()
        {
            return _context.Planes.ToList();

        }

        public Plan ObtenerPlanPorId(int id)
        {
            return _context.Planes.Find(id);
        }

        public void CrearPlan(Plan plan)
        {
            _context.Planes.Add(plan);
            _context.SaveChanges();
        }

        public void ActualizarPlan(Plan plan)
        {
            var planExistente = _context.Planes.Find(plan.Id_plan);
            if (planExistente != null)
            {
                planExistente.Id_plan = plan.Id_plan;
                planExistente.Desc_plan = plan.Desc_plan;
                planExistente.Id_especialidad = plan.Id_especialidad;
                _context.SaveChanges();
            }
        }

        public void EliminarPlan(int id)
        {
            var plan = _context.Planes.Find(id);
            if (plan != null)
            {
                _context.Planes.Remove(plan);
                _context.SaveChanges();
            }
        }

        public List<Plan> OrdenarPlanesAscendente()
        {
            return _context.Planes.OrderBy(pla => pla.Desc_plan).ToList();
        }

        public List<Plan> OrdenarPlanesDescendente()
        {
            return _context.Planes.OrderByDescending(pla => pla.Desc_plan).ToList();
        }
    }
}
