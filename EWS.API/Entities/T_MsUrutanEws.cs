using Microsoft.EntityFrameworkCore;

namespace EWS.API.Entities
{
    [Keyless]
    public class T_MsUrutanEws
    {
        public int? ranked { get; set; }
        public string? uraian { get; set; }
        public string? headerName { get; set; }
        public string? satuan { get; set; }
        public bool? asHeader { get; set; }
        public bool? colspan { get; set; }
        public bool? rowspan { get; set; }

    }

}