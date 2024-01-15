using Microsoft.EntityFrameworkCore;

namespace EWS.API.Entities
{
    [Keyless]
    public class T_PercentageAchColorEws
    {

        public string? backgroundColor { get; set; }
        public string? fontColor { get; set; }
        public decimal? numberStart { get; set; }
        public decimal? numberEnd { get; set; }

    }

}