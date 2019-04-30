using Microsoft.EntityFrameworkCore;
using SportTest.DomainModel.ApplicationClass;
using SportTest.DomainModel.DbContext;
using SportTest.DomainModel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTest.Repository.Test
{
    public class TestRepository : ITestRepository
    {
        #region Private Variables
        #region Dependencies
        private readonly SportsDbContext _dbContext;
        #endregion
        #endregion

        #region Constructor
        public TestRepository(SportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public Methods
        public async Task<List<TestDetailAC>> GetAllTestDetailAsync()
        {
            var testDetails = await _dbContext
                .Tests
                .Select(x => new {
                    x.Id,
                    x.TestDate,
                    x.TestType,
                    participantsCount = x.TestDetails.Count(y => y.TestId == x.Id)
                })
                .ToListAsync();

            List<TestDetailAC> testDetailACs = new List<TestDetailAC>();

            testDetails.ForEach(test =>
            {
                testDetailACs.Add(new TestDetailAC
                {
                    Id = test.Id,
                    Date = test.TestDate,
                    NumberOfParticipants = test.participantsCount,
                    TestType = test.TestType.ToString()
                });
            });

            return testDetailACs;
        }
        
        public async Task AddTestAsync(DomainModel.Models.Test test)
        {
            await _dbContext.Tests.AddAsync(test);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AtheleteReportAC>> GetAtheleteReportsAsync(int testId)
        {
            var atheleteDetails = await _dbContext
                .TestDetails
                .Where(x => x.TestId == testId)
                .Select(x => new { name = x.User.Name, atheleteId = x.AtheleteId, x.Distance, x.Id })
                .OrderByDescending(x => x.Distance)
                .AsNoTracking()
                .ToListAsync();

            List<AtheleteReportAC> atheleteReportACs = new List<AtheleteReportAC>();

            int rank = 1;

            atheleteDetails.ForEach(x =>
            {
                atheleteReportACs.Add(new AtheleteReportAC
                {
                    Id = x.Id,
                    AtheleteName = x.name,
                    AtheleteId = x.atheleteId,
                    Distance = x.Distance,
                    Rank = rank++,
                    FitnessRating = GetFitnessRating(x.Distance)
                });
            });

            return atheleteReportACs;
        }

        public async Task<TestDetailAC> GetTestAsync(int testId)
        {
            var testDetail = await _dbContext
                .Tests
                .Where(x => x.Id == testId)
                .Select(x => new
                {
                    x.Id,
                    x.TestDate,
                    x.TestType,
                    participantsCount = x.TestDetails.Count(y => y.TestId == x.Id)
                })
                .SingleAsync();

            return new TestDetailAC
            {
                Id = testDetail.Id,
                Date = testDetail.TestDate,
                NumberOfParticipants = testDetail.participantsCount,
                TestType = testDetail.TestType.ToString()
            };
        }

        public async Task AddAtheleteToTestAsync(TestDetail testDetail)
        {
            await _dbContext.TestDetails.AddAsync(testDetail);

            await _dbContext.SaveChangesAsync();
        }

        public async Task EditAtheleteInTestAsync(TestDetail testDetail)
        {
            var testDetailToEdit = await _dbContext.TestDetails.Where(x => x.Id == testDetail.Id).SingleAsync();

            testDetailToEdit.AtheleteId = testDetail.AtheleteId;
            testDetailToEdit.Distance = testDetail.Distance;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAtheleteFromTheTest(int testDetailId)
        {
            var testDetailToRemove = await _dbContext.TestDetails.Where(x => x.Id == testDetailId).SingleAsync();

            _dbContext.TestDetails.Remove(testDetailToRemove);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTest(int testId)
        {
            var testToRemove = await _dbContext.Tests.Where(x => x.Id == testId).SingleAsync();

            _dbContext.Tests.Remove(testToRemove);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsTestExistAsync(int testId)
        {
            return await _dbContext.Tests.AnyAsync(x => x.Id == testId);
        }

        public async Task<bool> IsTestDetailExistAsync(int testDetailId)
        {
            return await _dbContext.TestDetails.AnyAsync(x => x.Id == testDetailId);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Converts distance to fitness rating string.
        /// </summary>
        /// <param name="distance"></param>
        /// <returns>Fitness Rating</returns>
        private string GetFitnessRating(double distance)
        {
            if(distance > 3500)
            {
                return "Very Good";
            }

            if(distance > 2000 && distance <= 3500)
            {
                return "Good";
            }

            if(distance > 1000 && distance <= 2000)
            {
                return "Average";
            }

            return "Below Average";
        }
        #endregion
    }
}
