using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using IntegrationMarvelCommics.Api.Domain.Models;
using IntegrationMarvelCommics.ApiCrossCutting.Hashs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace IntegrationMarvelCommics.Api.CrossCutting.Json
{
    public static class HttpClienMarvel 
    {
        

        public static dynamic ResultadoMarvel(string Nome, [FromServices] IConfiguration config)
        {
            if (String.IsNullOrEmpty(Nome))
                Nome = "Captain America";

            Personagem personagem;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string ts = DateTime.Now.Ticks.ToString();
                string publicKey = config.GetSection("MarvelComicsAPI:PublicKey").Value;
                string hash = Hash.GerarHash(ts, publicKey,
                                             config.GetSection("MarvelComicsAPI:PrivateKey").Value);

                HttpResponseMessage response = client.GetAsync(
                    config.GetSection("MarvelComicsAPI:BaseURL").Value +
                    $"characters?ts={ts}&apikey={publicKey}&hash={hash}&" +
                    $"name={Uri.EscapeUriString(Nome)}").Result;

                response.EnsureSuccessStatusCode();
                string conteudo =
                    response.Content.ReadAsStringAsync().Result;

                dynamic resultado = JsonConvert.DeserializeObject(conteudo);

                //personagem = new Personagem();
                //personagem.Nome = resultado.data.results[0].name;
                //personagem.Descricao = resultado.data.results[0].description;
                //personagem.UrlImagem = resultado.data.results[0].thumbnail.path + "." +
                //                       resultado.data.results[0].thumbnail.extension;
                //personagem.UrlWiki = resultado.data.results[0].urls[1].url;
                return resultado;
            }
        }

    }
}

