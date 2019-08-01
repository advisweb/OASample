using OASample.Data;
using OASample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Service
{
    public interface IUserProfileService
    {
        void Update(UserProfile entity);
        void Add(UserProfile entity);
    }
}
