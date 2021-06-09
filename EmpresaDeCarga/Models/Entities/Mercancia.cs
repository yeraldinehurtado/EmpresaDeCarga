using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Entities
{
    public class Mercancia
    {
        [Key]
        public int MercanciaId { get; set; }

        [Required(ErrorMessage = "El tipo de mercancia es obligatorio")]
        [Column("TipoDeMercancia", TypeName = "nvarchar(100)")]
        public string TipoMercancia { get; set; }
    }
}
