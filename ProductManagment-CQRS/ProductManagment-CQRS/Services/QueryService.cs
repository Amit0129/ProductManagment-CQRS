using ProductManagment_CQRS.Entity;
using ProductManagment_CQRS.Interface;
using ProductManagment_CQRS.Model.Query;
using System.Linq;

namespace ProductManagment_CQRS.Services
{
    public class QueryService : IQueryService
    {
        private readonly ProductDBContext dBContext;
        public QueryService(ProductDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        //Get All Products
        public IEnumerable<ProductEntity> GetAll()
        {
            try
            {
                return dBContext.Products.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //Get Product By Id
        public GetProductModel GetProductById(int id)
        {
            try
            {
                ProductEntity productFromDb = new ProductEntity();
                productFromDb = dBContext.Products.SingleOrDefault(x => x.Id == id);
                if (productFromDb != null)
                {

                    GetProductModel product = new GetProductModel()
                    {
                        ProductId = productFromDb.ProductId,
                        ProductName = productFromDb.ProductName,
                        Qty = productFromDb.Qty,
                        Price = productFromDb.Price
                    };
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
