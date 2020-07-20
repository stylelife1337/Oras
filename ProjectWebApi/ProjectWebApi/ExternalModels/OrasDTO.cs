using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.ExternalModels
{
    public class OrasDTO
    {
        public Guid Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public Guid TaraId { get; set; }


        public TaraDTO Tara {get;set;}

        

     



       


    }
}
