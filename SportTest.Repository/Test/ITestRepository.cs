using SportTest.DomainModel.ApplicationClass;
using SportTest.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportTest.Repository.Test
{
    public interface ITestRepository
    {
        /// <summary>
        /// Gets all the test details
        /// </summary>
        /// <returns>TestDetailAC object</returns>
        Task<List<TestDetailAC>> GetAllTestDetailAsync();

        /// <summary>
        /// Get test by Id.
        /// </summary>
        /// <param name="testId">Test Id</param>
        /// <returns>TestDetailAC object</returns>
        Task<TestDetailAC> GetTestAsync(int testId);

        /// <summary>
        /// Checks if Test exists.
        /// </summary>
        /// <param name="testId">Test Id</param>
        /// <returns></returns>
        Task<bool> IsTestExistAsync(int testId);

        /// <summary>
        /// Checks if TestDetail exists.
        /// </summary>
        /// <param name="testDetailId">TestDetail Id</param>
        /// <returns></returns>
        Task<bool> IsTestDetailExistAsync(int testDetailId);

        /// <summary>
        /// Adds a test
        /// </summary>
        /// <returns></returns>
        Task AddTestAsync(DomainModel.Models.Test test);

        /// <summary>
        /// Gets report of the athelete in the Test.
        /// </summary>
        /// <param name="testId">Test Id</param>
        /// <returns>List of AtheleteReportAC object</returns>
        Task<List<AtheleteReportAC>> GetAtheleteReportsAsync(int testId);

        /// <summary>
        /// Adds athelete to the Test.
        /// </summary>
        /// <param name="testDetail">TestDetail Object</param>
        Task AddAtheleteToTestAsync(TestDetail testDetail);

        /// <summary>
        /// Update the athelete in the Test.
        /// </summary>
        /// <param name="testDetail">TestDetail Object</param>
        Task EditAtheleteInTestAsync(TestDetail testDetail);

        /// <summary>
        /// Deletes the athelete from the Test.
        /// </summary>
        /// <param name="testDetailId">TestDetail Id</param>
        Task DeleteAtheleteFromTheTest(int testDetailId);

        /// <summary>
        /// Delete test by Id.
        /// </summary>
        /// <param name="testId">Test Id</param>
        Task DeleteTest(int testId);
    }
}
