using Balogh_Szilard___tema_1_dawm.Data;
using Balogh_Szilard___tema_1_dawm.Models;
using Balogh_Szilard___tema_1_dawm.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MoviesService>();
builder.Services.AddDbContext<MoviesDbContext>(options => options.UseInMemoryDatabase("MoviesDb"));

var app = builder.Build();


var movies = new List<Movie>
{
    new Movie {Title = "The Shawshank Redemption", Director = "Frank Darabont", PublicationDate = new DateTime(1994, 1, 1)},
    new Movie {Title = "The Godfather", Director = "Francis Ford Coppola", PublicationDate = new DateTime(1972, 1, 1)},
    new Movie {Title = "The Dark Knight", Director = "Christopher Nolan", PublicationDate = new DateTime(2008, 1, 1)},
};

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MoviesDbContext>();
    dbContext.Movies.AddRange(movies);
    dbContext.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();