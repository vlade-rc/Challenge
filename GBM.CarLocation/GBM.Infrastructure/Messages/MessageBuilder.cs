
using GBM.Infrastructure.COR;
using System.Collections.Generic;

namespace GBM.Infrastructure.Messages
{
    public abstract class MessageBuilder
    {

        public  abstract void Initialize();
        protected Dictionary<string, ValidationMessage> Messages { get; private set; }

        protected void SetMessages(Dictionary<string, ValidationMessage> messagesIn)
        {
            Messages = messagesIn;
        }
        public ValidationMessage TryGetMessage(string Key)
        { 

            ValidationMessage message;
            Messages.TryGetValue(Key, out message);
            if (message == null)
            {
                message = new ValidationMessage { Code = "999", Message = "Udefined Message" };
            }
            return message;
        }
        public abstract void Clean();
    }
}
