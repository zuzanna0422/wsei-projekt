using Infrastructure.EF;
using KickstarterAPI.Configuration;
using KickstarterAPI.Dto;
using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddIdentity<UserEntity, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<JwtSettings>();
/*builder.Services.ConfigureIdentity();*/
builder.Services.ConfigureJWT(new JwtSettings(builder.Configuration));
builder.Services.ConfigureCors();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();