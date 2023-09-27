using VirtualBusinessCard.Data.IRepositories;
using VirtualBusinessCard.Service.Interfaces;
using VirtualBusinessCard.Service.Exceptions;
using VirtualBusinessCard.Service.DTOs.User;
using VirtualBusinessCard.Data.Repositories;
using VirtualBusinessCard.Domain.Entities;

namespace VirtualBusinessCard.Service.Services;

public class UserService : IUserService
{
    private long _id;
    private readonly IRepository<User> userRepository = new Repository<User>();
    ValidationService validation = new ValidationService();

    public async Task<UserForResultDto> CreateAsync(UserForCreationDto dto)
    {
        if (validation.IsValidPassword(dto.Password))
        {
            var user = (await userRepository.SelectAllAsync())
                .FirstOrDefault(u =>
                u.Password.ToLower() == dto.Password.ToLower());
            if (user != null)
                throw new VirtualBusinessCardException(409, "User is already exist");
        }
        else
        {
            throw new VirtualBusinessCardException(112, "IsValidPassword pass not");
        }
        await GenerateIdAsync();
        User newUser = new User()
        {
            Id = _id,
            FirstName = dto.FirstName,  
            LastName = dto.LastName,
            Password = dto.Password,
            CreatedAt = DateTime.UtcNow,
        };
        await userRepository.InsertAsync(newUser);

        var result = new UserForResultDto()
        {
            Id = _id,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Password = newUser.Password,
        };

        return result;
    }

    public async Task<List<UserForResultDto>> GetAllAsync()
    {
        var users = await userRepository.SelectAllAsync();
        List<UserForResultDto> mappedUsers = new List<UserForResultDto>();
        
        foreach (var user in users)
        {
            UserForResultDto dto = new UserForResultDto()
            {
                Id = user.Id,
                FirstName = user.FirstName, 
                LastName = user.LastName,
                Password = user.Password,
            };
            mappedUsers.Add(dto);   
        }
        return mappedUsers;
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var user = await userRepository.SelectByIdAsync(id);
        if (user is null)

            throw new VirtualBusinessCardException(404, "User is not found");

        var result = new UserForResultDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password = user.Password,
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await userRepository.SelectByIdAsync(id);
        if (user is null)
            throw new VirtualBusinessCardException(404, "User is not found");
    
        await userRepository.DeleteAsync(id);
        return true;
    }

    public async Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto)
    {
        var users = userRepository.SelectByIdAsync(dto.Id);
        if (users is null)
            throw new VirtualBusinessCardException(404, "User is not found");

        var mappedUser = new User()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Password = dto.Password,
            UpdateAt = DateTime.UtcNow
        };
        await userRepository.UpdateAsync(mappedUser);

        var result = new UserForResultDto()
        {
            Id = mappedUser.Id,
            FirstName = mappedUser.FirstName,
            LastName = mappedUser.LastName,
            Password = mappedUser.Password
        };

        return result;
    }

    public async Task GenerateIdAsync()
    {
        var users = await userRepository.SelectAllAsync();
        if (users.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var user = users[users.Count - 1];
            this._id = ++user.Id;
        }
    }
}
