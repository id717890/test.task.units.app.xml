namespace app_for_xml.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string message)
        {
            ViewBag.message = message;
            return View();
        }
    }
}