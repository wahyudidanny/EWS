using Microsoft.Extensions.Configuration;

namespace EWS.Services.Models
{
    public class AppSettings
    {
        private readonly IConfiguration _configuration;
        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? apiBaseUrl { get { return GetValue("apiBaseUrl"); } }
        public string? filePath { get { return GetValue("filePath"); } }
        public string? generatePDF { get { return GetValue("generatePDF"); } }
        public string? sendPDFProd { get { return GetValue("sendPDFProd"); } }
        public string? yearGenerate { get { return GetValue("yearGenerate"); } }

        public string? monthGenerate { get { return GetValue("monthGenerate"); } }

        public string? GetValue(string key)
        {
            var result = _configuration.GetSection("AppSettings")[key];
            return result;
        }
    }
}