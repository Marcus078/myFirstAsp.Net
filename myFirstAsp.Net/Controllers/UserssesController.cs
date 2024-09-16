using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myFirstAsp.Net.Data;
using myFirstAsp.Net.Models;

namespace myFirstAsp.Net.Controllers
{
    public class UserssesController : Controller
    {
        private readonly UsersContext _context;

        public UserssesController(UsersContext context)
        {
            _context = context;
        }

        // GET: Usersses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Userss.ToListAsync());
        }

        // GET: Usersses/Details/5
        public async Task<IActionResult> Details(int? userid)
        {
            if (userid == null)
            {
                return NotFound();
            }

            var userss = await _context.Userss
                .FirstOrDefaultAsync(m => m.UserId == userid);
            if (userss == null)
            {
                return NotFound();
            }

            return View(userss);
        }

        // GET: Usersses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usersses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name")] Userss userss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userss);
        }

        // GET: Usersses/Edit/5
        public async Task<IActionResult> Edit(int? userid)
        {
            if (userid == null)
            {
                return NotFound();
            }

            var userss = await _context.Userss.FindAsync(userid);
            if (userss == null)
            {
                return NotFound();
            }
            return View(userss);
        }

        // POST: Usersses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Name")] Userss userss)
        {
            if (id != userss.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserssExists(userss.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userss);
        }

        // GET: Usersses/Delete/5
        public async Task<IActionResult> Delete(int? userid)
        {
            if (userid == null)
            {
                return NotFound();
            }

            var userss = await _context.Userss
                .FirstOrDefaultAsync(m => m.UserId == userid);
            if (userss == null)
            {
                return NotFound();
            }

            return View(userss);
        }

        // POST: Usersses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int userid)
        {
            var userss = await _context.Userss.FindAsync(userid);
            if (userss != null)
            {
                _context.Userss.Remove(userss);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserssExists(int userid)
        {
            return _context.Userss.Any(e => e.UserId == userid);
        }
    }
}
