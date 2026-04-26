using System;
using System.ComponentModel.DataAnnotations;

namespace MovieShop.MVC.Models
{
    public class RegisterRequestModel
    {
        [Required, MaxLength(128)]
        public string FirstName { get; set; }

        [Required, MaxLength(128)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}