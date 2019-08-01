using Microsoft.EntityFrameworkCore;
using OASample.Data;
using OASample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Repo.Repositories
{
    public class RepositoryUserProfile : Repository<UserProfile>
    {
        public RepositoryUserProfile(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
