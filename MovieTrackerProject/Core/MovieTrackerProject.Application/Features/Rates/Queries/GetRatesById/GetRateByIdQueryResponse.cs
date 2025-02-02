namespace MovieTrackerProject.Application.Features.Rates.Queries.GetRatesById
{
    public class GetRateByIdQueryResponse
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string Comment { get; set; }
        public int Rank { get; set; }
        public string Username { get; set; }
    
    }
}
