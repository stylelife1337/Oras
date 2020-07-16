﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Entities
{
    public class User
    {
        [Key]

        public Guid Id { get; set; }
        [MaxLength(150)]
        public string FirstName { get; set; }
        [MaxLength(150)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool? Deleted { get; set; }




    }
}
