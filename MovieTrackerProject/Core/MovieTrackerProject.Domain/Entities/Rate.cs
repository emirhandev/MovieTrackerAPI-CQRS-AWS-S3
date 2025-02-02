

namespace MovieTrackerProject.Domain.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public int Rank { get; set; } 
        public string Comment { get; set; } 

     
        public int? UserId { get; set; }
        public User User { get; set; }

    
        public int? MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}
