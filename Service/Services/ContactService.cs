using VirtualBusinessCard.Service.DTOs.Contact;
using VirtualBusinessCard.Service.Exceptions;
using VirtualBusinessCard.Data.IRepositories;
using VirtualBusinessCard.Service.Interfaces;
using VirtualBusinessCard.Data.Repositories;
using VirtualBusinessCard.Domain.Entities;
using VirtualBusinessCard.Service.DTOs.User;

namespace VirtualBusinessCard.Service.Services;

public class ContactService : IContactService
{
    private long _id;
    private readonly IRepository<Contact> contactRepository = new Repository<Contact>();

    public async Task<ContactForResultDto> CreateAsync(ContactForCreationDto dto)
    {
        var contact = (await contactRepository.SelectAllAsync())
            .FirstOrDefault(c =>
            c.Email.ToLower() == dto.Email.ToLower());
        if (contact != null)
            throw new VirtualBusinessCardException(409, "Contact is already exist");

        Contact newContact = new Contact()
        {
            Id = _id,
            Name = dto.Name,
            Email = dto.Email,
            BusinessCardId = dto.BusinessCardId,
            PhoneNumber = dto.PhoneNumber,
            CreatedAt = DateTime.UtcNow,
        };
        await contactRepository.InsertAsync(newContact);

        var result = new ContactForResultDto()
        {
            Id = _id,
            Name = newContact.Name,
            Email = newContact.Email,
            BusinessCardId = newContact.BusinessCardId,
            PhoneNumber = newContact.PhoneNumber,
        };

        return result;
    }

    public async Task GenerateIdAsync()
    {
        var contacts = await contactRepository.SelectAllAsync();
        if (contacts.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var contact = contacts[contacts.Count - 1];
            this._id = ++contact.Id;
        }
    }

    public async Task<List<ContactForResultDto>> GetAllAsync()
    {
        var contacts = await contactRepository.SelectAllAsync();
        List<ContactForResultDto> mappedContacts = new List<ContactForResultDto>();

        foreach (var contact in contacts)
        {
            ContactForResultDto dto = new ContactForResultDto()
            {
                Id= contact.Id,
                Name = contact.Name,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                BusinessCardId = contact.BusinessCardId,
            };
            mappedContacts.Add(dto);
        }
        return mappedContacts;
    }

    public async Task<ContactForResultDto> GetByIdAsync(long id)
    {
        var contact = await contactRepository.SelectByIdAsync(id);
        if (contact is null)
            throw new VirtualBusinessCardException(404, "Contact is not found");

        var result = new ContactForResultDto()
        {
            Id = contact.Id,
            Name = contact.Name,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            BusinessCardId = contact.BusinessCardId,
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var contact = await contactRepository.SelectByIdAsync(id);
        if (contact is null)
            throw new VirtualBusinessCardException(404, "Contact is not found");

        await contactRepository.DeleteAsync(id);
        return true;
    }

    public async Task<ContactForResultDto> UpdateAsync(ContactForUpdateDto dto)
    {
        var contacts = contactRepository.SelectByIdAsync(dto.Id);
        if (contacts is null)
            throw new VirtualBusinessCardException(404, "Contact is not found");

        var mappedContact = new Contact()
        {
            Id = dto.Id,
            Name = dto.Name,
            Email = dto.Email,
            BusinessCardId = dto.BusinessCardId,
            PhoneNumber = dto.PhoneNumber,
            UpdateAt = DateTime.UtcNow
        };
        await contactRepository.UpdateAsync(mappedContact);

        var result = new ContactForResultDto()
        {
            Id = mappedContact.Id,
            Name = mappedContact.Name,
            Email = mappedContact.Email,
            BusinessCardId = mappedContact.BusinessCardId,
            PhoneNumber = mappedContact.PhoneNumber,
        };

        return result;
    }
}
