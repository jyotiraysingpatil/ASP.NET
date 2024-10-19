namespace ExamManagement.Entities
{
    public class Movie
    {
    public  int Id { get; set; }
        public string title {  get; set; }
        public DateTime releaseDate {  get; set; }
        public string description { get; set; }
        public string actorName {  get; set; }

        public override string ToString()
        {
            return "title" + this.title + "releaseDate" + this.releaseDate + "description" + this.description + "actorName " + this.actorName;
           
        }

    }
}
