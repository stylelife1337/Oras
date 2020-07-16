using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectWebApi.Entities
{
    public class Oras
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

        [Required]
        public Guid TaraId { get; set; }



        [ForeignKey("TaraId")]

        public virtual Tara Tara { get; set; }



        public bool? Deleted { get; set; }






    }
}
