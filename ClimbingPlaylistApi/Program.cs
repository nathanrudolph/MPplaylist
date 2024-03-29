using ClimbingPlaylistApi.Database;
using ClimbingPlaylistApi.Domain;
using ClimbingPlaylistApi.Endpoints;
using ClimbingPlaylistApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ClimbingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IDbService,DbService>();
builder.Services.AddScoped<IPlaylistService,PlaylistService>();
builder.Services.AddTransient<IMpScraper,MpScraper>();
builder.Services.AddTransient<IRouteModelHandler,RouteModelHandler>();

//builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.ConnectPlaylistEndpoints();

//app.UseAuthorization();
//app.MapControllers();

app.Run();
