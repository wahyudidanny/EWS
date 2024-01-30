using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EWS.API.Entities
{
    [Keyless]
    [Table("TempData_EWS_LevelRekapGroup")]
    public class T_MsRekapGroup
    {
        public string? Group { get; set; }
        public Int32? E_Blok { get; set; }
        public Int32? E_LuasHa { get; set; }
        public decimal? E_Percentage { get; set; }
        public Int32? G_Blok { get; set; }
        public Int32? G_LuasHa { get; set; }
        public decimal? G_Percentage { get; set; }
        public Int32? Ni_Blok { get; set; }
        public Int32? Ni_LuasHa { get; set; }
        public decimal? Ni_Percentage { get; set; }
        public Int32? Us_Blok { get; set; }
        public Int32? Us_LuasHa { get; set; }
        public decimal? Us_Percentage { get; set; }
        public Int32? NoBgt_Blok { get; set; }
        public Int32? NoBgt_LuasHa { get; set; }
        public decimal? NoBgt_Percentage { get; set; }
        public Int32? Total_Blok { get; set; }
        public Int32? Total_LuasHa { get; set; }
        public decimal? Total_Percentage { get; set; }
        public string? Period { get; set; }
        public DateTime? DateGenerate { get; set; }

    }
}