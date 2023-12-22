using Student_management_system.Models.Login;
using Student_management_system.Models.Repository;
using System.Linq;
using System.Web.Mvc;

namespace Student_management_system.Controllers
{
    public class LoginController : Controller
    {

        //Student_management_system.Models.Context.Studentcontext sc;
        private readonly IRegistrationRepository _registrationRepository;
        //public LoginController()
        //{
        //    sc = new Student_management_system.Models.Context.Studentcontext();
        //}

        public LoginController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        [HttpPost]
        public ActionResult Login(Registration newuserclass)
        {
            var check = _registrationRepository.GetRegistration(newuserclass.Name);

            if (check != null && check.Password == newuserclass.Password)
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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Login(Registration newuserclass)
        //{
        //    var check = sc.Registrations.Where(x => x.Name.Equals(newuserclass.Name) && x.Password.Equals(newuserclass.Password)).FirstOrDefault();
        //    if (check != null)
        //    {
        //        Session["user"] = newuserclass.Name.ToString();
        //        return RedirectToAction("Home", "Student");
        //    }
        //    else
        //    {
        //        ViewBag.Notification = "Invalid Credentials";
        //    }
        //    return View();
        //}

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Registration newuserclass)
        {
            ViewBag.Message = "Your login page.";
            var existingUser = _registrationRepository.GetRegistration(newuserclass.Name);

            if (existingUser != null)
            {
                ViewBag.Notification = "This account already exists";
                return RedirectToAction("Login", "Login");
            }
            else
            {
                _registrationRepository.AddRegistration(newuserclass);
                Session["user"] = newuserclass.Name.ToString();

                return RedirectToAction("Login", "Login");
            }
        }

        //[HttpPost]
        //public ActionResult Registration(Registration newuserclass)
        //{
        //    ViewBag.Message = "Your login page.";
        //    if (sc.Registrations.Any(x => x.Name == newuserclass.Name))
        //    {
        //        ViewBag.Notification = "This account already existed";
        //        return RedirectToAction("Login", "Login");
        //    }
        //    else
        //    {
        //        sc.Registrations.Add(newuserclass);
        //        sc.SaveChanges();

        //        Session["user"] = newuserclass.Name.ToString();

        //        return RedirectToAction("Login", "Login");
        //    }
        //}



    }

}
