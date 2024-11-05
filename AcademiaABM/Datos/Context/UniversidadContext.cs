namespace AcademiaABM.Datos.Context
{
    using AcademiaABM.Negocio.Entidades;
    using Microsoft.EntityFrameworkCore;

    public class UniversidadContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Alumno_Inscripcion> Alumnos_Inscripciones { get; set; }
        public DbSet<Docente_Curso> Docentes_cursos { get; set; }

        public UniversidadContext(DbContextOptions<UniversidadContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno_Inscripcion>()
                            .HasKey(ai => ai.Id_inscripcion);
            
            modelBuilder.Entity<Comision>()
                .HasKey(com => com.Id_comision);

            modelBuilder.Entity<Curso>()
                            .HasKey(cur => cur.Id_curso);
            
            modelBuilder.Entity<Docente_Curso>()
                            .HasKey(dc => dc.Id_dictado);
            
            modelBuilder.Entity<Especialidad>()
                            .HasKey(esp => esp.Id_especialidad);
            
            modelBuilder.Entity<Materia>()
                            .HasKey(mat => mat.Id_materia);
            
            modelBuilder.Entity<Persona>()
                            .HasKey(per => per.Id_persona);
            
            modelBuilder.Entity<Plan>()
                            .HasKey(pla => pla.Id_plan);

            modelBuilder.Entity<Usuario>()
                            .HasKey(usu => usu.Id_usuario);

            // Relación 0:N entre Persona y Usuario (opcional)
            modelBuilder.Entity<Usuario>()
                .HasOne(usu => usu.Persona)
                .WithMany()
                .HasForeignKey(usu => usu.Id_persona)
                .OnDelete(DeleteBehavior.Restrict);
    
            // Relación 1:N entre Especialidad y Plan
            modelBuilder.Entity<Plan>()
                .HasOne(pla => pla.Especialidad)
                .WithMany()
                .HasForeignKey(pla => pla.Id_especialidad)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Plan y Persona
            modelBuilder.Entity<Persona>()
                .HasOne(per => per.Plan)
                .WithMany()
                .HasForeignKey(per => per.Id_plan)
                .OnDelete(DeleteBehavior.Restrict);
    
            // Relación 1:N entre Plan y Comision
            modelBuilder.Entity<Comision>()
                .HasOne(com => com.Plan)
                .WithMany()
                .HasForeignKey(com => com.Id_plan)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Comision y Curso
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.Comision)
                .WithMany()
                .HasForeignKey(cur => cur.Id_comision)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Plan y Materia
            modelBuilder.Entity<Materia>()
                .HasOne(mat => mat.Plan)
                .WithMany()
                .HasForeignKey(mat => mat.Id_plan)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Materia y Curso
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.Materia)
                .WithMany()
                .HasForeignKey(cur => cur.Id_materia)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación N:M entre Curso y Alumno
            modelBuilder.Entity<Alumno_Inscripcion>()
                .HasOne(ai => ai.Alumno)
                .WithMany()
                .HasForeignKey(ai => ai.Id_alumno)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alumno_Inscripcion>()
                .HasOne(ai => ai.Curso)
                .WithMany()
                .HasForeignKey(ai => ai.Id_curso)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación N:M entre Curso y Docente
            modelBuilder.Entity<Docente_Curso>()
                .HasOne(dc => dc.Docente)
                .WithMany()
                .HasForeignKey(dc => dc.Id_docente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Docente_Curso>()
                .HasOne(dc => dc.Curso)
                .WithMany()
                .HasForeignKey(dc => dc.Id_curso)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
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
