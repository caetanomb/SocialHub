using Microsoft.AspNetCore.Mvc;
using SocialHub.Infrastructure.Data;
using SocialHub.Models;
using System.Linq;

namespace SocialHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public GigsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Create()
        {
            var gigsViewModel = new GigViewModel()
            {
                Genres = _appDbContext.Genres.Select(a => new GenreViewModel() {
                    Id = a.Id,
                    Name = a.Name
                }).ToList()
            };
            
            return View(gigsViewModel);
        }
    }
}