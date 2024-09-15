using Swashbuckle.AspNetCore.SwaggerGen;

namespace APIFundamentals.Abstractions;

public static class SwaggerAbstractions
{
	public static SwaggerGenOptions IncludeXmlCommentsFromAssembly<T>(this SwaggerGenOptions options) where T : class
	{
		var xmlFile = $"{typeof(T).Assembly.GetName().Name}.xml";
		var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFile);

		options.IncludeXmlComments(xmlFilePath);

		return options;
	}
}
