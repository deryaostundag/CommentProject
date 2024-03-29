﻿using CommentProject.EntityLayer.Concrete;
using CommentProject.Models.AppUserViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel registerViewModel)
        {
            var appUser= new AppUser();
            {
                appUser.Name = registerViewModel.Name;
                appUser.Surname = registerViewModel.Surname;
                appUser.Email = registerViewModel.Mail;
                appUser.UserName=registerViewModel.UserName;
                appUser.Image = "text";
            };
            if (registerViewModel.Password == registerViewModel.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);
                if (result.Succeeded) 
                { 
                    return RedirectToAction("Index", "Login"); 
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifreler birbiriyle uyuşmuyor!");
            }
            return View();
        }
    }
}
