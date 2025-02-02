

namespace MovieTrackerProject.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; } 
        public int ReleaseYear { get; set; } 

       
        public int? UserId { get; set; }
        public User User { get; set; }

       
        public List<Rate> Rates { get; set; } = new List<Rate>();
    }
}
