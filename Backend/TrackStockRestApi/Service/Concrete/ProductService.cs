using System.Linq.Expressions;
using TrackStockRestApi.Core.Repository;
using TrackStockRestApi.Core.Utilities.Result;
using TrackStockRestApi.Models;
using TrackStockRestApi.Service.Abstract;
using IResult = TrackStockRestApi.Core.Utilities.Result.IResult;
namespace TrackStockRestApi.Service.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBaseRepository<Product> _baseRepository;

        public ProductService(IBaseRepository<Product> baseRepository, IUnitOfWork unitOfWork)
        {
            _baseRepository = baseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> Add(Product entity)
        {
            await _baseRepository.Add(entity);
            await _unitOfWork.SaveChangesAsync();

            return new SuccessResult("Ürün başarıyla eklendi.");
        }

        public async Task<IResult> Delete(Guid id)
        {
            await _baseRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("ürün başarıyla silindi");
        }

        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var data = _baseRepository.GetAll(filter);
            return new SuccessDataResult<List<Product>>(data, " ürünler başarı ile listelendi");
        }

        public IDataResult<Product> GetById(Guid id)
        {
            var data = _baseRepository.Get(x => x.Id == id);
            return new SuccessDataResult<Product>(data, " ürün başarı ile listelendi");
        }

        public async Task<IResult> Update(Product entity)
        {
           await _baseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessResult("ürün başarıyla güncellendi");
        }
    }
}
