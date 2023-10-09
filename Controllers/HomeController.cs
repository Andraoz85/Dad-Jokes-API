using DadJokes.Api;
using DadJokes.Models;
using Microsoft.AspNetCore.Mvc;

namespace DadJokes.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            RootModel? data = await new ApiCaller().GetJoke();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}