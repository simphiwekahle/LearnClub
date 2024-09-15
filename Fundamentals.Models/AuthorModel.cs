namespace Fundamentals.Models;

public class AuthorModel
{
	/// <summary>
	/// Id of the author
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// The author's first name
	/// </summary>
	public string FirstName { get; set; } = string.Empty;

	/// <summary>
	/// The author's last name
	/// </summary>
	public string LastName { get; set; } = string.Empty;

	/// <summary>
	/// The author's book list
	/// </summary>
	public List<BookModel> Books { get; set; } = [];
}
