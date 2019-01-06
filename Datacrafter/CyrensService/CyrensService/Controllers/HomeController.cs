using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CyrensService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CyrensService.Controllers
{
    public class HomeController : Controller
    {
        private readonly CyrensDbContext _context;

        public HomeController(CyrensDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                id = 1;
            }

            var stories = await _context.Stories
                .SingleOrDefaultAsync(m => m.Id == id);
            if (stories == null)
            {
                return NotFound();
            }

            return View(stories);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
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
