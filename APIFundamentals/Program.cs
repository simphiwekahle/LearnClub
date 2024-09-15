using APIFundamentals.Abstractions;
using APIFundamentals.Data;
using APIFundamentals.Repository;
using Fundamentals.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
	setup.SwaggerDoc("OpenAPISpecificationForAuthors", new()
	{
		Title = "API Fundamentals [Authors]",
		Description = "Learning API basics",
		Version = "v1"
	});
	
	setup.SwaggerDoc("OpenAPISpecificationForBooks", new()
	{
		Title = "API Fundamentals [Books]",
		Description = "Learning API basics",
		Version = "v1"
	});

	setup.IncludeXmlCommentsFromAssembly<Program>();
	setup.IncludeXmlCommentsFromAssembly<AuthorModel>();
});

builder.Services.AddProblemDetails(); // Only Unsuccessful repsponses return problem details

builder.Services.AddSingleton<ApplicationContext>();
builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(setup =>
	{
		setup.SwaggerEndpoint(
			"/swagger/OpenAPISpecificationForAuthors/swagger.json",
			"API Fundamentals [Authors]");
		
		setup.SwaggerEndpoint(
			"/swagger/OpenAPISpecificationForBooks/swagger.json",
			"API Fundamentals [Books]");
	});

	app.Map("/", httpContext => Task.Run(() => httpContext.Response.Redirect("/swagger")));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
