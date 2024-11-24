using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Models
{
    public class Quizzes
    {
        [Key]
        public int quiz_id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        public bool isActive { get; set; }

        [Required]
        public int maxMarks { get; set; }

        [Required]
        public int num_of_questions { get; set; }

        [ForeignKey("Categories")]
        public int cat_id { get; set; }


    }
}
