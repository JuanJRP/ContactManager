using MongoDB.Driver;
using static ContactManager.DB.MongoService;
using static ContactManager.Interfaces.ContactInterface;
using static ContactManager.Repositories.ContactRepositories;
using static ContactManager.Services.ContactServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
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

app.UseHttpsRedirection();

app.UseRouting();

// Redirigir siempre a /Contacts/Index en la raíz "/"
app.MapGet("/", async context =>
{
    context.Response.Redirect("/Contacts/Index");
    await Task.CompletedTask;
});

// Configurar endpoints
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

// Habilitar Swagger en /swagger (no en la raíz)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Manager API v1");
    c.RoutePrefix = "swagger";  // Mover Swagger a /swagger
});

app.Run();
