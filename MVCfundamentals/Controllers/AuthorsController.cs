using Microsoft.AspNetCore.Mvc;

namespace MVCfundamentals.Controllers;

public class AuthorsController : Controller
{
	public async Task<IActionResult> Index()
	{
		return View();
	}

	[HttpGet("~/[controller]/[authorId:int]")]
	public async Task<IActionResult> Details(int authorId)
	{
		return View();
	}
}
