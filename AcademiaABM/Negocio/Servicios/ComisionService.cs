namespace AcademiaABM.Negocio.Servicios
{
    using AcademiaABM.Datos.Repositorios;
    using AcademiaABM.Negocio.Entidades;

    public class ComisionService
    {
        private readonly ComisionRepository _comisionRepository;

        public ComisionService()
        {
            _comisionRepository = new ComisionRepository();
        }

        public List<Comision> ObtenerTodasLasComisiones()
        {
            return _comisionRepository.ObtenerTodasLasComisiones();
        }

        public Comision ObtenerComisionPorId(int id)
        {
            return _comisionRepository.ObtenerComisionPorId(id);
        }

        public void CrearComision(Comision comision)
        {
            _comisionRepository.CrearComision(comision);
        }

        public void ActualizarComision(Comision comision)
        {
            _comisionRepository.ActualizarComision(comision);
        }

        public void EliminarComision(int id)
        {
            _comisionRepository.EliminarComision(id);
        }

        public List<Comision> OrdenarComisionesAscendente()
        {
            return _comisionRepository.OrdenarComisionesAscendente();
        }

        public List<Comision> OrdenarComisionesDescendente()
        {
            return _comisionRepository.OrdenarComisionesDescendente();
        }
    }
}

