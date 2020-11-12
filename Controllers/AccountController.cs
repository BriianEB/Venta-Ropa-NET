using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentaRopa.Data;
using Microsoft.AspNetCore.Mvc;
using VentaRopa.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace VentaRopa.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(LoginViewModel registrarModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = new ApplicationUser
                {
                    UserName = registrarModel.Nombre
                };

                var resultado = await _userManager.CreateAsync(usuario, registrarModel.Clave);

                if (resultado.Succeeded)
                {
                    await _signInManager.SignInAsync(usuario, false);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(registrarModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByNameAsync(loginModel.Nombre);

                if (usuario != null)
                { 
                    var resultado = await _signInManager.PasswordSignInAsync(usuario, loginModel.Clave, false, false);

                    if (resultado.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
