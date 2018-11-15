using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConfectioneryEnterprise.Core.Data;
using ConfectioneryEnterprise.Domain;
using ConfectioneryEnterprise.Web.Models;

namespace ConfectioneryEnterprise.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _unitOfWork.ClientRepository.Create(new Client());
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

        public ActionResult Personal()
        {
            return View();
        }
    }
}