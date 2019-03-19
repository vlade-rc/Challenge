
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GBM.Infrastructure.COR
{
  [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ResponseBaseDto <T> 
    {
      
        public T ResultItem { get; set; }
        
        public List<ValidationMessage> Errors { get; set; }


    }
}
