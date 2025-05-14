using TrackStockRestApi.Core.Service;
using TrackStockRestApi.Models;

namespace TrackStockRestApi.Service.Abstract
{
    public interface IProductService : IBaseService<Product, Guid>
    {
    }
}
