using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConfectioneryEnterprise.Core.Data;
using ConfectioneryEnterprise.Core.Server;
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

        public ActionResult Buy(int id)
        {
            var pastry = _unitOfWork.PastryRepository.Get(x => x.Id == id).FirstOrDefault();

            string message = $"\nBuy product - name {pastry.Name}, brand {pastry.Brand}, type {pastry.Type}";
            SynchronousSocketClient.SendMessage(message);

            var pastries = _unitOfWork.PastryRepository.GetAll().ToList();
            return View("Menu", pastries);
        }

        public ActionResult Menu()
        {
            var pastries = _unitOfWork.PastryRepository.GetAll().ToList();

            return View(pastries);
        }

        [HttpGet]
        public ActionResult Login(LoginViewModel loginVM)
        {
            var user = _unitOfWork.ClientRepository
                .First(x => x.Login == loginVM.Login && x.Password == loginVM.Password);

            string message = $"\nLogin client: {user.Login}\nPassword: {user.Password}";
            SynchronousSocketClient.SendMessage(message);

            if (user == null)
                return View("Error");

            return View("Personal", user);

        }

        public ActionResult Personal(LoginViewModel loginVM)
        {
            var user = _unitOfWork.ClientRepository
                .First(x => x.Login == loginVM.Login && x.Password == loginVM.Password);

            return View(user);
        }
    }
}