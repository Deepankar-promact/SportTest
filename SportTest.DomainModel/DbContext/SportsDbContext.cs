using Microsoft.EntityFrameworkCore;
using SportTest.DomainModel.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportTest.DomainModel.DbContext
{
    public class SportsDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public SportsDbContext(DbContextOptions<SportsDbContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<TestDetail> TestDetails { get; set; }


        #region Overridden Methods  
        public override int SaveChanges()
        {
            ChangeTracker.Entries().Where(x => x.Entity is BaseModel && x.State == EntityState.Added).ToList().ForEach(x =>
            {
                ((BaseModel)x.Entity).CreatedDateTime = DateTime.UtcNow;
            });
            ChangeTracker.Entries().Where(x => x.Entity is BaseModel && x.State == EntityState.Modified).ToList().ForEach(x =>
            {
                ((BaseModel)x.Entity).UpdatedDateTime = DateTime.UtcNow;
            });

            return base.SaveChanges();
        }

        /// <summary>
        /// override savechangesasync method
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.Entries().Where(x => x.Entity is BaseModel && x.State == EntityState.Added).ToList().ForEach(x =>
            {
                ((BaseModel)x.Entity).CreatedDateTime = DateTime.UtcNow;
            });
            ChangeTracker.Entries().Where(x => x.Entity is BaseModel && x.State == EntityState.Modified).ToList().ForEach(x =>
            {
                ((BaseModel)x.Entity).UpdatedDateTime = DateTime.UtcNow;
            });

            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
