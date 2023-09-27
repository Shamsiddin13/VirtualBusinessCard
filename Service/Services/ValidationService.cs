namespace VirtualBusinessCard.Service.Services;
using VirtualBusinessCard.Domain.Entities;


public class ValidationService
{
    public IEnumerable<string> ValidateUser(User user)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(user.FirstName))
        {
            errors.Add("First name is required.");
        }

        if (string.IsNullOrWhiteSpace(user.LastName))
        {
            errors.Add("Last name is required.");
        }

        if (string.IsNullOrWhiteSpace(user.Password))
        {
            errors.Add("Password is required.");
        }
        else if (user.Password.Length < 8)
        {
            errors.Add("Password must be at least 8 characters long.");
        }

        return errors;
    }

    public IEnumerable<string> ValidateBusinessCard(BusinessCard businessCard)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(businessCard.Company))
        {
            errors.Add("Company name is required.");
        }

        if (string.IsNullOrWhiteSpace(businessCard.Address))
        {
            errors.Add("Address is required.");
        }

        return errors;
    }

    public IEnumerable<string> ValidateContact(Contact contact)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(contact.Email))
        {
            errors.Add("Email is required.");
        }
        else if (!IsValidEmail(contact.Email))
        {
            errors.Add("Invalid email format.");
        }

        if (string.IsNullOrWhiteSpace(contact.PhoneNumber))
        {
            errors.Add("Phone number is required.");
        }

        return errors;
    }

   
    private bool IsValidEmail(string email)
    {
      
        return true;
    }
}
