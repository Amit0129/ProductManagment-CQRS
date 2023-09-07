using ProductManagment_CQRS.Entity;
using ProductManagment_CQRS.Model.Query;

namespace ProductManagment_CQRS.Interface
{
    public interface IQueryService
    {
        public IEnumerable<ProductEntity> GetAll();
        public GetProductModel GetProductById(int id);
    }
}
