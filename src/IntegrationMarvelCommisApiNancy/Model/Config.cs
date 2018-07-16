using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace IntegrationMarvelCommics.Api.Nancy.Model
{
    public static class Config
    {
        public static IConfiguration Configurations { get; set; }
    }
}
