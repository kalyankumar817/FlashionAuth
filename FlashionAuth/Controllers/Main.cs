using FlashionAuth.Data;
using FlashionAuth.Models;
using FlashionAuth.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Cryptography.X509Certificates;

namespace FlashionAuth.Controllers
{
    public class Main : Controller
    {
        private readonly MvcDemoDbContext mvcDemoDbContext;
        public Main(MvcDemoDbContext mvcdemoDbContext)
        {
            this.mvcDemoDbContext = mvcdemoDbContext;
        }
        //signuppage get
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        //signuppage  post
        [HttpPost]
        public async Task<IActionResult> Signup(Signupform signupformrequest)
        {
            if (ModelState.IsValid)
            {
                var signupdata = new Signupdata()
                {
                    name = signupformrequest.name,
                    username = signupformrequest.username,
                    password = signupformrequest.password
                };
                await mvcDemoDbContext.Signupdatas.AddAsync(signupdata);
                await mvcDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View();
        }

        //login page get
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //login page post
        [HttpPost]
        public async Task<IActionResult> Login(Loginform loginformRequest)
        {
            if (ModelState.IsValid)
            {
                var user = await mvcDemoDbContext.Signupdatas.FirstOrDefaultAsync(u => u.username == loginformRequest.username && u.password == loginformRequest.password);
                if (user != null)
                {
                    return RedirectToAction("Home");
                }
                // Authentication failed, show an error message
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }
        //menswear
        public IActionResult Menswear()
        {
            return View();
        }
        //womenswear
        public IActionResult Womenswear()
        {
            return View();
        }
        //Kidswear
        public IActionResult Kidswear()
        {
            return View();
        }

        //search filter
        [HttpGet]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("Home");
            }

            switch (query.ToLower())
            {
                case "menswear":
                    return RedirectToAction("Menswear");
                case "womenswear":
                    return RedirectToAction("Womenswear");
                case "kidswear":
                    return RedirectToAction("Kidswear");
                default:
                    // Optionally, handle unknown queries, e.g., show a search results page
                    return RedirectToAction("Home");
            }
        }
    }
}
