namespace Balogh_Szilard___tema_1_dawm.Models
{
    public class AddMovieRequest
    {
        public string? Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Likes { get; set; }
        public string? Director { get; set; }
    }
}
