using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialHub.Core.Entities;
using SocialHub.Infrastructure.Data;
using SocialHub.Infrastructure.IdentityData;
using SocialHub.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialHub.Controllers
{
    [Authorize]
    public class GigsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IdentityAppDbContext _identityAppDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public GigsController(AppDbContext appDbContext, UserManager<ApplicationUser> userManager,
            IdentityAppDbContext identityAppDbContext)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _identityAppDbContext = identityAppDbContext;
        }

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Create(GigViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            DateTime parsedDateTime;
            Genre genre = _appDbContext.Genres.Single(a => a.Id == model.GenreId);

            parsedDateTime = DateTime.Parse($"{model.Date} {model.Time}");

            Gig newGig = new Gig(userId, genre, parsedDateTime, model.Venue);

            _appDbContext.Gigs.Add(newGig);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}