using DadJokes.Api;
using DadJokes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DadJokes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly ApiCaller _apiCaller;

        public HomeController(IMemoryCache cache)
        {
            _cache = cache;
            _apiCaller = new ApiCaller();
        }

        public async Task<IActionResult> Index()
        {
            RootModel? data = await _apiCaller.GetJoke();
            if (data != null)
            {
                var jokes = _cache.GetOrCreate("JokesList", entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1);
                    return new List<RootModel>();
                });

                jokes?.Add(data);
                _cache.Set("JokesList", jokes);
            }
            return View(data);
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult History()
        {
            var jokes = _cache.Get<List<RootModel>>("JokesList") ?? new List<RootModel>();
            return View(jokes);
        }
    }
}