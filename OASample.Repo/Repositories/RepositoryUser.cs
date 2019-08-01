using Microsoft.EntityFrameworkCore;
using OASample.Data;
using OASample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OASample.Repo.Repositories
{
    public class RepositoryUser : Repository<User>
    {
        public RepositoryUser(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
