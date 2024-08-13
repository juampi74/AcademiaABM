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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<Persona>()
                            .HasKey(per => per.Id_persona);

            modelBuilder.Entity<Usuario>()
                            .HasKey(usu => usu.Id_usuario);

            modelBuilder.Entity<Especialidad>()
                            .HasKey(esp => esp.Id_especialidad);

            modelBuilder.Entity<Plan>()
                            .HasKey(pla => pla.Id_plan);

            modelBuilder.Entity<Materia>()
                            .HasKey(mat => mat.Id_materia);

            modelBuilder.Entity<Comision>()
                            .HasKey(com => com.Id_comision);

            modelBuilder.Entity<Curso>()
                            .HasKey(cur => cur.Id_curso);

            modelBuilder.Entity<Alumno_Inscripcion>()
                            .HasKey(ai => ai.Id_inscripcion);

            modelBuilder.Entity<Docente_Curso>()
                            .HasKey(dc => dc.Id_dictado);

            // Relación 1:N entre Persona y Usuario
            modelBuilder.Entity<Usuario>()
                .HasOne(usu => usu.Persona)
                .WithMany(per => per.Usuarios)
                .HasForeignKey(usu => usu.Id_persona)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Especialidad y Plan
            modelBuilder.Entity<Plan>()
                .HasOne(pla => pla.Especialidad)
                .WithMany(esp => esp.Planes)
                .HasForeignKey(pla => pla.Id_especialidad)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Plan y Persona
            modelBuilder.Entity<Persona>()
                .HasOne(per => per.Plan)
                .WithMany(pla => pla.Personas)
                .HasForeignKey(per => per.Id_plan)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Plan y Comision
            modelBuilder.Entity<Comision>()
                .HasOne(com => com.Plan)
                .WithMany(pla => pla.Comisiones)
                .HasForeignKey(com => com.Id_plan)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Comision y Curso
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.Comision)
                .WithMany(com => com.Cursos)
                .HasForeignKey(cur => cur.Id_comision)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Plan y Materia
            modelBuilder.Entity<Materia>()
                .HasOne(mat => mat.Plan)
                .WithMany(pla => pla.Materias)
                .HasForeignKey(mat => mat.Id_plan)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación 1:N entre Materia y Curso
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.Materia)
                .WithMany(mat => mat.Cursos)
                .HasForeignKey(cur => cur.Id_materia)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación N:M entre Curso y Alumno
            modelBuilder.Entity<Alumno_Inscripcion>()
                .HasOne(ai => ai.Alumno)
                .WithMany(per => per.Alumno_Inscripciones)
                .HasForeignKey(ai => ai.Id_alumno)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alumno_Inscripcion>()
                .HasOne(ai => ai.Curso)
                .WithMany(cur => cur.Alumno_Inscripciones)
                .HasForeignKey(ai => ai.Id_curso)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación N:M entre Curso y Docente
            modelBuilder.Entity<Docente_Curso>()
                .HasOne(dc => dc.Docente)
                .WithMany(per => per.Docente_Cursos)
                .HasForeignKey(dc => dc.Id_docente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Docente_Curso>()
                .HasOne(dc => dc.Curso)
                .WithMany(cur => cur.Docente_Cursos)
                .HasForeignKey(dc => dc.Id_curso)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

            // El método Include en Entity Framework se utiliza para especificar las entidades
            // relacionadas que deben cargarse junto con la entidad principal.
            // var cursoConComision = context.Cursos
            // .Include(c => c.Comision)  // Incluye la entidad relacionada Comision
            // .FirstOrDefault(c => c.Id == cursoId);  // Devuelve el primer Curso que coincide
            //                                            con el Id especificado o null

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