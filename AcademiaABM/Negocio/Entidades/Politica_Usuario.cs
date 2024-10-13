namespace AcademiaABM.Negocio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Politicas_Usuarios")]
    public class Politica_Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_politica")]
        public int Id_politica { get; set; }

        [Column("Id_usuario")]
        public int Id_usuario { get; set; }

        [Column("Politica_usuario")]
        public string? Politica_usuario { get; set; }

        [Column("Habilitada")]
        public bool Habilitada { get; set; }

        public Politica_Usuario(int id_usuario, string politica_usuario, bool habilitada)
        {
            this.Id_usuario = id_usuario;
            this.Politica_usuario = politica_usuario;
            this.Habilitada = habilitada;

        }

        public Politica_Usuario() { }
    }
}
