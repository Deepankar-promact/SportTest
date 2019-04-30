using Microsoft.EntityFrameworkCore;
using SportTest.DomainModel.DbContext;
using SportTest.DomainModel.Enums;
using SportTest.DomainModel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTest.Utility
{
    public class SeedDatabase
    {
        #region Private variables
        #region Dependencies
        private SportsDbContext _dbContext;
        #endregion
        #endregion

        public SeedDatabase(SportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            await SeedRolesAsync();

            await SeedUserAsync();
        }

        #region Private Methods
        /// <summary>
        /// Seeds roles into the table if roles does not exists.
        /// </summary>
        private async Task SeedRolesAsync()
        {
            bool roleExists = await _dbContext.Roles.AnyAsync();

            if (!roleExists)
            {
                List<Role> roles = new List<Role>
                {
                    new Role{ UserRole = RoleType.Coach},
                    new Role{ UserRole = RoleType.Athelete}
                };

                await _dbContext.Roles.AddRangeAsync(roles);

                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Seeds users into the table if no user exists.
        /// </summary>
        private async Task SeedUserAsync()
        {
            bool userExists = await _dbContext.Users.AnyAsync();

            if (!userExists)
            {
                List<Role> roles = await _dbContext.Roles.ToListAsync();

                int coachRoleId = roles.Where(x => x.UserRole == RoleType.Coach).Select(x => x.Id).Single();
                int atheleteRoleId = roles.Where(x => x.UserRole == RoleType.Athelete).Select(x => x.Id).Single();

                List<User> users = new List<User>
                {
                    new User{Name="Mitchel Fausto",  RoleId=coachRoleId},
                    new User{Name="Queen Jacobi",  RoleId=atheleteRoleId},
                    new User{Name="Magen Faye",  RoleId=atheleteRoleId},
                    new User{Name="Delicia Ledonne",  RoleId=atheleteRoleId},
                    new User{Name="Camille Grantham",  RoleId=atheleteRoleId},
                    new User{Name="Marc Voth",  RoleId=atheleteRoleId},
                    new User{Name="Randy Rondon",  RoleId=atheleteRoleId},
                    new User{Name="Delora Saville",  RoleId=atheleteRoleId},
                    new User{Name="Rosario Reuben",  RoleId=atheleteRoleId},
                    new User{Name="Lula Uhlman",  RoleId=atheleteRoleId}
                };

                await _dbContext.Users.AddRangeAsync(users);

                await _dbContext.SaveChangesAsync();                
            }

        }

        #endregion

    }
}
