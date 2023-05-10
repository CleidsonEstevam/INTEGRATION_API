using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Configure the HTTP request pipeline.
#region "Swagger"
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "INTEGRATION_API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token!",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
});
var app = builder.Build();

//var connection = builder.Configuration["MySQlConnection:MySQlConnectionString"];

//builder.Services.AddDbContext<MySQLContext>(options => options.
//    UseMySql(connection,
//            new MySqlServerVersion(
//                new Version(8, 0, 5))));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntegrationRev  API v1"));
}
#endregion




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
