namespace MVC.Controllers
{
    using System.Web.Mvc;

    public class StudentController : Controller
    {
        public ActionResult Index(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        public ActionResult AddCourse(string id)
        {
            ViewBag.Id = id;
            return this.View();
        }

        //ADD STUFF HERE TO CRUD CAPE AND PREREQS
        public ActionResult Cape(string id, string course)
        {
            ViewBag.Class = course;
            ViewBag.Id = id;
            return this.View();
        }
    }
}
