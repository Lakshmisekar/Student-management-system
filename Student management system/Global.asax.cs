using Student_management_system.Models.Context;
using Student_management_system.Models.Interface;
using Student_management_system.Models.IRepository;
using Student_management_system.Models.Repository;
using Student_management_system.Models.Student;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Services.Description;
using Unity;
using Unity.AspNet.Mvc;

namespace Student_management_system
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var container = new UnityContainer();
            container.RegisterType<IAttendanceService, AttendanceService>();
            container.RegisterType<IRegistrationRepository, RegistrationRepository>();
            container.RegisterType<IAttendanceRepository, AttendanceRepository>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<Studentcontext>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

           
        }
    }
}
