using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Entities
{
    public class Cazare
    {
        [Key]

        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]

        public string Name { get; set; }

        [Required]
        [MaxLength(150)]

        public string Adresa { get; set; }

        [Required]
        [MaxLength(2500)]

        public string Description { get; set; }

        [Required]
        [MaxLength(150)]

        public string Review { get; set; }


        public int Pret { get; set; }


        public bool? Deleted { get; set; }

    }
}
