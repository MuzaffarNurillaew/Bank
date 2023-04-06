using Bank.Domain.Configuration;
using Bank.Service.Dtos.Users;
using Bank.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Mvc.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 2, string searchString = null)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 1;
            }

            if (searchString is not null)
            {

                var users = await _userService
                    .GetAllAsync(
                        new PaginationParams()
                        {
                            PageIndex = pageIndex,
                            PageSize = (short)pageSize
                        }, user => user.FirstName.Contains(searchString));

                return View(users);
            }
            else
            {
                var users = await _userService
                    .GetAllAsync(
                        new PaginationParams()
                        {
                            PageIndex = pageIndex,
                            PageSize = (short)pageSize
                        });

                return View(users);
            }
        }

        public async Task<IActionResult> Details(long id)
        {
            var entity = await _userService.GetAsync(u => u.Id == id);
            
            return View(entity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreationDto dto) 
        {
            if (dto is null || !ModelState.IsValid)
            {
                return View(dto);
            }

            await this._userService.CreateAsync(dto);
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long id)
        {
            var entity = await this._userService.GetAsync(u => u.Id == id);
            return View(entity);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var isDeleted = await this._userService.DeleteAsync(u => u.Id == id);

            if (isDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(long id)
        {
            var entity = await this._userService.GetAsync(u => u.Id == id);
            return View(entity);
        }

        [ActionName("Edit")]
        [HttpPost]
        public async Task<IActionResult> EditAsync(long id, UserDto dto)
        {
            var updatedEntity = await this._userService.UpdateAsync(u => u.Id == id, dto);

            if (updatedEntity is null)
            {
                return View(updatedEntity);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
