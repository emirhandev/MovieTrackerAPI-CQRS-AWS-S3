namespace MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByTitle
{
    public class GetMovieByTitleQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
    }
}
