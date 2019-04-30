using Microsoft.AspNetCore.Mvc;
using SportTest.DomainModel.Models;
using SportTest.Repository.Test;
using System.Threading.Tasks;

namespace SportTest.Core.Controllers
{
    [Route(BaseUrl)]
    public class TestController : Controller
    {
        #region Private variables
        #region Dependencies
        private ITestRepository _testRepository;
        #endregion

        private const string BaseUrl = "api/[controller]";
        #endregion

        #region Constructor
        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }
        #endregion

        #region Public Methods
        [HttpPost]
        public async Task<IActionResult> AddTest([FromBody]Test test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _testRepository.AddTestAsync(test);

            return Ok(test);
        }

        [HttpPost("addAthelete")]
        public async Task<IActionResult> AddAtheleteToTest([FromBody]TestDetail testDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _testRepository.IsTestExistAsync(testDetail.TestId))
            {
                return NotFound();
            }

            await _testRepository.AddAtheleteToTestAsync(testDetail);

            return Ok(testDetail);
        }

        [HttpPut("editAthelete")]
        public async Task<IActionResult> EditAtheleteToTest([FromBody]TestDetail testDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(!await _testRepository.IsTestDetailExistAsync(testDetail.Id))
            {
                return NotFound();
            }

            await _testRepository.EditAtheleteInTestAsync(testDetail);

            return Ok(testDetail);
        }

        [HttpDelete("deleteAtheleteFromTest/{testDetailId}")]
        public async Task<IActionResult> DeleteAtheleteFromTest([FromRoute]int testDetailId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _testRepository.IsTestDetailExistAsync(testDetailId))
            {
                return NotFound();
            }

            await _testRepository.DeleteAtheleteFromTheTest(testDetailId);

            return Ok(testDetailId);
        }

        [HttpDelete("deleteTest/{testId}")]
        public async Task<IActionResult> DeleteTest([FromRoute]int testId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!await _testRepository.IsTestExistAsync(testId))
            {
                return NotFound();
            }

            await _testRepository.DeleteTest(testId);

            return Ok(testId);
        }
        #endregion
    }
}
