using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EWS.Job.Entities
{
    public class AppSettings
    {
        private readonly IConfiguration _configuration;
        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? baseApiUrl { get { return GetValue("baseApiUrl"); } }
        public string? filePath { get { return GetValue("filePath"); } }
        public string? generatePDF { get { return GetValue("generatePDF"); } }
        public string? sendPDFProd { get { return GetValue("sendPDFProd"); } }
        public string? GetValue(string key)
        {
            var result = _configuration.GetSection("AppSettings")[key];
            return result;
        }

    }
}
