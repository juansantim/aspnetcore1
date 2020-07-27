using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegistroEstudiantes.Data;
using RegistroEstudiantes.Dto;

namespace RegistroEstudiantes.Pages
{
    [AllowAnonymous]
    public class IniciarSesionModel : PageModel
    {
        [BindProperty]
        public LoginModel loginModel { get; set; }

        public void OnGet()
        {
            
        }

        public ActionResult OnPost(string returnUrl = "/Index") 
        {
            returnUrl = returnUrl == "/" ? "/Index" : returnUrl;

            SecurityService service = new SecurityService();

            var usuario = service.VerificarCredenciales(loginModel.Login, loginModel.Password);

            if (usuario != null) 
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nombre + " " +usuario.Apellido),
                    new Claim(ClaimTypes.Role, usuario.Rol)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = loginModel.Recordarme
                    }).GetAwaiter().GetResult();


                return RedirectToPage(returnUrl);
            }

            return Page();
        }
    }
}
