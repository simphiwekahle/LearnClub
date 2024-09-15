using Fundamentals.Models;

namespace MVCfundamentals.HttpClient;

public interface IAuthorsClient
{
	Task<List<AuthorModel>> RetrieveAllAsync();
	Task<AuthorModel> RetieveSingleAsync(int authorId);
}
