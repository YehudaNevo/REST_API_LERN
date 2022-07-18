using Catalog.Repo;
using Catalog.Settings;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IItemRepo,MongoDbItemsRepo>();

builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    // var settings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

    return new MongoClient("mongodb://localhost:27017");
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

app.Run();
