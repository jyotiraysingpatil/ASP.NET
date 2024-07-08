namespace ECommerce_Flipkart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string UnitPrice { get; set; }

        public string Imageurl { get; set; }
        public int quantity { get; set; }
    }
}
