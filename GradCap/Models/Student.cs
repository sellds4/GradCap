using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradCap.Models
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ICollection<School> FavoriteSchools { get; set; }
        public ICollection<School> NoInterestSchools { get; set; }
    }
}