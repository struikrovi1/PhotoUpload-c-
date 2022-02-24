using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.AgencyAdmin.Controllers
{
    [Area(nameof(AgencyAdmin))]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
