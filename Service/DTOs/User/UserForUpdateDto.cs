﻿namespace VirtualBusinessCard.Service.DTOs.User;

public class UserForUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}
