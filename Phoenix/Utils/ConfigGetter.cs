using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Phoenix.Utils
{
    public static class ConfigGetter
    {
        public static string GetSectionFromJson(string name, string configFileName = "appsettings.json")
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), configFileName);
            configurationBuilder.AddJsonFile(path, false);
            return configurationBuilder.Build().GetSection(name).Value;
        }
    }
}
