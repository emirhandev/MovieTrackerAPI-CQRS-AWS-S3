namespace MovieTrackerProject.Application.Features.TMDB.Queries.GetMovieByTMDBAPI
{
    public class GetMovieByTMDBAPIQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public double VoteAverage { get; set; }
        public string release_date { get; set; }

    }
}