using ClimbingPlaylistApi.Database;
using ClimbingPlaylistApi.Domain;
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
builder.Services.AddScoped<IMpScraperAdapter,MpScraperAdapter>();
builder.Services.AddScoped<IRouteModelHandler,RouteModelHandler>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

//app.UseAuthorization();

app.Run();
