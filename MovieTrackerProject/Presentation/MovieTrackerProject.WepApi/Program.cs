using System.Text.Json.Serialization;
using System.Text.Json;
using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using MovieTrackerProject.Application.Features.Users.Commands.AddMovie;
using MovieTrackerProject.Application.Interfaces;
using MovieTrackerProject.Application.Services;
using MovieTrackerProject.Domain.Entities;
using MovieTrackerProject.Persistence.Context;
using MovieTrackerProject.Persistence.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUserRepository<User>, UserRepository>();
builder.Services.AddScoped<IRateRepository<Rate>, RateRepository>();
builder.Services.AddScoped<IMovieRepository<Movie>, MovieRepository>();


// Add services to the container.

builder.Services.AddHttpClient<TMDBService>();
builder.Services.AddSingleton(new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    Converters = { new JsonStringEnumConverter() }
});


// AWS Part
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();

// TmDb Handlers
builder.Services.AddScoped<AddMovieToWatchListByIdWithTMDBCommandHandler>();

//Mediatr
builder.Services.AddMediatR(cfg =>


{

//User Queries
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.TMDB.Queries.GetMovieByTMDBAPI.GetMovieByTMDBAPIQuery).Assembly);
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Users.Queries.GetUser.GetUserQuery).Assembly);
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Users.Queries.GetUserById.GetUserByIdQuery).Assembly);
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Users.Queries.GetUserWithMovies.GetUserWithMoviesQuery).Assembly);


// Rate Queries
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Rates.Queries.GetRates.GetRatesQuery).Assembly);
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Rates.Queries.GetRatesById.GetRateByIdQuery).Assembly);
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Rates.Queries.GetRatesByIdWithRate.GetRatesByIdWithRateQuery).Assembly);

// Movie Queries
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Movies.Queries.GetMovie.GetMovieQuery).Assembly);
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Movies.Queries.GetMovieById.GetMovieByIdQuery).Assembly);
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByTitle.GetMovieByTitleQuery).Assembly);
cfg.RegisterServicesFromAssembly(typeof(MovieTrackerProject.Application.Features.Movies.Queries.GetMovieByTitleWithRates.GetMovieByTitleWithRatesQuery).Assembly);

});


builder.Services.AddControllers();

// Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext and configure connection string
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Run the application
app.Run();
