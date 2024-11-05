namespace AcademiaABM.Negocio.Servicios
{
    using AcademiaABM.Datos.Repositorios;
    using AcademiaABM.Negocio.Entidades;

    public class PlanService
    {
        private readonly PlanRepository _planRepository;

        public PlanService()
        {
            _planRepository = new PlanRepository();
        }

        public List<Plan> ObtenerTodosLosPlanes()
        {
            return _planRepository.ObtenerTodosLosPlanes();
        }

        public Plan ObtenerPlanPorId(int id)
        {
            return _planRepository.ObtenerPlanPorId(id);
        }

        public void CrearPlan(Plan plan)
        {
            _planRepository.CrearPlan(plan);
        }

        public void ActualizarPlan(Plan plan)
        {
            _planRepository.ActualizarPlan(plan);
        }

        public void EliminarPlan(int id)
        {
            _planRepository.EliminarPlan(id);
        }

        public List<Plan> OrdenarPlanesAscendente()
        {
            return _planRepository.OrdenarPlanesAscendente();
        }

        public List<Plan> OrdenarPlanesDescendente()
        {
            return _planRepository.OrdenarPlanesDescendente();
        }
    }
}
