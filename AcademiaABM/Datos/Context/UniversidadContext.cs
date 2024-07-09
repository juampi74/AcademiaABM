namespace AcademiaABM.Datos.Context
{
    using AcademiaABM.Negocio.Entidades;
    using Microsoft.EntityFrameworkCore;

    public class UniversidadContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                            .HasKey(a => a.Id);

            modelBuilder.Entity<Alumno>()
                            .Property(b => b.Telefono)
                            .IsRequired(false);

            modelBuilder.Entity<Usuario>()
                            .HasKey(c => c.Id);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura la cadena de conexión a SQL Server
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-I6LRHO6\SQLEXPRESS;Initial Catalog=universidad;Integrated Security=true;Encrypt=False;Connection Timeout=5");
        }
        public UniversidadContext()
        {
            // Asegura que la base de datos se cree si no existe
            Database.EnsureCreated();
        }

    }
}