using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tarea2.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Tarea )).";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Información del contacto";

			return View();
		}
	}
}