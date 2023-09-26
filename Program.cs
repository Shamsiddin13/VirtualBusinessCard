using Microsoft.Data.SqlClient;
using VirtualBusinessCard.Data.IRepositories;
using VirtualBusinessCard.Data.Repositories;
using VirtualBusinessCard.Domain.Entities;

namespace VirtualBusinessCard;
class Program
{
    static async Task Main(string[] args)
    {
        IRepository<Contact> contactRepository = new Repository<Contact>();

        await contactRepository.InsertAsync(new Contact()
        {
            Id = 1,
            BusinessCardId = 2,
            Name = "Shamsiddin",
            PhoneNumber = "998914995906",
            Email = "shamsiddin13@gmail.com",
            CreatedAt = DateTime.Now,
        });



    }
}
