using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace categoryProduct.Entities
{
    public class Products
    {
        [Key]
        public int pro_id { get; set; }
        [Required]
        [StringLength(255)]
        public string prodName { get; set; }=string.Empty;

        [ForeignKey("cat_id")]
        public int cat_id { get; set; }

       
        
        
    }
}
