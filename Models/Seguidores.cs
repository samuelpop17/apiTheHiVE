﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiProyectoConjuntoAWSRedSocial.Models
{
    [Table("Seguidores")]
    public class Seguidores
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("seguido_username")]
        public string SeguidoUsername { get; set; }

        [Column("seguidor_username")]
        public string SeguidorUsername { get; set; }

        [ForeignKey("SeguidoUsername")]
        public Usuario Seguido { get; set; }

        [ForeignKey("SeguidorUsername")]
        public Usuario Seguidor { get; set; }
    }
}
