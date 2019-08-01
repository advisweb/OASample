using OASample.Data;
using OASample.Data.Entity;
using OASample.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Service
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetUsers();
        void AddUser(UserViewModel entity);
        void UpdateUser(UserViewModel entity);
        void DeleteUser(UserViewModel vm);
        UserViewModel GetUserById(int id);
    }
}
