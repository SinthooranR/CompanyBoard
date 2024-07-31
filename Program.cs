using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Models.Entity;
using YTCG_Deck_Builder_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});


builder.Services.AddScoped<TokenGenerator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication();

builder.Services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<DataContext>().AddApiEndpoints().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<AppUser>();

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
