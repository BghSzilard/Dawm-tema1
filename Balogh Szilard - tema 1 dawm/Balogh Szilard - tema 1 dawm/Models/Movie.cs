﻿namespace Balogh_Szilard___tema_1_dawm.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Likes { get; set; }
        public String Director { get; set; }
        
    }
}
