using BulkDeleteCreate.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BulkDeleteCreate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestRepository _testRepository;

        public HomeController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                await _testRepository.UpdateGroupMembershipsAsync(AppSettings.UserId);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
