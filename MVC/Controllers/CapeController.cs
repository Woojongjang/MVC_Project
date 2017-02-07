namespace MVC.Controllers
{
    using System.Web.Mvc;
    public class CapeController : Controller
    {
        //
        // GET: /Cape/
        public ActionResult Index(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult Edit(string id, string course)
        {
            ViewBag.Class = course;
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult Insert(string id, string course)
        {
            ViewBag.Class = course;
            ViewBag.Id = id;
            return this.View();
        }
    }
}