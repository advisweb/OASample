using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;

namespace OASample.Data.Entity
{
    public class User : BaseEntity
    {
        public int Id { get; set; }        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsActive { get; set; }

        //setup 1 to 1 with user profile
        public UserProfile UserProfile { get; set; }

    }


}
