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
using Microsoft.AspNetCore.Authorization;

namespace Chat.Controllers
{
    [Authorize]
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

            if(User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }
            
            var messages = await dbContext.Messages.ToListAsync();
            return View();
        }

        public async Task<IActionResult> Create(Message message)
        {
            if (ModelState.IsValid)
            {
                message.UserName = User.Identity.Name;
                var sender = await _UserManager.GetUserAsync(User);
                message.UserID = sender.Id;
                await dbContext.Messages.AddAsync(message);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            return Error();
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
