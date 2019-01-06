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
    public class ExamplesController : Controller
    {
        //private readonly CyrensDbContext _context;

        //public PersonsController(CyrensDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Persons
        public IActionResult Index()
        {
            // return View(await _context.Persons.ToListAsync());
            return View();
        }

        //    // GET: Persons/Details/5
        //    public async Task<IActionResult> Details(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var persons = await _context.Persons
        //            .SingleOrDefaultAsync(m => m.Id == id);
        //        if (persons == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(persons);
        //    }

        //    // GET: Persons/Create
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Persons/Create
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,Age")] Persons persons)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(persons);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction("Index");
        //        }
        //        return View(persons);
        //    }

        //    // GET: Persons/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var persons = await _context.Persons.SingleOrDefaultAsync(m => m.Id == id);
        //        if (persons == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(persons);
        //    }

        //    // POST: Persons/Edit/5
        //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,Age")] Persons persons)
        //    {
        //        if (id != persons.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(persons);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!PersonsExists(persons.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction("Index");
        //        }
        //        return View(persons);
        //    }

        //    // GET: Persons/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var persons = await _context.Persons
        //            .SingleOrDefaultAsync(m => m.Id == id);
        //        if (persons == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(persons);
        //    }

        //    // POST: Persons/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var persons = await _context.Persons.SingleOrDefaultAsync(m => m.Id == id);
        //        _context.Persons.Remove(persons);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    private bool PersonsExists(int id)
        //    {
        //        return _context.Persons.Any(e => e.Id == id);
        //    }
    }
}
