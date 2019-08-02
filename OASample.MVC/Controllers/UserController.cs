using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OASample.Repo.Converter;
using OASample.Data.ViewModel;
using OASample.Service;
using Microsoft.Extensions.Localization;

namespace OASample.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            //var converter = this.converterFactory.CreateConverter<User,UserViewModel>();
            var result = this.userService.GetUsers().ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            UserViewModel vm = new UserViewModel();
            return PartialView("_AddUser", vm);
        }

        public IActionResult EditUser(int id)
        {
            var vm = this.userService.GetUserById(id);
            return PartialView("_AddUser", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                this.userService.AddUser(vm);
                this.RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}