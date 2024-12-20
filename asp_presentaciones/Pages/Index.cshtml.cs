using lib_utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace asp_presentaciones.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contraseņa { get; set; }

        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Email = string.Empty;
                Contraseņa = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        //public void OnPostBtEnter()
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(Email) &&
        //            string.IsNullOrEmpty(Contraseņa))
        //        {
        //            OnPostBtClean();
        //            return;
        //        }

        //        if ("Usuario.123" != Email + "." + Contraseņa)
        //        {
        //            OnPostBtClean();
        //            return;
        //        }
        //        ViewData["Logged"] = true;
        //        HttpContext.Session.SetString("Usuario", Email!);
        //        EstaLogueado = true;
        //        OnPostBtClean();
        //    }
        //    catch (Exception ex)
        //    {
        //        LogConversor.Log(ex, ViewData!);
        //    }
        //}


        public void OnPostBtEnter()
        {
            try
            {
                // Mira que meta todos los datos
                if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contraseņa))
                {
                    OnPostBtClean();
                    return;
                }

                // Mira si es usuario
                if (Email == "Usuario" && Contraseņa == "123")
                {
                    ViewData["Logged"] = true;
                    HttpContext.Session.SetString("Usuario", Email!);
                    EstaLogueado = true;
                    OnPostBtClean();
                    return;
                }

                // Mira si es empresa
                if (Email == "Empresa" && Contraseņa == "321")
                {
                    ViewData["Logged"] = true;
                    HttpContext.Session.SetString("Empresa", Email!);
                    EstaLogueado = true;
                    OnPostBtClean();
                    return;
                }
                if (Email == "Administrador" && Contraseņa == "3312")
                {
                    ViewData["Logged"] = true;
                    HttpContext.Session.SetString("Administrador", Email!);
                    EstaLogueado = true;
                    OnPostBtClean();
                    return;
                }
                //Si mete contraseņa o email incorrectos
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}