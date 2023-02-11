using iJoker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace iJoker.DataAccess.EntityFramework
{
    public class JokesDbContext : DbContext
    {
        public DbSet<Joke> Jokes { get; set; }

        public JokesDbContext(DbContextOptions<JokesDbContext> options) : base(options)
        {
        }
    }

    public class JokesDBContextFactory : IDesignTimeDbContextFactory<JokesDbContext>
    {
        public JokesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<JokesDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=JokesDatabase;Trusted_Connection=true;MultipleActiveResultSets=true", b => b.MigrationsAssembly("iJoker.DataAccess.EntityFramework"));

            return new JokesDbContext(optionsBuilder.Options);
        }
    }
}
