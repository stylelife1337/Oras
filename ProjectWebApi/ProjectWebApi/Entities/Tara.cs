using System;
using System.ComponentModel.DataAnnotations;

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
