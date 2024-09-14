namespace Fundamentals.Models;

public class AuthorModel
{
	public int Id { get; set; }
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public List<BookModel> Books { get; set; } = [];
}
