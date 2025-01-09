using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MurderAPI.Models;
using MurderAPI.Services;
using System.Text;

var key = Encoding.UTF8.GetBytes("EGYPTIANMYTHOLOGYISTHEKEYTOEVERYTHING");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<ISuspectsModel, SuspectsModel>();
builder.Services.AddScoped<ISuspectsService, SuspectsService>();
builder.Services.AddScoped<IRoomsModel, RoomsModel>();
builder.Services.AddScoped<IRoomsService, RoomsService>();
builder.Services.AddScoped<IPlacesToSearchModel, PlacesToSearchModel>();
builder.Services.AddScoped<IPlacesToSearchService, PlacesToSearchService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "set",
        ValidateAudience = true,
        ValidAudience = "murderAPI",
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
