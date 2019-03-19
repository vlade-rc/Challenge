
namespace GBM.Infrastructure.Logger.Base
{
    public class TraceLog<T> where T : class
    {
        

        public string Operation
        {
            get; set;
        }

        public string Tag
        {
            get; set;
        }

        public string ApplicationName
        {
            get; set;
        }

        public T Content

        {
            get; set;
        }
    }
}
