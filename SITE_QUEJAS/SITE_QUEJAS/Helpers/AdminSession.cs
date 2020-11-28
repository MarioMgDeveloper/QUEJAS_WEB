using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SITE_QUEJAS.Helpers
{
    public class AdminSession
    {
        HttpContext httpContext;

        public AdminSession(HttpContext httpContext)
        {
            this.httpContext = httpContext;
        }

        public void SetString(string value, string key)
        {
            httpContext.Session.SetString(key, value);
        }

        public string GetString(string key)
        {
            var respuesta = httpContext.Session.GetString(key);
            return (respuesta);
        }

        public void Remove(string key)
        {
            httpContext.Session.Remove(key);
        }

        public void SetObject(string key, object value)
        {
            httpContext.Session.SetObject(key, value);
        }

        public T GetObject<T>(string key)
        {
            var respuesta = httpContext.Session.GetObject<T>(key);
            return (respuesta);
        }

        public string GetClaim(string nameClaim)
        {
            try
            {
                var claim = httpContext.User.Claims.First(c => c.Type.Equals(nameClaim));

                return claim.Value;
            }
            catch
            {
                return null;
            }
        }
        public void RemoveClaim(string nameClaim)
        {
            try
            {
                var principal = httpContext.User as ClaimsPrincipal;
                var identity = principal.Identity as ClaimsIdentity;
                var claim = (from c in principal.Claims
                             where c.Type == nameClaim
                             select c).FirstOrDefault();
                identity.RemoveClaim(claim);
                var props = new AuthenticationProperties();
                props.IsPersistent = false;
                httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
            }
            catch
            {
            }
        }

        public bool CheckSession()
        {

            bool ok = false;

            try
            {
                if (GetClaim(VariablesDeSession.Token) != null)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return ok;
        }
    }
}
