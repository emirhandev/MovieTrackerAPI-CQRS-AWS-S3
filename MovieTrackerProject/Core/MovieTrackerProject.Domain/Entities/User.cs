

namespace MovieTrackerProject.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? ProfilePhotoUrl { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();

        
        public List<Rate> Rates { get; set; } = new List<Rate>();

    }
}
