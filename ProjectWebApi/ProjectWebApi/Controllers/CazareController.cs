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
    [Route("cazare")]
    [ApiController]
    public class CazareController : ControllerBase
    {
        private readonly ICazareUnitOfWork _cazareUnit;
        private readonly IMapper _mapper;

        public CazareController(ICazareUnitOfWork cazareUnit,
            IMapper mapper)
        {
            _cazareUnit = cazareUnit ?? throw new ArgumentNullException(nameof(cazareUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #region Bookings
        [HttpGet]
        [Route("{id}", Name = "GetCazare")]
        public IActionResult GetCazare(Guid id)
        {
            var cazareEntity = _cazareUnit.Bookings.Get(id);
            if (cazareEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CazareDTO>(cazareEntity));
        }

        [HttpGet]
        [Route("details/{id}", Name = "GetCazareDetails")]
        public IActionResult GetCazareDetails(Guid id)
        {
            var cazareEntity = _cazareUnit.Bookings.GetCazareDetails(id);
            if (cazareEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AtractieDTO>(cazareEntity));
        }

        [Route("add", Name = "Add a new booking")]
        [HttpPost]
        public IActionResult AddCazare([FromBody] CazareDTO cazare)
        {
            var cazareEntity = _mapper.Map<Cazare>(cazare);
            _cazareUnit.Bookings.Add(cazareEntity);

            _cazareUnit.Complete();

            _cazareUnit.Bookings.Get(cazareEntity.Id);

            return CreatedAtRoute("GetCazare",
                new { id = cazareEntity.Id },
                _mapper.Map<CazareDTO>(cazareEntity));
        }
        #endregion Bookings

    }
}
