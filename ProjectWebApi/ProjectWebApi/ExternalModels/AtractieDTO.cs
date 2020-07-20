using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.ExternalModels
{
    public class AtractieDTO
    {
        public Guid Id { get; set; }

        

        public string Name { get; set; }

       

        public string Adresa { get; set; }
       
        public string Description { get; set; }


        public int Pret { get; set; }

      
        public Guid OrasId { get; set; }


        public OrasDTO Oras { get; set; }

    }
}
