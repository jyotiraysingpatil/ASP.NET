
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace sample.Models
{
    public class QuizResults
    {
        [Key]
        public int quiz_res_id { get; set; }    
        public DateTime attemptDateTime { get; set; }   
        public int totalObtainedMarks { get; set; }
        [ForeignKey("quiz_id")]
        public int quiz_id;

        [ForeignKey("user_id")]
       public int user_id { get; set; } 
        
    }
}
