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
    [Route("atractie")]
    [ApiController]
    public class AtractieController : ControllerBase
    {
        private readonly IAtractieUnitOfWork _atractieUnit;
        private readonly IMapper _mapper;

        public AtractieController(IAtractieUnitOfWork atractieUnit,
            IMapper mapper)
        {
            _atractieUnit = atractieUnit ?? throw new ArgumentNullException(nameof(atractieUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #region Attractions
        [HttpGet]
        [Route("{id}", Name = "GetAtractie")]
        public IActionResult GetAtractie(Guid id)
        {
            var atractieEntity = _atractieUnit.Attractions.Get(id);
            if (atractieEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AtractieDTO>(atractieEntity));
        }

        [HttpGet]
        [Route("details/{id}", Name = "GetAtractieDetails")]
        public IActionResult GetAtractieDetails(Guid id)
        {
            var atractieEntity = _atractieUnit.Attractions.GetAtractieDetails(id);
            if (atractieEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AtractieDTO>(atractieEntity));
        }

        [Route("add", Name = "Add a new attraction")]
        [HttpPost]
        public IActionResult AddAtractie([FromBody] AtractieDTO atractie)
        {
            var atractieEntity = _mapper.Map<Atractie>(atractie);
            _atractieUnit.Attractions.Add(atractieEntity);

            _atractieUnit.Complete();

            _atractieUnit.Attractions.Get(atractieEntity.Id);

            return CreatedAtRoute("GetAtractie",
                new { id = atractieEntity.Id },
                _mapper.Map<AtractieDTO>(atractieEntity));
        }
        #endregion Attractions

        #region Cities
        [HttpGet]
        [Route("Oras/{OrasId}", Name = "GetOras")]
        public IActionResult GetOras(Guid OrasId)
        {
            var orasEntity = _atractieUnit.Cities.Get(OrasId);
            if (orasEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OrasDTO>(orasEntity));
        }

        [HttpGet]
        [Route("Oras", Name = "GetAllOrase")]
        public IActionResult GetAllOrase()
        {
            var orasEntities = _atractieUnit.Cities.Find(o => o.Deleted == false || o.Deleted == null);
            if (orasEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<OrasDTO>>(orasEntities));
        }

        [Route("Oras/add", Name = "Add a new Oras")]
        [HttpPost]
        public IActionResult AddOras([FromBody] OrasDTO oras)
        {
            var orasEntity = _mapper.Map<Oras>(oras);
            _atractieUnit.Cities.Add(orasEntity);

            _atractieUnit.Complete();

            _atractieUnit.Cities.Get(orasEntity.Id);

            return CreatedAtRoute("GetOras",
                new { OrasId = orasEntity.Id },
                _mapper.Map<OrasDTO>(orasEntity));
        }

        [Route("Oras/{OrasId}", Name = "Mark Oras as deleted")]
        [HttpPut]
        public IActionResult MarkOrasAsDeleted(Guid OrasId)
        {
            var oras = _atractieUnit.Cities.FindDefault(o => o.Id.Equals(OrasId) && (o.Deleted == false || o.Deleted == null));
            if (oras != null)
            {
                oras.Deleted = true;
                if (_atractieUnit.Complete() > 0)
                {
                    return Ok("Oras " + OrasId + " was deleted.");
                }
            }
            return NotFound();
        }
        #endregion Orase

    }
}

