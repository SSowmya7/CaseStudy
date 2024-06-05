using CaseStudy.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CaseStudy.Infrastructure.Data
{
    public class PrjContext : DbContext
    {
        public PrjContext(DbContextOptions<PrjContext> contextOptions) : base(contextOptions)
        { }

        public DbSet<Cars> cars { get; set; }
        public DbSet<Components> components { get; set; }
        public DbSet<DealerPages> dealerPages { get; set; }
        public DbSet<Dealers> dealers { get; set; }
        public DbSet<HeaderAndFooterSettings> headerAndFooterSettings { get; set; }
        public DbSet<MenuSettings> menuSettings { get; set; }
        public DbSet<Pages> pages { get; set; }
        public DbSet<UserFavourites> userFavourites { get; set; }
        public DbSet<Users> users { get; set; }





    }
}
