using Microsoft.EntityFrameworkCore;

namespace ReplaceWithProjectName.Models
{
  public class ReplaceWithProjectNameContext : DbContext
  {
    public virtual DbSet<ReplaceWithParentClassName> ReplaceWithParentClassName { get; set; }
    public DbSet<ReplaceWithChildClassName> ReplaceWithChildClassName { get; set; }

    public ReplaceWithProjectNameContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}