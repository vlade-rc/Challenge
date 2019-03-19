
namespace GBM.Infrastructure.COR
{
    using Filter;
    public  class RequestQueryBaseDto<T>  where T : IFilter
    {
        public T Filter { get; set; }

    }
}
