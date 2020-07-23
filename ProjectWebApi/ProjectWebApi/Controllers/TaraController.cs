using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectWebApi.Entities;
using ProjectWebApi.ExternalModels;
using ProjectWebApi.Services.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWebApi.Controllers
{
    [Route("tara")]
    [ApiController]
    public class TaraController : ControllerBase
    {
        private readonly ITaraUnitOfWork _taraUnit;
        private readonly IMapper _mapper;

        public TaraController(ITaraUnitOfWork taraUnit,
            IMapper mapper)
        {
            _taraUnit = taraUnit ?? throw new ArgumentNullException(nameof(taraUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #region Countries
        [HttpGet]
        [Route("{id}", Name = "GetTara")]
        public IActionResult GetTara(Guid id)
        {
            var taraEntity = _taraUnit.Countries.Get(id);
            if (taraEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaraDTO>(taraEntity));
        }

        [HttpGet]
        [Route("details/{id}", Name = "GetTaraDetails")]
        public IActionResult GetTaraDetails(Guid id)
        {
            var taraEntity = _taraUnit.Countries.GetTaraDetails(id);
            if (taraEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AtractieDTO>(taraEntity));
        }

        [Route("add", Name = "Add a new tara")]
        [HttpPost]
        public IActionResult AddTara([FromBody] TaraDTO tara)
        {
            var taraEntity = _mapper.Map<Tara>(tara);
            _taraUnit.Countries.Add(taraEntity);

            _taraUnit.Complete();

            _taraUnit.Countries.Get(taraEntity.Id);

            return CreatedAtRoute("GetTara",
                new { id = taraEntity.Id },
                _mapper.Map<TaraDTO>(taraEntity));
        }
        #endregion Countries

    }
}
