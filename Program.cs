using Microsoft.Data.SqlClient;
using VirtualBusinessCard.Data.IRepositories;
using VirtualBusinessCard.Data.Repositories;
using VirtualBusinessCard.Domain.Entities;

namespace VirtualBusinessCard;
class Program
{
    static void Main(string[] args)
    {
        UI uI = new UI();
        uI.Print();
    }
}
