
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace EWS.API.Requests

{
    [Keyless]
    [Table("T_DataDetail_Rotasi_Sensus_alan")]
    public class T_MsRequests
    {
        public string? Header { get; set; }
        public string? T1 { get; set; }
        public string? T2 { get; set; }
        public string? T3 { get; set; }
        public string? T4 { get; set; }
        public string? T5 { get; set; }
        public string? T6 { get; set; }
        public string? T7 { get; set; }
        public string? T8 { get; set; }
        public string? T9 { get; set; }
        public string? T10 { get; set; }
        public string? T11 { get; set; }
        public string? T12 { get; set; }

    }
}