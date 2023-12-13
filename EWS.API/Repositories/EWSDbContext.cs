using EWS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EWS.API.Repositories
{
    public class EWSDbContext : DbContext
    {
        public EWSDbContext(DbContextOptions<EWSDbContext> options)
                  : base(options)
        {

        }
        public DbSet <T_MsEws>? T_MsEws { get; set; }

    }
}