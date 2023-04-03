using ClimbingPlaylistApi.Database;
using ClimbingPlaylistApi.Domain;
using ClimbingPlaylistApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapGet("/pizzas/{id}", (int id) => PizzaDB.GetPizza(id));
//app.MapGet("/pizzas", () => PizzaDB.GetPizzas());
//app.MapPost("/pizzas", (Pizza pizza) => PizzaDB.CreatePizza(pizza));
//app.MapPut("/pizzas", (Pizza pizza) => PizzaDB.UpdatePizza(pizza));
//app.MapDelete("/pizzas/{id}", (int id) => PizzaDB.RemovePizza(id));

app.Run();
