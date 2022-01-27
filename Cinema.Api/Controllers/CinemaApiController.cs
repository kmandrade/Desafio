﻿using Domain.Dtos.FilmeDto;
using Domain.Models;
using Domain.Services.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Api.Controllers
{
    [ApiController]
    [Route("controller")]
    public class CinemaApiController : ControllerBase
    {
        IFilmeService _service;

        public CinemaApiController(IFilmeService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult ConsultaTodosFilmes()
        {
            var filmes = _service.ConsultaFilmes();
            return Ok(filmes);
        }
        [HttpPost]
        public IActionResult CadastraFilme([FromBody] CriarFilmeDto filme)
        {
            _service.CadastraFilme(filme);
            return Ok();
        }


    }
}
