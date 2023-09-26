using VirtualBusinessCard.Service.DTOs.BusinessCard;
using VirtualBusinessCard.Data.IRepositories;
using VirtualBusinessCard.Service.Exceptions;
using VirtualBusinessCard.Service.Interfaces;
using VirtualBusinessCard.Data.Repositories;
using VirtualBusinessCard.Domain.Entities;
using VirtualBusinessCard.Service.DTOs;

namespace VirtualBusinessCard.Service.Services;

public class BusinessCardService : IBusinessCardService
{
    private long _id;
    private readonly IRepository<BusinessCard> businessCardRepository = new Repository<BusinessCard>();
    public async Task<BusinessCardForResultDto> CreateAsync(BusinessCardForCreationDto dto)
    {
        var businessCard = (await businessCardRepository.SelectAllAsync())
            .FirstOrDefault(b =>
            b.UserId == dto.UserId);
        if (businessCard != null)
            throw new VirtualBusinessCardException(409, "BusinessCard is already exist");

        BusinessCard newbusinessCard = new BusinessCard()
        {
            Id = _id,
            UserId = dto.UserId,
            Title = dto.Title,
            Company = dto.Company,
            CreatedAt = DateTime.UtcNow,
        };
        await businessCardRepository.InsertAsync(newbusinessCard);

        var result = new BusinessCardForResultDto()
        {
            Id = _id,
            UserId = newbusinessCard.UserId,
            Title = newbusinessCard.Title,
            Company = newbusinessCard.Company,
        };

        return result;
    }

    public async Task GenerateIdAsync()
    {
        var businessCards = await businessCardRepository.SelectAllAsync();
        if (businessCards.Count == 0)
        {
            this._id = 1;
        }
        else
        {
            var businessCard = businessCards[businessCards.Count - 1];
            this._id = ++businessCard.Id;
        }
    }

    public async Task<List<BusinessCardForResultDto>> GetAllAsync()
    {
        var businessCards = await businessCardRepository.SelectAllAsync();
        List<BusinessCardForResultDto> mappedBusinessCards = new List<BusinessCardForResultDto>();

        foreach (var businessCard in businessCards)
        {
            BusinessCardForResultDto dto = new BusinessCardForResultDto()
            {
                Id = businessCard.Id,
                UserId = businessCard.UserId,
                Title = businessCard.Title,
                Company = businessCard.Company,
            };
            mappedBusinessCards.Add(dto);
        }
        return mappedBusinessCards;
    }

    public async Task<BusinessCardForResultDto> GetByIdAsync(long id)
    {
        var businessCard = await businessCardRepository.SelectByIdAsync(id);
        if (businessCard is null)
            throw new VirtualBusinessCardException(404, "BusinessCard is not found");

        var result = new BusinessCardForResultDto()
        {
            Id = businessCard.Id,
            UserId = businessCard.UserId,
            Title = businessCard.Title,
            Company = businessCard.Company,
        };

        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var businessCard = await businessCardRepository.SelectByIdAsync(id);
        if (businessCard is null)
            throw new VirtualBusinessCardException(404, "BusinessCard is not found");

        await businessCardRepository.DeleteAsync(id);
        return true;
    }

    public async Task<BusinessCardForResultDto> UpdateAsync(BusinessCardForUpdateDto dto)
    {
        var businessCards = businessCardRepository.SelectByIdAsync(dto.Id);
        if (businessCards is null)
            throw new VirtualBusinessCardException(404, "BusinessCard is not found");

        var mappedBusinessCard = new BusinessCard()
        {
            Id = dto.Id,
            UserId = dto.UserId,
            Title = dto.Title,
            Company = dto.Company,
            UpdateAt = DateTime.UtcNow
        };
        await businessCardRepository.UpdateAsync(mappedBusinessCard);

        var result = new BusinessCardForResultDto()
        {
            Id = mappedBusinessCard.Id,
            UserId = mappedBusinessCard.UserId,
            Title = mappedBusinessCard.Title,
            Company = mappedBusinessCard.Company
        };

        return result;
    }
}
