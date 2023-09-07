namespace ProductManagment_CQRS.Model.Query
{
    public class GetProductModel
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public float Price { get; set; }
    }
}
