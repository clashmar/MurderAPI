using MurderAPI.Models;
using MurderAPI.Services;

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
