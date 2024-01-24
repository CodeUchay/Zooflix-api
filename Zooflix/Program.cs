using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Zooflix.Data;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ZooflixContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZooflixContext") ?? throw new InvalidOperationException("Connection string 'ZooflixContext' not found.")));
// uche cors
builder.Services.AddCors(options =>
{

    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://zooflix.vercel.app")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
//builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cors shit
// Enable CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// ajout pour création bdd
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ZooflixContext>();
    //context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

app.Run();
