using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sample.Models
{
    public class Questions
    {
        [Key]
        public int ques_id { get; set; }

        [Required]
        public string question { get; set; }

        [Required]
        public string option1 { get; set; }

        [Required]
        public string option2 { get; set; }

        [Required]
        public string option3 { get; set; }

        [Required]
        public string option4 { get; set; }

        [Required]
        public string answer { get; set; }

        [ForeignKey("Quiz")]
        public int quiz_id { get; set; }

       
        [NotMapped]
        public string SelectedAnswer { get; set; }
    }
}
