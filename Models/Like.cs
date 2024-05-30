using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiProyectoConjuntoAWSRedSocial.Models
{
    [Table("Likes")]
    public class Like
    {
        [Key]
        [Column("id_publicacion")]
        public int IdPublicacion { get; set; }

        [Key]
        [Column("username")]
        public string Username { get; set; }

        [ForeignKey("IdPublicacion")]
        public Publicacion Publicacion { get; set; }

        [ForeignKey("Username")]
        public Usuario Usuario { get; set; }
    }
}
