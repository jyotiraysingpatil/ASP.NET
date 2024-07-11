namespace Movie_Man.Entities
{
    public class Movie
    {
        public int id {  get; set; }
        public string title {  get; set; }
        public DateTime releaseDate {  get; set; }
        public string description { get; set; } 
        public string actorName {  get; set; }

        public string ToString()
        {
            return "id" + this.id + "title" + this.title + "releasedate" + this.releaseDate + "description" + this.description +
                "actorname" + this.actorName;

        }
    }
}
