namespace MVC.Controllers
{
    using System.Web.Mvc;

    public class AdminController : Controller
    {
        public ActionResult Index(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult StudentList()
        {
            return this.View();
        }

        public ActionResult Prerequisite(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult InsertPrerequisite(int id)
        {
            ViewBag.id = id;
            return this.View();
        }

        public ActionResult Insert(int id)
        {
            ViewBag.id = id;
            return this.View();
        }
    }
}
