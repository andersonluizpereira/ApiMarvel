using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IntegrationMarvelCommics.Api.CrossCutting.Json;
using IntegrationMarvelCommics.Api.Domain.Models;
using IntegrationMarvelCommics.ApiCrossCutting.Hashs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IntegrationMarvelCommicsApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Personagem")]
    public class PersonagemController : Controller
    {
        [HttpGet("{Nome}")]
        public IActionResult Get(string Nome, [FromServices]IConfiguration config)
        {
            var personagem = HttpClienMarvel.ResultadoMarvel(Nome, config);
            return Ok(personagem);
        }

    }
}