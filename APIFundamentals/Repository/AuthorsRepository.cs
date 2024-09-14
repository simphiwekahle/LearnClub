using APIFundamentals.Data;
using Fundamentals.Models;

namespace APIFundamentals.Repository;

public class AuthorsRepository(
	ApplicationContext authorsContext) : IAuthorsRepository
{
	public Task<List<AuthorModel>> GetAllAsync()
	{
		var authors = authorsContext.Authors;

		return Task.FromResult(authors);
	}

	public Task<AuthorModel> GetSingleAsync(int authorId)
	{
		var author = authorsContext.Authors
						.SingleOrDefault(author => author.Id == authorId);

		return Task.FromResult(author);
	}
}
