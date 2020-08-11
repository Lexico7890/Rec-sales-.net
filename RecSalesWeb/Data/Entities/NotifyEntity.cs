using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecSalesWeb.Data.Entities
{
    public class NotifyEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "El campo {0} nececita {1} caracteres minimo")]
        public string Titulo { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
