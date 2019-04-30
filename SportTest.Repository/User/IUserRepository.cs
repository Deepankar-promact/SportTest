using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportTest.Repository.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets all the user who are atheletes.
        /// </summary>
        /// <returns>List of user object</returns>
        Task<List<DomainModel.Models.User>> GetAllAtheletes();
    }
}
