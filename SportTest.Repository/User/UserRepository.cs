using Microsoft.EntityFrameworkCore;
using SportTest.DomainModel.DbContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTest.Repository.User
{
    public class UserRepository : IUserRepository
    {
        #region Private Variables
        #region Dependencies
        private readonly SportsDbContext _dbContext;
        #endregion
        #endregion

        #region Constructor
        public UserRepository(SportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public Methods
        public async Task<List<DomainModel.Models.User>> GetAllAtheletes()
        {
            return await _dbContext
                .Users
                .Where(x => x.UserRole.UserRole == DomainModel.Enums.RoleType.Athelete)
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion
    }
}
