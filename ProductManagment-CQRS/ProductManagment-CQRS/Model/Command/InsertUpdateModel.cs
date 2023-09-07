using System.ComponentModel.DataAnnotations;

namespace ProductManagment_CQRS.Model.Command
{
    public class InsertUpdateModel
    {
        [Required]
        public string ProductId { get; set; }


        [RegularExpression(@"^[a-zA-Z0-9\s]+$",ErrorMessage ="Product name must contain only letter, digit and spaces")]
        public string ProductName { get; set; }



        [Range(0,int.MaxValue,ErrorMessage ="Quality always a positive value")]
        public int Qty { get; set; }



        [Range(0.0,float.MaxValue,ErrorMessage ="Price always a positive value")]
        public float Price { get; set; }



        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Added By must contain only letter and spaces")]
        public string AddedBy { get; set; }


        //public DateTime AddedOn { get; set; }
    }
}
