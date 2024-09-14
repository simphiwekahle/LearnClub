using APIFundamentals.Repository;
using Fundamentals.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace APIFundamentals.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(Application.Json)]
public class AuthorsController(
	IAuthorsRepository authorsRepository) : ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<List<AuthorModel>>> RetrieveAllAsync()
	{
		var authors = await authorsRepository.GetAllAsync();
		return Ok(authors);
	}

	[HttpGet("{authorId:int}")]
	public async Task<ActionResult<AuthorModel>> RetrieveSingleAsync(int authorId)
	{
		var author = await authorsRepository.GetSingleAsync(authorId);

		if (author is null)
		{
			return NotFound();
		}

		return Ok(author);
	}
}
