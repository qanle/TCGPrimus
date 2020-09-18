using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TCG.Models.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Users> User { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityField> ActivityFields { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<WorkflowItem> WorkflowItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ConnStr");
                //optionsBuilder.UseSqlServer(connectionString);
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            }
        }


    }
}
