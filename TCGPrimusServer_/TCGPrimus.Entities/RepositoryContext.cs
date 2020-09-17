using TCGPrimus.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace TCGPrimus.Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Folder> Folders{ get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ActivityField> ActivityFields { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}
