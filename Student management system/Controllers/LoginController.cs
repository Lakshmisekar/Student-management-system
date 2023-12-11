using Student_management_system.Models.Login;
using System.Linq;
using System.Web.Mvc;

namespace Student_management_system.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Student_management_system.Models.Context.Studentcontext sc;

       
        public LoginController()
        {
            sc = new Student_management_system.Models.Context.Studentcontext();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Registration newuserclass)
        {
            var check = sc.Registrations.Where(x => x.Name.Equals(newuserclass.Name) && x.Password.Equals(newuserclass.Password)).FirstOrDefault();
            if (check != null)
            {
                Session["user"] = newuserclass.Name.ToString();
                return RedirectToAction("Home", "Student");
            }
            else
            {
                ViewBag.Notification = "Invalid Credentials";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Registration newuserclass)
        {
            ViewBag.Message = "Your login page.";
            if (sc.Registrations.Any(x => x.Name == newuserclass.Name))
            {
                ViewBag.Notification = "This account already existed";
                return RedirectToAction("Registration", "Login");
            }
            else
            {
                sc.Registrations.Add(newuserclass);
                sc.SaveChanges();

                Session["user"] = newuserclass.Name.ToString();

                return RedirectToAction("Login", "Login");
            }
        }
    }
}
