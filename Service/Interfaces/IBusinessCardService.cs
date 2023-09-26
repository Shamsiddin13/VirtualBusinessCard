namespace VirtualBusinessCard.Service.Interfaces;
using VirtualBusinessCard.Service.DTOs;
using VirtualBusinessCard.Service.DTOs.BusinessCard;

public interface IBusinessCardService
{
    public Task<bool> RemoveAsync(long id);
    public Task<List<BusinessCardForResultDto>> GetAllAsync();
    public Task<BusinessCardForResultDto> GetByIdAsync(long id);
    public Task<BusinessCardForResultDto> UpdateAsync(BusinessCardForUpdateDto dto);
    public Task<BusinessCardForResultDto> CreateAsync(BusinessCardForCreationDto dto);
    public Task GenerateIdAsync();
}
