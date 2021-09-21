using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Contact
    {

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        public string Email { get; set; }

        public string Organization { get; set; }

        public int ContactId { get; set; }


        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
