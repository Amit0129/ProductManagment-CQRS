using ProductManagment_CQRS.Model.Command;

namespace ProductManagment_CQRS.Interface
{
    public interface ICommandService
    {
        public int AddProduct(InsertUpdateModel newProduct);
        public bool UpdateProduct(InsertUpdateModel newProduct, int id);
    }
}
