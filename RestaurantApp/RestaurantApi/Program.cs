using Entities;
using Repositories;
using RestaurantApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddScoped<UserRepository>();//we must add the scope to dedect the sepcific repository cuz we add the general reposotiry with the dobcontext!!
//and we have to chech the data after createing the migrations and remove any unwanted data!!! and after removing them we must drop the migraion again and remove it and recreate it again!!!
/* builder.Services.AddSingleton<UserRepository>();//we have to uncomment them if we want to not to use the database
builder.Services.AddSingleton<List<User>>(); */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandler();//To handel the errors in the first middleware to save the app from the hackers
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
