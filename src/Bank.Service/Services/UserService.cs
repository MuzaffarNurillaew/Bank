using AutoMapper;
using Bank.Data.DbContexts;
using Bank.Data.IRepositories;
using Bank.Domain.Configuration;
using Bank.Domain.Entities;
using Bank.Service.Dtos.Users;
using Bank.Service.Exceptions;
using Bank.Service.Interfaces;
using System.Linq.Expressions;

namespace Bank.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(UserCreationDto userDto)
        {
            var entity = await _userRepository.SelectAsync(user 
                => user.Email == userDto.Email || user.Phone == userDto.Phone);
        
            if (entity is not null)
            {
                throw new CustomException(400, "User Already exists");
            }
            
            User entityToInsert = _mapper.Map<User>(userDto);
            
            try
            {
                var insertedUser = await _userRepository.InsertAsync(entityToInsert);
                var result = _mapper.Map<UserDto>(insertedUser);

                await _userRepository.SaveAsync();
                return result;
            }
            catch
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var isDeleted = await _userRepository.DeleteAsync(expression);
            if (!isDeleted)
                throw new CustomException(404, "Matching user not found");

            await _userRepository.SaveAsync();
            return isDeleted;
        }

        public Task<IEnumerable<UserDto>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetAsync(Expression<Func<User, bool>> expression)
        {
            var entity = await _userRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> UpdateAsync(Expression<Func<User, bool>> expression, UserCreationDto userDto)
        {
            var entity = await _userRepository.SelectAsync(expression);

            if (entity is null)
                throw new CustomException(404, "Matching user not found");

            _mapper.Map(userDto, entity, typeof(UserDto), typeof(User));

            var updatedEntity = await _userRepository.UpdateAsync(entity);
            await _userRepository.SaveAsync();

            return _mapper.Map<UserDto>(updatedEntity);
        }
    }
}
