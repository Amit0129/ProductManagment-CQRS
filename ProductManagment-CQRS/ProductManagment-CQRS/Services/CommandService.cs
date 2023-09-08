using ProductManagment_CQRS.Entity;
using ProductManagment_CQRS.Interface;
using ProductManagment_CQRS.Model.Command;

namespace ProductManagment_CQRS.Services
{
    public class CommandService : ICommandService
    {
        private readonly ProductDBContext context;
        public CommandService(ProductDBContext context)
        {
            this.context = context;
        }

        public int AddProduct(InsertUpdateModel newProduct)
        {
            try
            {
                ProductEntity product = new ProductEntity()
                {
                    ProductId = newProduct.ProductId,
                    ProductName = newProduct.ProductName,
                    Qty = newProduct.Qty,
                    Price = newProduct.Price,
                    AddedBy = newProduct.AddedBy,
                    AddedOn = DateTime.Now
                };
                context.Products.Add(product);
                var result = context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public bool UpdateProduct(InsertUpdateModel newProduct,int id)
        {
            try
            {
                ProductEntity product = new ProductEntity();
                product = context.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return false;
                }
                product.ProductId = newProduct.ProductId;
                product.ProductName = newProduct.ProductName;
                product.Qty = newProduct.Qty;
                product.Price = newProduct.Price;
                product.AddedBy = newProduct.AddedBy;
                product.AddedOn = DateTime.Now;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
