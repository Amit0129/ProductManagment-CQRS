using ProductManagment_CQRS.Entity;
using ProductManagment_CQRS.Interface;
using ProductManagment_CQRS.Model.Query;
using System.Linq;

namespace ProductManagment_CQRS.Services
{
    /// <summary>
    /// Query side service class
    /// </summary>
    public class QueryService : IQueryService
    {
        private readonly ProductDBContext dBContext;
        public QueryService(ProductDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        /// <summary>
        /// Get all product from database
        /// </summary>
        /// <returns>All product info</returns>
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

        /// <summary>
        /// Get product info by id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>Product info of a perticular product Id</returns>
        /// <exception cref="Exception"></exception>
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
