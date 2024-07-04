using CaseStudy.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.Data;

public class PrjContext : DbContext
{
    public PrjContext(DbContextOptions<PrjContext> contextOptions) : base(contextOptions)
    {

    }

    public DbSet<Cars> Cars { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<DealerPages> DealerPages { get; set; }
    public DbSet<Dealers> Dealers { get; set; }
    public DbSet<HeaderAndFooterSettings> HeaderAndFooterSettings { get; set; }
    public DbSet<MenuSettings> MenuSettings { get; set; }
    public DbSet<Pages> Pages { get; set; }
    public DbSet<UserFavourites> UserFavourites { get; set; }
    public DbSet<Users> Users { get; set; }





}
