using System.Linq.Expressions;
using TrackStockRestApi.Core.Utilities.Result;
using IResult = TrackStockRestApi.Core.Utilities.Result.IResult;
namespace TrackStockRestApi.Core.Service
{
    public interface IBaseService<T, I>
    {
        Task<IResult> Add(T entity);
        Task<IResult> Delete(I id);
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        IDataResult<T> GetById(I id);
        Task<IResult> Update(T entity);
    }
}
