namespace AcademiaABM.Negocio.Servicios
{
    using AcademiaABM.Datos.Repositorios;
    using AcademiaABM.Negocio.Entidades;

    public class MateriaService
    {
        private readonly MateriaRepository _materiaRepository;

        public MateriaService()
        {
            _materiaRepository = new MateriaRepository();
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            return _materiaRepository.ObtenerTodasLasMaterias();
        }

        public Materia ObtenerMateriaPorId(int id)
        {
            return _materiaRepository.ObtenerMateriaPorId(id);
        }

        public void CrearMateria(Materia materia)
        {
            _materiaRepository.CrearMateria(materia);
        }

        public void ActualizarMateria(Materia materia)
        {
            _materiaRepository.ActualizarMateria(materia);
        }

        public void EliminarMateria(int id)
        {
            _materiaRepository.EliminarMateria(id);
        }

        public List<Materia> OrdenarMateriasAscendente()
        {
            return _materiaRepository.OrdenarMateriasAscendente();
        }

        public List<Materia> OrdenarMateriasDescendente()
        {
            return _materiaRepository.OrdenarMateriasAscendente();
        }
    }
}
