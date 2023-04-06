using Bank.Service.Dtos.Users;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Mvc.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", new UserDto()
            {
                FirstName = "Muzaffar",
                LastName = "Nurillayev",
                Balance = 0,
                DateOfBirth = DateTime.Now,
                Email = "nurillaewmuzaffar@gmail.com",
                Phone = "324234"
            });
        }
    }
}
