using Hocomm.Database;
using Hocomm.WebApi.Bootstrap;
using Hocomm.WebApi.Filters;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("No DB connection string config.");
var authServiceUrl = builder.Configuration.GetSection("AuthServiceUrl").Get<string>() ?? throw new InvalidOperationException("No AuthServiceUrl config.");

// Add services to the container.

builder.Services.AddControllers(q =>
{
    q.Filters.Add<HttpResponseHeadersFilter>();
    q.Filters.Add<HttpResponseExceptionFilter>();
});

builder.Services.AddSwagger(authServiceUrl);
builder.Services.AddHttpContextAccessor();

builder.Services.AddHocomAuth(authServiceUrl);
builder.Services.AddHocommStuff(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseHocomm();

app.Run();
