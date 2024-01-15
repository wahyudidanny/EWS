using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EWS.API.Entities
{
    [Keyless]
    public class T_MsEwsNew
    {
        public Int64? ranked { get; set; }
        public string? company { get; set; }
        public string? location { get; set; }
        public string? afdeling { get; set; }
        public string? blokCode { get; set; }
        public decimal? hectaragePlanted { get; set; }
        public decimal? tonHa { get; set; }
        public decimal? roundTonHa { get; set; }
        public decimal? bdgtTonHa { get; set; }
        public decimal? roundBdgtTonHa { get; set; }
        public decimal? acHTonHaAktvsBgdt { get; set; }
        public decimal? jjgPkk { get; set; }
        public decimal? roundJjgPkk { get; set; }
        public decimal? bdgtJjgPkk { get; set; }
        public decimal? roundBdgtJjgPkk { get; set; }
        public decimal? achJjgAktvsBgdt { get; set; }
        public decimal? bjrAkt { get; set; }
        public decimal? roundBjrAkt { get; set; }
        public decimal? bjrBdgt { get; set; }
        public decimal? roundBjrBdgt { get; set; }
        public decimal? achBjrAktvsBgdt { get; set; }
        public decimal? aktRotPnn { get; set; }
        public decimal? roundAktRotPnn { get; set; }
        public decimal? bdgtRotasi { get; set; }
        public decimal? achRotasiAktvsBgdt { get; set; }
        public decimal? totAnotganikAkt { get; set; }
        public decimal? totAnotganikBdgt { get; set; }
        public decimal? achAnorganikAktvsBgdt { get; set; }
        public decimal? totpiringanAkt { get; set; }
        public decimal? totpiringanBdgt { get; set; }
        public decimal? achPiringanAktvsBgdt { get; set; }
        public decimal? totgawanganAkt { get; set; }
        public decimal? totgawanganBdgt { get; set; }
        public decimal? achGawanganAktvsBgdt { get; set; }
        public decimal? tottunasAkt { get; set; }
        public decimal? tottunasBdgt { get; set; }
        public decimal? achTunasAktvsBgdt { get; set; }
    }
}