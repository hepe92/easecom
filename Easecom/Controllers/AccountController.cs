using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easecom.Models;
using Easecom.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Easecom.Controllers
{
    public class AccountController : Controller
    {
        AccountService accountService;


        public AccountController(AccountService accountService, CaseService service)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        [Route("")]
        [Route("login")]
        public IActionResult Login(string returnUrl)
        {
            var model = new AccountLoginVM { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        [Route("logIn")]
        public async Task<IActionResult> Login(AccountLoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Check if credentials is valid (and set auth cookie)
            if (!await accountService.TryLoginAsync(viewModel))
            {
                // Show login error
                ModelState.AddModelError(nameof(AccountLoginVM.Username), "Invalid credentials");
                return View(viewModel);
            }
                        

            // Redirect user
            if (string.IsNullOrWhiteSpace(viewModel.ReturnUrl))
                return RedirectToAction(nameof(CaseController.Index),"case");
                //return RedirectToAction("Index", "Case", "case");
            else
                return Redirect(viewModel.ReturnUrl);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountCreateVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(nameof(Login));

            await accountService.AddAccountAsync(viewModel);
            return RedirectToAction(nameof(Login));
        }
    }
}