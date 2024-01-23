using Business;
using Business.Services;
using Business.Services.Interfeces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
	options.JsonSerializerOptions.WriteIndented = true; // Opcional: para una salida más legible
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceJugadores, ServiceJugadores>();
builder.Services.AddScoped<IServiceTorneos, ServiceTorneos>();
builder.Services.AddScoped<IServicePartidos, ServicePartidos>();
DependencyInjection.AddRepositories(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
	build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();
app.UseCors("PolicyCors");

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
