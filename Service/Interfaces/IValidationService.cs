namespace VirtualBusinessCard.Service.Interfaces;
using VirtualBusinessCard.Domain.Entities;


public interface IValidationService
{
    bool ValidateBusinessCard(BusinessCard card);
    bool ValidateContact(Contact contact);
    bool ValidateUser(User user);
}
