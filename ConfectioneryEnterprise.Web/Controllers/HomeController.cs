using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConfectioneryEnterprise.Core.Data;
using ConfectioneryEnterprise.Domain;
using ConfectioneryEnterprise.Web.Models;
using ConfectioneryEnterprise.Web.ViewModels;

namespace ConfectioneryEnterprise.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            //Generator.Generate();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Menu()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(LoginViewModel loginVM)
        {
            var user = _unitOfWork.ClientRepository
                .First(x => x.Login == loginVM.Login && x.Password == loginVM.Password);

            if (user == null)
                return View("Error");

            return View("Personal");

        }

        public ActionResult Personal(LoginViewModel loginVM)
        {
            return View();
        }
    }
}