using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthorizationApp.Data;
using AuthorizationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminsController( UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
       
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // GET: Admins
        public async Task<IActionResult> Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }

        // GET: Admins/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var admin = await _context.Etudiants
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (admin == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(admin);
        //}

        //// GET: Admins/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admins/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,nom,prenome,CIN,Adress")] Admin admin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(admin);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(admin);
        //}

        //// GET: Admins/Edit/5
        public async Task<IActionResult> Edit()
        {
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();

            ViewBag.Users = new SelectList(users, "Id", "UserName");
            ViewBag.Roles = new SelectList(roles, "Name", "Name");
            return View();
        }

        //// POST: Admins/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AspNetUserRoles userRole)
        {
            var user = await userManager.FindByIdAsync(userRole.UserId);

            await userManager.AddToRoleAsync(user, userRole.RoleId);

            return RedirectToAction(nameof(Index));
        }

        //// GET: Admins/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var admin = await _context.Etudiants
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (admin == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(admin);
        //}

        //// POST: Admins/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var admin = await _context.Etudiants.FindAsync(id);
        //    _context.Etudiants.Remove(admin);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AdminExists(int id)
        //{
        //    return _context.Etudiants.Any(e => e.id == id);
        //}
    }
}
