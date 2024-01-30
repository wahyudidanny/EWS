using EWS.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace EWS.API.Repositories
{
    public class EWSDbContext : DbContext
    {
        public EWSDbContext(DbContextOptions<EWSDbContext> options) : base(options){ }
        public DbSet<T_MsEws>? T_MsEws { get; set; }
        public DbSet<T_MsEwsNew>? T_MsEwsNew { get; set; }
        public DbSet<T_MsUrutanEws>? T_MsUrutanEws { get; set; }
        public DbSet<T_MsRekapKebun>? T_MsRekapKebun { get; set; }
        public DbSet<T_PercentageAchColorEws>? T_PercentageAchColorEws { get; set; }
        public DbSet<T_MsRekapGroup>? T_MsRekapGroup { get; set; }

    }
}