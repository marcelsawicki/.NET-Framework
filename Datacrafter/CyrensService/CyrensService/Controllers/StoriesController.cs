using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CyrensService.Models;

namespace CyrensService.Controllers
{
    public class StoriesController : Controller
    {
        private readonly CyrensDbContext _context;

        public StoriesController(CyrensDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Stories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stories = await _context.Stories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (stories == null)
            {
                return NotFound();
            }

            return View(stories);
        }

        // GET: Stories/Details/5
        public async Task<IActionResult> Like(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stories = await _context.Stories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (stories == null)
            {
                return NotFound();
            }
            else
            {
                stories.Likes += 1;
            }
            _context.SaveChanges();

            return View(stories);
        }

        public async Task<IActionResult> Unlike(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stories = await _context.Stories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (stories == null)
            {
                return NotFound();
            }
            else
            {
                stories.Unlikes += 1;
            }
            _context.SaveChanges();

            return View(stories);
        }
    }
}
