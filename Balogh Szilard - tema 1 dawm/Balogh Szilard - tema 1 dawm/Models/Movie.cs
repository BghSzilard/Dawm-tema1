namespace Balogh_Szilard___tema_1_dawm.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Likes { get; set; }
        public Movie(Guid id, string title, DateTime publicationDate, int likes)
        {
            Id = id;
            Title = title;
            PublicationDate = publicationDate;
            Likes = likes;
        }
    }
}
