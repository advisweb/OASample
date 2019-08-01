using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Repo.Mapping
{
    public interface IEntityMapping<T> where T : class
    {
        void ConfigureModel(EntityTypeBuilder<T> entity);
    }
}
