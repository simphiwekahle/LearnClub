using Fundamentals.Models;

namespace APIFundamentals.Repository;

public interface IAuthorsRepository
{
	Task<List<AuthorModel>> GetAllAsync();
	Task<AuthorModel> GetSingleAsync(int authorId);
}
