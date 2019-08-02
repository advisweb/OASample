using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OASample.Data.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredFirstname_ErrorMessage")]
        [DisplayName("Firstname")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Lastname")]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Address { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
    }
}
