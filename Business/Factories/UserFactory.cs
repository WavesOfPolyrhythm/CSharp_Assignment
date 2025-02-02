﻿using Business.Entities;
using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public class UserFactory
{

    //Creates a UserEntity object from UserRegistrationForm. 
    public static UserEntity Create (UserRegistrationForm userRegistrationForm)
    {
        return new UserEntity
        {
            FirstName = userRegistrationForm.FirstName,
            LastName = userRegistrationForm.LastName,
            PhoneNumber = userRegistrationForm.PhoneNumber,
            Email = userRegistrationForm.Email,
            Address = userRegistrationForm.Address,
            City = userRegistrationForm.City,

            //Generating a unique ID for the UserEntity object using the IdentifierGenerator
            Id = IdentifierGenerator.GenerateUniqueId()
        };
    }
}
