using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SocialHub.Core.Entities;
using SocialHub.Infrastructure.Data;
using SocialHub.Infrastructure.IdentityData;
using SocialHub.Models;
using System;
using System.Collections.Generic;
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
        private readonly IMemoryCache _memoryCache;

        public GigsController(AppDbContext appDbContext, UserManager<ApplicationUser> userManager,
            IdentityAppDbContext identityAppDbContext, IMemoryCache memoryCache)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _identityAppDbContext = identityAppDbContext;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var gigsViewModel = new GigViewModel()
            {
                Genres = GetGenres().GetAwaiter().GetResult()
            };
            
            return View(gigsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GigViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = await GetGenres();
                return View("Create", model);
            }

            var userId = _userManager.GetUserId(User);            
            Genre genre = _appDbContext.Genres.Single(a => a.Id == model.GenreId);            

            Gig newGig = new Gig(userId, genre, model.GetDateTime(), model.Venue);

            _appDbContext.Gigs.Add(newGig);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        private async Task<IEnumerable<GenreViewModel>> GetGenres()
        {            
            return await _memoryCache.GetOrCreateAsync("GenreList", (entry) =>
            {
                var cachedList =
                    _appDbContext.Genres.Select(a => new GenreViewModel()
                    {
                        Id = a.Id,
                        Name = a.Name
                    }).ToList();

                entry.SetSlidingExpiration(TimeSpan.FromMinutes(3));

                return Task.FromResult(cachedList);
            });
        }
    }
}