using OASample.Data.Entity;
using OASample.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Repo.Converter
{
    public class ConvertUserToUserVM : IEntityConverter<User, UserViewModel>
    {
        public UserViewModel Convert(User entity)
        {
            return new UserViewModel();
        }
    }
}
