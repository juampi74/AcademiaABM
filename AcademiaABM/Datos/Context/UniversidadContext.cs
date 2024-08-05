namespace AcademiaABM.Datos.Context
{
    using AcademiaABM.Negocio.Entidades;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UniversidadContext : DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comision> Comisiones { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                            .HasKey(a => a.Id);

            modelBuilder.Entity<Alumno>()
                            .Property(b => b.Telefono)
                            .IsRequired(false);

            modelBuilder.Entity<Usuario>()
                            .HasKey(c => c.Id);

            modelBuilder.Entity<Comision>()
                            .HasKey(a => a.Id_comision);

            modelBuilder.Entity<Curso>()
                            .HasKey(a => a.Id_curso);

            // Relación 1:N entre Comision y Curso
            modelBuilder.Entity<Curso>()
                .HasOne(com => com.Comision)
                .WithMany(curs => curs.Cursos)
                .HasForeignKey(com => com.Id_comision);

            // El método Include en Entity Framework se utiliza para especificar las entidades
            // relacionadas que deben cargarse junto con la entidad principal.
            // var cursoConComision = context.Cursos
            // .Include(c => c.Comision)  // Incluye la entidad relacionada Comision
            // .FirstOrDefault(c => c.Id == cursoId);  // Devuelve el primer Curso que coincide
            //                                            con el Id especificado o null

            // base.OnModelCreating(modelBuilder);
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