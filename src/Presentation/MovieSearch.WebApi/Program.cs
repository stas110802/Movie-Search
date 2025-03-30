using MovieSearch.Domain;
using MovieSearch.Infrastructure.Clients;
using MovieSearch.Infrastructure.Options;
using MovieSearch.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using MovieSearch.Application.Profiles;
using MovieSearch.Domain.Repositories;
using MovieSearch.Persistence.Repositories;
using MovieSearch.WebApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add All AutoMappers
builder.Services.AddAutoMapper(typeof(MovieProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ActorProfile).Assembly);

// Add MediatR
foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}

// Add SqLite db
var connectionString = $"Data Source={FolderPathList.TempFolder}mydatabase.db";
if (!File.Exists($"{FolderPathList.TempFolder}mydatabase.db"))
{
    using var file = File.CreateText($"{FolderPathList.TempFolder}mydatabase.db");
    file.Close();
}

builder.Services.AddDbContext<MovieSearchDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

// Add Api Options (base uri + fee public key)
builder.Services.Configure<MovieApiOptions>(x =>
{
    x.BaseUri = "http://www.omdbapi.com/";
    x.PublicKey = "5e29bf89";
});

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IRestMovieClient, OmDbClient>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// create local db + create table
using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetRequiredService<MovieSearchDbContext>();
context.Database.EnsureCreated();

app.MapControllers();
app.Run();
