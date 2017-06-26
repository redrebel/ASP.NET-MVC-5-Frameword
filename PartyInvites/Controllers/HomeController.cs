using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
			int hour = DateTime.Now.Hour;
			this.ViewBag.Greeting = hour < 12 ? "Good Morning" : " Good Afternoon";
            return View();
        }

		[HttpGet]
		public ViewResult RsvpForm()
		{
			return View();
		}

		[HttpPost]
		public ViewResult RsvpForm(GuestResponse guestResponse)
		{
			if (ModelState.IsValid)
			{
				return View("Thanks", guestResponse);
			} else
			{
				// 유효성 검사 오류가 존재한다.
				return View();
			}
		}
	}
}