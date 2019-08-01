using OASample.Data.Entity;
using OASample.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Repo.Extensions
{
    public static class UserViewModelExtensions
    {
        public static User MapToEntity(this UserViewModel vm)
        {
            User user = new User()
            {
                UserName = vm.UserName,
                UserProfile = new UserProfile()
                {
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Address = vm.Address,
                    IsActive = vm.IsActive,
                    IsRemoved = vm.IsRemoved
                },
                Email = vm.Email
            };
            return user;
        }
    }
}
