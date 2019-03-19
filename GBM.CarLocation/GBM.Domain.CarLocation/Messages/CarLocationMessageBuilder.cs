using ERMX.Infrastructure.Utils.Serializer;
using GBM.Domain.CarLocation.Messages;
using GBM.Infrastructure.COR;
using GBM.Infrastructure.Messages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBM.CarLocation.Domain.Messages
{
    public class CarLocationMessageBuilder : MessageBuilder
    {
        public override void Clean()
        {
            if(Messages!= null)
            {
                Messages.Clear();
            }
        }

        public override void Initialize()
        {
            this.Clean();
            try
            {
                SetMessages( new Dictionary<string, ValidationMessage>());
                var jsonMessages = LoadJsonMessages();
                foreach (var item in jsonMessages)
                {
                    Messages.Add(item.Code, item);

                }
            }
            catch(Exception exception)
            {
                throw;
            }
           

          
        }


        private List<ValidationMessage> LoadJsonMessages()
        {
            List<ValidationMessage> items = new List<ValidationMessage>();
            string[] fileEntries = Directory.GetFiles(string.Format(@"{0}\bin\Messages", System.AppDomain.CurrentDomain.BaseDirectory), "*.Messages.json");
            foreach (string fileName in fileEntries)
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    string json = r.ReadToEnd();
                     var data = Serializers.JsonDeserializer<MessageStructure>(json);
                    if (data != null && data.Messages != null && data.Messages.Any())
                        items.AddRange(data.Messages);
                }
            }
            return items;
            
        }


    }
}
