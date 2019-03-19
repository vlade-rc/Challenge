using Microsoft.AspNet.WebHooks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GBM.HookProvider.Api.Hook
{

    public class GBMCarLocationFilterProvider : IWebHookFilterProvider
    {
        private readonly Collection<WebHookFilter> filters =
            new Collection<WebHookFilter>
            {
                new WebHookFilter
                {
                    Name = "UpdatedLocation",
                    Description = "Se actualiza la ubicación de un coche"
                }
            };
        public Task<Collection<WebHookFilter>> GetFiltersAsync()
        {
            return Task.FromResult(this.filters);
        }
    }
}