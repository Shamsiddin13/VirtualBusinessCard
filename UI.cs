using VirtualBusinessCard.Service.DTOs.BusinessCard;
using VirtualBusinessCard.Service.DTOs.Contact;
using VirtualBusinessCard.Service.DTOs.User;
using VirtualBusinessCard.Service.Services;
using VirtualBusinessCard.Service.DTOs;

namespace VirtualBusinessCard;
public class UI
{
    public void Print()
    {
        try
        {
            while (true)
            {
                Console.WriteLine("\t\t\t\t\t  Assalomu Alaykum !\n\n\t\t\t\t\t     WELCOME TO !\n\n\t\t\t\t\tVIRTUAL BUSINESS CARD");
                Console.WriteLine();
                Console.WriteLine("1 => User");
                Console.WriteLine("2 => BusinessCard");
                Console.WriteLine("3 => Contact");
                Console.WriteLine("4 => Exit\n");
                int num = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (num)
                {
                    case 1:
                        UserPrint();
                        break;
                    case 2:
                        BusinessCardPrint();
                        break;
                    case 3:
                        ContactPrint();
                        break;
                    case 4:
                        return;
                    default:
                        break;
                }
            }
        }
        catch (Exception)
        {

            throw;
        }
    }


    public void UserPrint()
    {
        UserService userService = new UserService();
        try
        {

            while (true)
            {
                Console.WriteLine("1 => Create");
                Console.WriteLine("2 => GetById");
                Console.WriteLine("3 => GetAll");
                Console.WriteLine("4 => Remove");
                Console.WriteLine("5 => Update");
                Console.WriteLine("6 => Exit");
                Console.WriteLine();
                int num = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (num)
                {
                    case 1:
                        UserForCreationDto user = new UserForCreationDto();
                        Console.WriteLine("Enter the FirstName");
                        user.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter the LastName");
                        user.LastName = Console.ReadLine();
                        Console.WriteLine("Enter the Password");
                        user.Password = Console.ReadLine();
                        var newUser = userService.CreateAsync(user);
                        Console.WriteLine();
                        Console.WriteLine("User Id: " + newUser.Result.Id);
                        Console.WriteLine("User FirstName: " + newUser.Result.FirstName);
                        Console.WriteLine("User LastName: " + newUser.Result.LastName);
                        Console.WriteLine("User Password: " + newUser.Result.Password);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter the Id");
                        long id = long.Parse(Console.ReadLine());
                        var result = userService.GetByIdAsync(id).Result;
                        if (result != null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("User Id: " + result.Id);
                            Console.WriteLine("User FirstName: " + result.FirstName);
                            Console.WriteLine("User LastName: " + result.LastName);
                            Console.WriteLine("User Password: " + result.Password);
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("User is not found");
                        }
                        break;
                    case 3:
                        foreach (var item in userService.GetAllAsync().Result)
                        {
                            Console.WriteLine();
                            Console.WriteLine("User Id: " + item.Id);
                            Console.WriteLine("User FirstName: " + item.FirstName);
                            Console.WriteLine("User LastName: " + item.LastName);
                            Console.WriteLine("User Password: " + item.Password);
                            Console.WriteLine();
                        }
                        break;
                    case 4:

                        Console.WriteLine("Enter the Id");
                        Console.WriteLine(userService.RemoveAsync(long.Parse(Console.ReadLine())).Result);

                        break;
                    case 5:

                        UserForUpdateDto userForUpdateDto = new UserForUpdateDto();
                        Console.WriteLine("Enter the Id");
                        userForUpdateDto.Id = long.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the FirstName");
                        userForUpdateDto.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter the LastName");
                        userForUpdateDto.LastName = Console.ReadLine();
                        Console.WriteLine("Enter the Password");
                        userForUpdateDto.Password = Console.ReadLine();
                        var Userresult = userService.UpdateAsync(userForUpdateDto).Result;
                        Console.WriteLine();
                        Console.WriteLine("User Id: " + Userresult.Id);
                        Console.WriteLine("User FirstName: " + Userresult.FirstName);
                        Console.WriteLine("User LastName: " + Userresult.LastName);
                        Console.WriteLine("User Password: " + Userresult.Password);
                        Console.WriteLine();

                        break;
                    case 6:
                        return;

                    default:
                        break;
                }

            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

    }


    public void BusinessCardPrint()
    {
        BusinessCardService businessCardService = new BusinessCardService();

        while (true)
        {
            Console.WriteLine("1 => Create");
            Console.WriteLine("2 => GetById");
            Console.WriteLine("3 => GetAll");
            Console.WriteLine("4 => Remove");
            Console.WriteLine("5 => Update");
            Console.WriteLine("6 => Exit");
            Console.WriteLine();
            int num = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (num)
            {
                case 1:
                    BusinessCardForCreationDto businessCardForCreationDto = new BusinessCardForCreationDto();
                    Console.WriteLine("Enter the Title");
                    businessCardForCreationDto.Title = Console.ReadLine();
                    Console.WriteLine("Enter the Company");
                    businessCardForCreationDto.Company = Console.ReadLine();
                    Console.WriteLine("Enter the Website");
                    businessCardForCreationDto.Website = Console.ReadLine();
                    Console.WriteLine("Enter the Address");
                    businessCardForCreationDto.Address = Console.ReadLine();
                    Console.WriteLine("Enter the ImageUrl");
                    businessCardForCreationDto.ImageUrl = Console.ReadLine();
                    Console.WriteLine("Enter the Description");
                    businessCardForCreationDto.Description = Console.ReadLine();

                    var resultDto = businessCardService.CreateAsync(businessCardForCreationDto).Result;

                    Console.WriteLine();

                    Console.WriteLine("User Id: " + resultDto.Id);
                    Console.WriteLine("User UserId: " + resultDto.UserId);
                    Console.WriteLine("User Title: " + resultDto.Title);
                    Console.WriteLine("User Company: " + resultDto.Company);
                    Console.WriteLine("User Website: " + resultDto.Website);
                    Console.WriteLine("User Address: " + resultDto.Address);
                    Console.WriteLine("User ImageUrl: " + resultDto.ImageUrl);
                    Console.WriteLine("User Description: " + resultDto.Description);

                    Console.WriteLine();

                    break;
                case 2:
                    Console.WriteLine("Enter the Id");
                    long id = long.Parse(Console.ReadLine());
                    var result = businessCardService.GetByIdAsync(id).Result;
                    if (result != null)
                    {
                        Console.WriteLine();

                        Console.WriteLine("User Id: " + result.Id);
                        Console.WriteLine("User UserId: " + result.UserId);
                        Console.WriteLine("User Title: " + result.Title);
                        Console.WriteLine("User Company: " + result.Company);
                        Console.WriteLine("User Website: " + result.Website);
                        Console.WriteLine("User Address: " + result.Address);
                        Console.WriteLine("User ImageUrl: " + result.ImageUrl);
                        Console.WriteLine("User Description: " + result.Description);

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("User is not found");
                    }
                    break;
                case 3:
                    foreach (var item in businessCardService.GetAllAsync().Result)
                    {
                        Console.WriteLine();

                        Console.WriteLine("User Id: " + item.Id);
                        Console.WriteLine("User UserId: " + item.UserId);
                        Console.WriteLine("User Title: " + item.Title);
                        Console.WriteLine("User Company: " + item.Company);
                        Console.WriteLine("User Website: " + item.Website);
                        Console.WriteLine("User Address: " + item.Address);
                        Console.WriteLine("User ImageUrl: " + item.ImageUrl);
                        Console.WriteLine("User Description: " + item.Description);

                        Console.WriteLine();
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the Id");
                    Console.WriteLine(businessCardService.RemoveAsync(long.Parse(Console.ReadLine())).Result);

                    break;
                case 5:

                    BusinessCardForUpdateDto businessCardForUpdateDto = new BusinessCardForUpdateDto();

                    Console.WriteLine("Enter the Id");
                    businessCardForUpdateDto.Id = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Title");
                    businessCardForUpdateDto.Title = Console.ReadLine();
                    Console.WriteLine("Enter the Company");
                    businessCardForUpdateDto.Company = Console.ReadLine();
                    Console.WriteLine("Enter the Website");
                    businessCardForUpdateDto.Website = Console.ReadLine();
                    Console.WriteLine("Enter the Address");
                    businessCardForUpdateDto.Address = Console.ReadLine();
                    Console.WriteLine("Enter the ImageUrl");
                    businessCardForUpdateDto.ImageUrl = Console.ReadLine();
                    Console.WriteLine("Enter the Description");
                    businessCardForUpdateDto.Description = Console.ReadLine();

                    var resultDtos = businessCardService.UpdateAsync(businessCardForUpdateDto).Result;

                    Console.WriteLine();

                    Console.WriteLine("User Id: " + resultDtos.Id);
                    Console.WriteLine("User UserId: " + resultDtos.UserId);
                    Console.WriteLine("User Title: " + resultDtos.Title);
                    Console.WriteLine("User Company: " + resultDtos.Company);
                    Console.WriteLine("User Website: " + resultDtos.Website);
                    Console.WriteLine("User Address: " + resultDtos.Address);
                    Console.WriteLine("User ImageUrl: " + resultDtos.ImageUrl);
                    Console.WriteLine("User Description: " + resultDtos.Description);

                    Console.WriteLine();

                    break;
                case 6:
                    return;
                default:
                    break;
            }
        }
    }


    public void ContactPrint()
    {
        ContactService contactService = new ContactService();

        while (true)
        {
            Console.WriteLine("1 => Create");
            Console.WriteLine("2 => GetById");
            Console.WriteLine("3 => GetAll");
            Console.WriteLine("4 => Remove");
            Console.WriteLine("5 => Update");
            Console.WriteLine("6 => Exit");
            Console.WriteLine();
            int num = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (num)
            {
                case 1:
                    ContactForCreationDto contactForCreationDto = new ContactForCreationDto();

                    Console.WriteLine("Enter the JobTitle");
                    contactForCreationDto.PhoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter the Companty");
                    contactForCreationDto.Email = Console.ReadLine();
                    Console.WriteLine("Enter the Website");
                    contactForCreationDto.JobTitle = Console.ReadLine();

                    var resultDto = contactService.CreateAsync(contactForCreationDto).Result;

                    Console.WriteLine();

                    Console.WriteLine("User Id: " + resultDto.Id);
                    Console.WriteLine("User BusinnessCardId: " + resultDto.BusinessCardId);
                    Console.WriteLine("User UserId: " + resultDto.PhoneNumber);
                    Console.WriteLine("User JobTitle: " + resultDto.Email);
                    Console.WriteLine("User Company: " + resultDto.JobTitle);
         
                    Console.WriteLine();

                    break;
                case 2:
                    Console.WriteLine("Enter the Id");
                    long id = long.Parse(Console.ReadLine());
                    var result = contactService.GetByIdAsync(id).Result;
                    if (result != null)
                    {
                        Console.WriteLine();

                        Console.WriteLine("User Id: " + result.Id);
                        Console.WriteLine("User BusinnessCardId: " + result.BusinessCardId);
                        Console.WriteLine("User UserId: " + result.PhoneNumber);
                        Console.WriteLine("User JobTitle: " + result.Email);
                        Console.WriteLine("User Company: " + result.JobTitle);

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("User is not found");
                    }
                    break;
                case 3:
                    foreach (var item in contactService.GetAllAsync().Result)
                    {
                        Console.WriteLine();

                        Console.WriteLine("User Id: " + item.Id);
                        Console.WriteLine("User BusinnessCardId: " + item.BusinessCardId);
                        Console.WriteLine("User UserId: " + item.PhoneNumber);
                        Console.WriteLine("User JobTitle: " + item.Email);
                        Console.WriteLine("User Company: " + item.JobTitle);

                        Console.WriteLine();
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter the Id");
                    Console.WriteLine(contactService.RemoveAsync(long.Parse(Console.ReadLine())).Result);

                    break;
                case 5:

                    ContactForUpdateDto contactForUpdateDto = new ContactForUpdateDto();

                    Console.WriteLine("Enter the Id");
                    contactForUpdateDto.Id = long.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the JobTitle");
                    contactForUpdateDto.PhoneNumber = Console.ReadLine();
                    Console.WriteLine("Enter the Companty");
                    contactForUpdateDto.Email = Console.ReadLine();
                    Console.WriteLine("Enter the Website");
                    contactForUpdateDto.JobTitle = Console.ReadLine();

                    var resultDtos = contactService.UpdateAsync(contactForUpdateDto).Result;

                    Console.WriteLine();

                    Console.WriteLine("User Id: " + resultDtos.Id);
                    Console.WriteLine("User BusinnessCardId: " + resultDtos.BusinessCardId);
                    Console.WriteLine("User UserId: " + resultDtos.PhoneNumber);
                    Console.WriteLine("User JobTitle: " + resultDtos.Email);
                    Console.WriteLine("User Company: " + resultDtos.JobTitle);

                    Console.WriteLine();

                    break;
                case 6:
                    return;
                default:
                    break;
            }
        }
    }


}

