namespace VirtualBusinessCard.Service.Interfaces;
using VirtualBusinessCard.Domain.Entities;
using VirtualBusinessCard.Service.DTOs.User;

public interface IUserService
{
    public Task<bool> RemoveAsync(long id);  
    public Task<UserForResultDto> GetById(long id);
    public Task<List<UserForResultDto>> GetAllAsync();
    public Task<UserForResultDto> UpdateAsync(UserForUpdateDto dto);
    public Task<UserForResultDto> CreateAsync(UserForCreationDto dto);
    public Task GenerateIdAsync();
}
