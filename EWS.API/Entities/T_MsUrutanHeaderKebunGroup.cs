using System.ComponentModel.DataAnnotations.Schema;

namespace EWS.API.Entities
{
    [Table("T_MsUrutanHeaderKebunGroup")]
    public class T_MsUrutanHeaderKebunGroup
    {
        public int? Id { get; set; }
        public bool? asHeader { get; set; }
        public string? uraian { get; set; }
        public string? headerName { get; set; }
        public bool? colspan { get; set; }
        public bool? rowspan { get; set; }
        public Int32? colspanAmount { get; set; }
        public Int32? rowspanAmount { get; set; }
        public string? colorBackground { get; set; }
        public string? fontStyle { get; set; }
        public string? fontSize { get; set; }
        public string? fontWeight { get; set; }
        public string? fontColor { get; set; }
        public Int32? heightColumn { get; set; }
        public Int32? widthRow { get; set; }
    }

}
