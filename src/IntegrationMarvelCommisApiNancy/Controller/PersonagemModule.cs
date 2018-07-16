using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationMarvelCommics.Api.CrossCutting.Json;
using IntegrationMarvelCommics.Api.Nancy.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Nancy;
using Nancy.Json;
using Newtonsoft.Json;

namespace IntegrationMarvelCommics.Api.Nancy.Controller
{
    public class PersonagemModule : NancyModule
    {
    
        public PersonagemModule()
        {
            Get("/", args => JsonConvert.SerializeObject("Hello Marvel"));
            Get("/api/Personagem/{Nome}", args =>JsonConvert.SerializeObject(HttpClienMarvel.ResultadoMarvel(args.Nome, Config.Configurations)));
        }
    }
}
