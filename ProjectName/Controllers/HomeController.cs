using Microsoft.AspNetCore.Mvc;

namespace Replace.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}