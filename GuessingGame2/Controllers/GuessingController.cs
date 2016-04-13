using GuessingGame2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessingGame2.Controllers
{
    public static class SessionKeys
    {
        public const string Counters = "Counters";
    }

    public class GuessingController : Controller
    {


        Random rnd = new Random();

        public ActionResult Index()
        {
            //Session["ComputerCounter"] = 0;
            //Session["Counter"] = 0;

            Session[SessionKeys.Counters] = new Counters();

            Session["Answer"] = rnd.Next(1, 11);

            return View();
        }

        private int ComputerGuessing()
        {
            var answer = (int)Session["Answer"];
            var counter = 0;
            var guess = 0;

            do
            {
                guess = rnd.Next(1, 11);
                counter++;
            } while (guess != answer);

            return counter;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Guessing model)
        {
            if (ModelState.IsValid)
            {
                var answer = (int)Session["Answer"];

                var counters = (Counters)Session[SessionKeys.Counters];
                counters.PlayerCounter++;

                if (model.Guess > answer)
                {
                    ViewBag.Win = -1;
                }
                else if (model.Guess < answer)
                {
                    ViewBag.Win = 1;
                }
                else
                {
                    ViewBag.Win = 0;
                    counters.ComputerCounter = ComputerGuessing();
                }
            }

            return View(model);
        }
    }
}