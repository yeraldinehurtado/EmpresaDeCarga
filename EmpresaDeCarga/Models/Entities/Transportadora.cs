using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmpresaDeCarga.Models.Entities
{
    public class Transportadora
    {

        [Key]
        public int TransportadoraId { get; set; }


        [Required(ErrorMessage = "El nombre es obligarotio")]
        [Column("NombreTransportadora", TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }




    }
}

