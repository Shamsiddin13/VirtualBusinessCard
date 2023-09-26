using VirtualBusinessCard.Domain.Entities;
namespace VirtualBusinessCard.Service.Interfaces
{
    public interface IBusinessLogicManager
    {
        void ShareBusinessCard(User sender, User recipient, BusinessCard card);
        List<BusinessCard> SearchBusinessCards(string query);
        byte[] GenerateQRCode(BusinessCard card);
        bool SendEmailWithBusinessCard(User sender, User recipient, BusinessCard card);

    }
}
