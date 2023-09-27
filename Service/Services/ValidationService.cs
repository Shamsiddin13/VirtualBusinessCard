using VirtualBusinessCard.Domain.Entities;
using System.Text.RegularExpressions;

namespace VirtualBusinessCard.Service.Services;
public class ValidationService
{
    public bool ValidateBusinessCard(BusinessCard card)
    {
        if (card == null)
        {
            // Handle the case where the card is null (e.g., throw an exception or return false)
            return false;
        }

        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(card.Company))
        {
            errors.Add("Company name is required.");
        }

        if (string.IsNullOrWhiteSpace(card.Address))
        {
            errors.Add("Address is required.");
        }

        if (string.IsNullOrWhiteSpace(card.Website))
        {
            errors.Add("Website URL is required.");
        }
        else if (!IsValidUrl(card.Website))
        {
            errors.Add("Invalid website URL format.");
        }

        // Add more validation rules specific to BusinessCard entity

        // Check if there are any validation errors
        if (errors.Count > 0)
        {
            // Handle the validation errors (e.g., log them, return false, or throw an exception)
            // You can also return the list of errors if you need to display them to the user
            return false;
        }

        // Validation passed
        return true;
    }

    public bool ValidateContact(Contact contact)
    {
        if (contact == null)
        {
            // Handle the case where the contact is null (e.g., throw an exception or return false)
            return false;
        }

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

        // Add more validation rules specific to Contact entity

        // Check if there are any validation errors
        if (errors.Count > 0)
        {
            // Handle the validation errors (e.g., log them, return false, or throw an exception)
            // You can also return the list of errors if you need to display them to the user
            return false;
        }

        // Validation passed
        return true;
    }

    public bool ValidateUser(User user)
    {
        if (user == null)
        {
            // Handle the case where the user is null (e.g., throw an exception or return false)
            return false;
        }

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

        // Add more validation rules specific to User entity

        // Check if there are any validation errors
        if (errors.Count > 0)
        {
            // Handle the validation errors (e.g., log them, return false, or throw an exception)
            // You can also return the list of errors if you need to display them to the user
            return false;
        }

        // Validation passed
        return true;
    }

    // Additional utility methods for validation
    public bool IsValidPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            return false; // Password is required
        }

        // Define your password criteria here
        int minLength = 8; // Minimum password length

        // Regular expression pattern to enforce password criteria (example pattern)
        string pattern = "^(?=.*[a-zA-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).+$";

        if (password.Length < minLength)
        {
            return false; // Password is too short
        }

        if (!Regex.IsMatch(password, pattern))
        {
            return false; // Password doesn't meet criteria
        }

        return true; // Password is valid
    }

    public bool IsValidUrl(string url)
    {
        // Implement URL validation logic (e.g., using regular expressions)
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }

    public bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
    }
}
