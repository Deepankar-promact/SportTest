using Microsoft.AspNetCore.Mvc;
using SportTest.DomainModel.Enums;
using SportTest.Repository.Test;
using SportTest.Repository.User;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportTest.Core.Controllers
{
    public class HomeController : Controller
    {
        #region Dependencies
        private ITestRepository _testRepository;
        private IUserRepository _userRepository;
        #endregion

        #region Constructor
        public HomeController(ITestRepository testRepository, IUserRepository userRepository)
        {
            _testRepository = testRepository;
            _userRepository = userRepository;
        }
        #endregion

        #region Public Methods
        public async Task<IActionResult> Index()
        {
            ViewBag.TestDetails = await _testRepository.GetAllTestDetailAsync();
            ViewBag.TestTypes = Enum
                .GetNames(typeof(TestType))
                .ToList();

            return View();
        }

        public async Task<IActionResult> TestDetail([FromRoute]int id)
        {
            var reports = await _testRepository.GetAtheleteReportsAsync(id);
            var atheletes = await _userRepository.GetAllAtheletes();

            ViewBag.TestDetail = await _testRepository.GetTestAsync(id);
            ViewBag.AtheleteReport = reports;

            //Remove the athelete already in the Test
            ViewBag.Atheletes = atheletes.Where(x => !reports.Any(u => u.AtheleteId == x.Id)).ToList();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        #endregion
    }
}
