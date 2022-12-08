﻿using Codecool.CodecoolShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace Codecool.CodecoolShop.Controllers
{
    public class RegistrationController : Controller
    {
        public RegisterRepository registerRepository;

        public RegistrationController(RegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username,string password)
        {
            registerRepository.InsertUserIntoDb(username, password);
            return Redirect("Registration/LogIn");
        }



        [HttpGet]
        
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string username, string password)
        {
            if (registerRepository.IsUserRegistered(username, password))
            {
                return Redirect("/Index");
            }
            return Redirect("Registration/Register");
            
        }


    }
}
