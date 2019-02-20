using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using connect_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace connect_test.Controllers
{
    public class TestController : Controller
    {
        private readonly MyDbContext _context;

        public TestController(MyDbContext context)
        {
            _context = context;
        }

        //GET: Tests
        public async Task<IActionResult> Index()
        {
            return View(await _context.Test.ToListAsync());
        }

        //GET: Test/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type")] Test test)
        {
            if (ModelState.IsValid)
            {
                _context.Add(test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(test);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}