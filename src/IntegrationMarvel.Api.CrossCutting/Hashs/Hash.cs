﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IntegrationMarvelCommics.ApiCrossCutting.Hashs
{
    public static class Hash
    {
        public static string GerarHash(
            string ts, string publicKey, string privateKey)
        {
            byte[] bytes =
                Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var gerador = MD5.Create();
            byte[] bytesHash = gerador.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash)
                               .ToLower().Replace("-", String.Empty);
        }

    }
}
