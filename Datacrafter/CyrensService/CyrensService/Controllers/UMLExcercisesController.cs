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
    public class UMLExcercisesController : Controller
    {

        public IActionResult Index()
        {
            //return View(await _context.UMLExcercises.ToListAsync());
            return View();
        }
    }
}
