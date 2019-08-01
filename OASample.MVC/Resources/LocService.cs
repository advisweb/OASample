using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OASample.MVC.Resources
{
    public class LocService
    {
        private readonly IStringLocalizer localizer;
        public LocService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assembly = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            this.localizer = factory.Create("SharedResource", assembly.Name);
        }

        public LocalizedString GetLocalizedString(string key)
        {
            return localizer[key];
        }
    }
}
