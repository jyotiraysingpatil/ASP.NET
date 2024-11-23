using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Models
{
    public class Categories
    {
        public int cat_id {  get; set; }    
        public string description { get; set; } 
        public string title { get; set; }
        
        [ForeignKey("admin_id")]
        public int admin_id { get; set; }
       

    }
}
