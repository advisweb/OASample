using OASample.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Repo.Mapping
{
    public class EntityMappingFactory
    {
        public IEntityMapping<T> CreateMappingFactory<T>() where T : BaseEntity
        {
            if (typeof(T) == typeof(User))
                return (IEntityMapping<T>)new UserMapping();
            else if (typeof(T) == typeof(UserProfile))
                return (IEntityMapping<T>)new UserProfileMapping();
            else
                return null;
        }
    }
}
