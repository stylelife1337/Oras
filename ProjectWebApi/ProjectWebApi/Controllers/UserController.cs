﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectWebApi.Entities;
using ProjectWebApi.ExternalModels;
using ProjectWebApi.Services.UnitsOfWork;
using System;
using System.Collections.Generic;

namespace ProjectWebApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUnitOfWork _userUnit;
        private readonly IMapper _mapper;

        public UserController(IUserUnitOfWork userUnit,
            IMapper mapper)
        {
            _userUnit = userUnit ?? throw new ArgumentNullException(nameof(userUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("{id}", Name = "GetUser")]
        public IActionResult GetUser(Guid id)
        {
            var userEntity = _userUnit.Users.Get(id);
            if (userEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDTO>(userEntity));
        }

        [HttpGet]
        [Route("", Name = "GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var userEntities = _userUnit.Users.Find(u => u.Deleted == false || u.Deleted == null);
            if (userEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<UserDTO>>(userEntities));
        }

        [Route("register", Name = "Register a new account")]
        [HttpPost]
        public IActionResult Register([FromBody] UserDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            _userUnit.Users.Add(userEntity);

            _userUnit.Complete();

            _userUnit.Users.Get(userEntity.Id);

            return CreatedAtRoute("GetUser",
                new { id = userEntity.Id },
                _mapper.Map<UserDTO>(userEntity));
        }
    }
}
