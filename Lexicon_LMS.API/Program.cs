using Microsoft.EntityFrameworkCore;
using Lexicon_LMS.API.Endpoints;
using Lexicon_LMS.Server.Data;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

var specOrigin = "MySpecOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: specOrigin, policy =>
    {
        policy.WithOrigins("https://localhost:5130")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});   

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.RegisterUserEndpoint();

app.UseCors(specOrigin);
app.Run();

