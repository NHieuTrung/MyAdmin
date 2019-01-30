using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Type = Model.Models.Type;

namespace MyCoreAdmin.Controllers
{
    public class TypesController : Controller
    {
        private readonly MyCoreAdminDBContext _context;

        public TypesController(MyCoreAdminDBContext context)
        {
            _context = context;
        }

        // GET: Types
        public async Task<IActionResult> Index()
        {
            var myCoreAdminDBContext = _context.Type.Include(m => m.Branch);
            return View(await myCoreAdminDBContext.ToListAsync());
        }

        // GET: Types/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mtype = await _context.Type
                .Include(m => m.Branch)
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (mtype == null)
            {
                return NotFound();
            }

            return View(mtype);
        }

        // GET: Types/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branch, "BranchId", "BranchName");
            return View();
        }

        // POST: Types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,BranchId,TypeName")] Type mtype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mtype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branch, "BranchId", "BranchName", mtype.BranchId);
            return View(mtype);
        }

        // GET: Types/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mtype = await _context.Type.FindAsync(id);
            if (mtype == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branch, "BranchId", "BranchName", mtype.BranchId);
            return View(mtype);
        }

        // POST: Types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeId,BranchId,TypeName")] Type mtype)
        {
            if (id != mtype.TypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mtype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeExists(mtype.TypeId))
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
            ViewData["BranchId"] = new SelectList(_context.Branch, "BranchId", "BranchName", mtype.BranchId);
            return View(mtype);
        }

        // GET: Types/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mtype = await _context.Type
                .Include(m => m.Branch)
                .FirstOrDefaultAsync(m => m.TypeId == id);
            if (mtype == null)
            {
                return NotFound();
            }

            return View(mtype);
        }

        // POST: Types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mtype = await _context.Type.FindAsync(id);
            _context.Type.Remove(mtype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeExists(int id)
        {
            return _context.Type.Any(e => e.TypeId == id);
        }
    }
}
