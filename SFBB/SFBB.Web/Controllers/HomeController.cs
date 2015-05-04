using System;
using System.Linq;
using System.Web.Mvc;
using Sfbb.Data.UoW;
using SFBB.Model;

namespace SFBB.Web.Controllers
{
    public class HomeController : Controller
    {
        //Should display all forums and information about them
        public ActionResult Index()
        {
            SfbbUnitOfWork uow = new SfbbUnitOfWork();

            User user = new User();

            user.UserName = "Kyojin";
            user.PasswordHash = "cocacola";
            user.Email = "muzunov875@gmail.com";


            uow.Users.Add(user);


            return View();
        }
    }
}