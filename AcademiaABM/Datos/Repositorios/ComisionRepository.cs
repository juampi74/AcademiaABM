namespace AcademiaABM.Datos.Repositorios
{
    using AcademiaABM.Datos.Context;
    using AcademiaABM.Negocio.Entidades;

    public class ComisionRepository
    {
        private readonly UniversidadContext _context;

        public ComisionRepository()
        {
            _context = new UniversidadContext();
        }

        public List<Comision> ObtenerTodasLasComisiones()
        {
            return _context.Comisiones.ToList();
        }

        public Comision ObtenerComisionPorId(int id)
        {
            return _context.Comisiones.Find(id);
        }

        public void CrearComision(Comision comision)
        {
            _context.Comisiones.Add(comision);
            _context.SaveChanges();
        }

        public void ActualizarComision(Comision comision)
        {
            var comisionExistente = _context.Comisiones.Find(comision.Id_comision);
            if (comisionExistente != null)
            {
                comisionExistente.Desc_comision = comision.Desc_comision;
                comisionExistente.Anio_especialidad = comision.Anio_especialidad;
                _context.SaveChanges();
            }
        }

        public void EliminarComision(int id)
        {
            var comision = _context.Comisiones.Find(id);
            if (comision != null)
            {
                _context.Comisiones.Remove(comision);
                _context.SaveChanges();
            }
        }

        public List<Comision> OrdenarComisionesAscendente()
        {
            return _context.Comisiones.OrderBy(a => a.Desc_comision).ThenBy(a => a.Anio_especialidad).ToList();
        }

        public List<Comision> OrdenarComisionesDescendente()
        {
            return _context.Comisiones.OrderByDescending(a => a.Desc_comision).ThenByDescending(a => a.Anio_especialidad).ToList();
        }
    }
}
