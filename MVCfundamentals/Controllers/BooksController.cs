using Microsoft.AspNetCore.Mvc;

namespace MVCfundamentals.Controllers;

public class BooksController : Controller
{
	public async Task<IActionResult> Index()
	{
		return View();
	}

	[HttpGet("~/authors/[authorId:int]/[controller]/[bookId:int]")]
	public async Task<IActionResult> Details(int authorId, int bookId)
	{
		return View();
	}
}
