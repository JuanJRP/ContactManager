using MongoDB.Driver;
using static ContactManager.DB.MongoService;
using static ContactManager.Interfaces.ContactInterface;
using static ContactManager.Repositories.ContactRepositories;
using static ContactManager.Services.ContactServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<MongoDbService>(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDB");
    return new MongoClient(settings["ConnectionString"]);
});

builder.Services.AddScoped(sp =>
{
    var settings = builder.Configuration.GetSection("MongoDB");
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings["DatabaseName"]);
});

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ContactService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
