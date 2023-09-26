using VirtualBusinessCard.Service.DTOs.Contact;

namespace VirtualBusinessCard.Service.Interfaces
{
    public interface IContactService
    {
        public Task<bool> RemoveAsync(long id);
        public Task<List<ContactForResultDto>> GetAllAsync();
        public Task<ContactForResultDto> GetByIdAsync(long id);
        public Task<ContactForResultDto> UpdateAsync(ContactForUpdateDto dto);
        public Task<ContactForResultDto> CreateAsync(ContactForCreationDto dto);
        public Task GenerateIdAsync();
    }
}
