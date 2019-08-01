using OASample.Data.Entity;
using OASample.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OASample.Repo.Converter
{
    public interface IEntityConverter<TInput, TOutput>
    {
        TOutput Convert(TInput entity);
    }
}
