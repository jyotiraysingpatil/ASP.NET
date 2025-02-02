using System.ComponentModel.DataAnnotations;

namespace categoryProduct.Entities
{
    public class Categories
    {
        [Key]
        public int cat_id { get; set; }

        [Required]
        [StringLength(255)]
        public string catName { get; set; } 
        
       
    }
}
