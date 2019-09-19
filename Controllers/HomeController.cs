using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chat.Models;
using Microsoft.AspNetCore.Identity;
using Chat.Data;
using Microsoft.EntityFrameworkCore;

namespace Chat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<AppUser> _UserManager;

        public HomeController(ApplicationDbContext dbContext,UserManager<AppUser> _userManager)
        {
            this.dbContext = dbContext;
            _UserManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _UserManager.GetUserAsync(User);
            var messages = await dbContext.Messages.ToListAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
