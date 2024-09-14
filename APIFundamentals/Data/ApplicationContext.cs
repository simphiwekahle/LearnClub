using Fundamentals.Models;

namespace APIFundamentals.Data;

public class ApplicationContext
{
	public List<AuthorModel> Authors =>
	[
		new()
		{
			Id = 1,
			FirstName = "Gege",
			LastName = "Akutami",
			Books =
			[
				new()
				{
					Id = 1,
					Title = "Jujutsu Kaisen",
					Description = "Shibuya Incident",
					ISBN = "4321"
				}
			]
		},
		new()
		{
			Id = 2,
			FirstName = "Masashi",
			LastName = "Kishimoto",
			Books =
			[
				new()
				{
					Id = 2,
					Title = "Naruto",
					Description = "Chunin Exam",
					ISBN = "3214"
				},
				new()
				{
					Id = 3,
					Title = "Naruto Shipuden",
					Description = "The 4th Great Ninja War",
					ISBN = "2143"
				},
				new()
				{
					Id = 4,
					Title = "Boruto",
					Description = "Naruto - Next Generation",
					ISBN = "1234"
				}
			]
		},
	];
}
