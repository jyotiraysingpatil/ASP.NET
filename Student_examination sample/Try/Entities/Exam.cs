using System.ComponentModel.DataAnnotations.Schema;

namespace Try.Entities
{
    public class Exam
    {
        public int exam_id { get; set; }
        public string exam_name { get; set; }
        public string subject { get; set; }
        [ForeignKey("id")]
        public int sid { get; set; }
    }
}
