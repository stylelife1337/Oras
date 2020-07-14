using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Entities
{
    public class Tara
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

        public bool? Deleted { get; set; }
    }
}
