using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OASample.Data.Entity
{
    public class UserProfile : BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Firstname")]
        public string FirstName { get; set; }

        [DisplayName("Lastname")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public bool IsRemoved { get; set; }

        public bool IsActive { get; set; }

        //setup 1 to 1 relationship with user
        public User User { get; set; }
    }


}
