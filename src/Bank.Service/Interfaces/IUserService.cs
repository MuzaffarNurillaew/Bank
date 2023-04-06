using Bank.Domain.Entities;
using Bank.Service.Dtos.Users;
using System.Linq.Expressions;

namespace Bank.Service.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserCreationDto userDto);
        Task<UserDto> UpdateAsync(UserCreationDto userDto);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        Task<UserDto> GetAsync(Expression<Func<User, bool>> expression);
    }
}
