using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SITE_QUEJAS.Helpers;
using SITE_QUEJAS.Models.Account;

namespace SITE_QUEJAS.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostLogin(ClsLogin model)
        {
            if (ModelState.IsValid)
            {
                AdminSession session = new AdminSession(HttpContext);
                ClsPeticiones peticion = new ClsPeticiones();

                var response = await peticion.PostComplejo<ClsLogin, Cls_Response<ClsInfoUsuario>>(model, "AdmonUsuarios/Login");

                if (!response.Error)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Role, response.Body.NombreRol));
                    claims.Add(new Claim(VariablesDeSession.IdUsuario, response.Body.IdUsuario.ToString()));
                    claims.Add(new Claim(VariablesDeSession.Token, response.Body.JWT));
                    session.SetObject(VariablesDeSession.InfoUsuario, response.Body);

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    //props.IsPersistent = false;
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = response.Message;
                    return View("Login", model);
                }
            }
            else
            {
                return View("Login", model);
            }
        }

        [HttpGet]
        public  async Task<IActionResult> Salir()
        {
            AdminSession sesion = new AdminSession(HttpContext);

            HttpContext.Session.Clear();
            HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Cookies.Delete(".AspNetCore." + CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var prop = new AuthenticationProperties()
            {
                RedirectUri = "/Account/Index"
            };
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, prop);
            ViewBag.tk = sesion.GetClaim(VariablesDeSession.Token);
            ViewBag.CerarSesion = "si";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AccessoDenegado()
        {
            return View();
        }
    }
}
