using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RecipeManagement.Automapper;
using RecipeManagement.Data;
using RecipeManagement.Interfaces;
using RecipeManagement.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperConnection>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddCors();
builder.Services.AddScoped<IUserService, UserRepository>();
builder.Services.AddScoped<ICategoryService, CategoryRepository>();
builder.Services.AddScoped<IRecipeService, RecipeRepository>();
builder.Services.AddScoped<IRatingService, RatingRepository>();
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

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication(); // Add this line for JWT authentication
app.UseRouting(); // Add this line for routing
app.UseAuthorization();

app.MapControllers();

app.Run();
