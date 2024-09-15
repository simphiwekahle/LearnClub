using APIFundamentals.Repository;
using Fundamentals.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace APIFundamentals.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces(Application.Json)]
[ApiExplorerSettings(GroupName = "OpenAPISpecificationForAuthors")]
public class AuthorsController(
	IAuthorsRepository authorsRepository) : ControllerBase
{
	/// <summary>
	/// Retrieves a list of authors
	/// </summary>
	/// <response code="200">
	/// A list of authors
	/// </response>
	/// <returns>
	/// A task of type ActionResult of list of type of AuthorModel
	/// </returns>
	[HttpGet]
	[ProducesResponseType<List<AuthorModel>>(StatusCodes.Status200OK)]
	public async Task<ActionResult<List<AuthorModel>>> RetrieveAllAsync()
	{
		var authors = await authorsRepository.GetAllAsync();
		return Ok(authors);
	}

	/// <summary>
	/// Retrieves an author by their id
	/// </summary>
	/// <param name="authorId">
	/// The id is used to filter through the list of authors
	/// </param>
	/// <response code="200">
	/// The requested author
	/// </response>
	/// /// <response code="404">
	/// The requested author was not found
	/// </response>
	/// <returns></returns>
	[HttpGet("{authorId:int}")]
	[ProducesResponseType<AuthorModel>(StatusCodes.Status200OK)]
	[ProducesResponseType<ProblemDetails>(StatusCodes.Status404NotFound)]
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
