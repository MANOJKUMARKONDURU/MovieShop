using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string Email { get; set; }

        [Required, MaxLength(1024)]
        public string HashedPassword { get; set; }

        [MaxLength(1024)]
        public string Salt { get; set; }

        [Required, MaxLength(128)]
        public string FirstName { get; set; }

        [Required, MaxLength(128)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
        public ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}