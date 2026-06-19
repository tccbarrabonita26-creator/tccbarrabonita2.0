using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BarraBonitaTurismo.Filters
{
    public class AdminAuthFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var isLogged = context.HttpContext.Session.GetString("AdminLogado");

            if (isLogged != "true")
            {
                context.Result = new RedirectToActionResult("Login", "Admin", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
