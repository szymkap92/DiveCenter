﻿using DiveCenter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Register([FromForm]User user)
        {
            if (ModelState.IsValid)
            {
                
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Ten email jest już zarejestrowany.");
                    return View(user);
                }

                
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(user);
        }

       
        public IActionResult Login()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email);

            if (user == null || user.PasswordHash != password)
            {
                ModelState.AddModelError("", "Nieprawidłowe dane logowania.");
                return View();
            }

           
            HttpContext.Session.SetString("UserFullName", user.FullName);

            return RedirectToAction("Index", "Home");
        }

      
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
