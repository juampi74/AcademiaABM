namespace AcademiaABM.Datos.Repositorios
{
    using AcademiaABM.Datos.Context;
    using AcademiaABM.Negocio.Entidades;

    public class MateriaRepository
    {
        private readonly UniversidadContext _context;

        public MateriaRepository()
        {
            _context = new UniversidadContext();
        }

        public List<Materia> ObtenerTodasLasMaterias()
        {
            return _context.Materias.ToList();

        }

        public Materia ObtenerMateriaPorId(int id)
        {
            return _context.Materias.Find(id);
        }

        public void CrearMateria(Materia materia)
        {
            _context.Materias.Add(materia);
            _context.SaveChanges();
        }

        public void ActualizarMateria(Materia materia)
        {
            var materiaExistente = _context.Materias.Find(materia.Id_materia);
            if (materiaExistente != null)
            {
                materiaExistente.Id_materia = materia.Id_materia;
                materiaExistente.Desc_materia = materia.Desc_materia;
                materiaExistente.Hs_semanales = materia.Hs_semanales;
                materiaExistente.Hs_totales = materia.Hs_totales;
                materiaExistente.Id_plan = materia.Id_plan;
                _context.SaveChanges();
            }
        }

        public void EliminarMateria(int id)
        {
            var materia = _context.Materias.Find(id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
                _context.SaveChanges();
            }
        }

        public List<Materia> OrdenarMateriasAscendente()
        {
            return _context.Materias.OrderBy(mat => mat.Desc_materia).ThenBy(mat => mat.Hs_semanales).ToList();
        }

        public List<Materia> OrdenarMateriasDescendente()
        {
            return _context.Materias.OrderByDescending(mat => mat.Desc_materia).ThenByDescending(mat => mat.Hs_semanales).ToList();
        }
    }
}