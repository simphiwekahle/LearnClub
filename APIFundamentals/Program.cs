using APIFundamentals.Data;
using APIFundamentals.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails(); // Only Unsuccessful repsponses return problem details

builder.Services.AddSingleton<ApplicationContext>();
builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();

	app.Map("/", httpContext => Task.Run(() => httpContext.Response.Redirect("/swagger")));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
