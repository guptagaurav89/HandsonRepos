using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnockoutSample.ViewModel;

namespace KnockoutSample.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Countries = new List<Country>(){
                new Country()
                {
                    Id = 1,
                    Name = "India"
                },
                new Country()
                {
                    Id = 2,
                    Name = "USA"
                },
                new Country()
                {
                    Id = 3,
                    Name = "France"
                }
            };

            var viewModel = new Person()
            {
                Id = 1,
                Name = "Naveen",
                DateOfBirth = new DateTime(1990, 11, 21)
            };

            return View(viewModel);
        }
        [HttpPost]
        public JsonResult SavePersonDetails(Person viewModel)
        {
            // TODO: Save logic goes here.

            return Json(new { });
        } 
    }
}
