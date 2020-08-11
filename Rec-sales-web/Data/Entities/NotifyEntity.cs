using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rec_sales_web.Data.Entities
{
    public class NotifyEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "El campo {0} necesita minimo {1} caracteres")]
        public string Titulo { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
