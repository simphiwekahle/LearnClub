using APIFundamentals.Repository;
using Fundamentals.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace APIFundamentals.Controllers;

[Route("api/authors/{authorId:int}/[controller]")]
[ApiController]
[Produces(Application.Json)]
[ApiExplorerSettings(GroupName = "OpenAPISpecificationForBooks")]
public class BooksController(
	IAuthorsRepository authorsRepository) : ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<List<BookModel>>> RetrieveAllAsync(int authorId)
	{
		var author = await authorsRepository.GetSingleAsync(authorId);

		if (author is null)
		{
			return NotFound();
		}

		return Ok(author.Books);
	}

	[HttpGet("{bookId:int}")]
	public async Task<ActionResult<BookModel>> RetrieveSingleAsync(int authorId, int bookId)
	{
		var author = await authorsRepository.GetSingleAsync(authorId);

		if (author is null)
		{
			return NotFound();
		}

		var book = author.Books.SingleOrDefault(book => book.Id == bookId);
		if (book is null)
		{
			return NotFound();
		}

		return Ok(book);
	}
}
