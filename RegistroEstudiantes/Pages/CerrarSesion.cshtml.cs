using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RegistroEstudiantes.Pages
{
    public class CerrarSesionModel : PageModel
    {
        public void OnGet()
        {
        }

        public ActionResult OnPost() 
        {
            HttpContext.SignOutAsync().GetAwaiter().GetResult();
            
            return RedirectToPage("/Index");
        }
    }
}
