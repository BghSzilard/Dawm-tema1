namespace Balogh_Szilard___tema_1_dawm.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Likes { get; set; }
        public string? Director { get; set; }
        
        public Movie()
        {

        }
        public Movie(string title, DateTime publicationDate, int likes, string director)
        {
            Id = Guid.NewGuid();
            Title = title;
            PublicationDate = publicationDate;
            Likes = likes;
            Director = director;
        }
    }
}
