using System.Collections.Generic;
using System.Web.Mvc;
using Courts_Searchable_Dropdown.Models;

namespace Courts_Searchable_Dropdown.Controllers
{
    public class CourtsController : Controller
    {
        public ActionResult Show()
        {
            // Let's get all states that we need for a DropDownList
            var courts = GetAllCourts();

            var model = new Courts();

            // Create a list of SelectListItems so these can be rendered on the page
            model.CourtsListItems = GetSelectListItems(courts);

            return View(model);
        }
        
        [HttpPost]
        public ActionResult Show(Courts model)
        {
            var courts = GetAllCourts();
            
            model.CourtsListItems = GetSelectListItems(courts);
            
            if (ModelState.IsValid)
            {
                Session["Courts"] = model;
                return RedirectToAction("Details");
                //return Content("This is working");
            }

            return View("Show", model);
        }

        public ActionResult Details()
        {
            
            
            var model = Session["Courts"] as Courts;

            //return Content("Nader is here");
            
            return View(model);
        }

        // Just return a list of states - in a real-world application this would call
        // into data access layer to retrieve states from a database.
        private IEnumerable<string> GetAllCourts()
        {
            return new List<string>
            {
                "Jeddah",
                "East Riyadh",
                "North Riyadh",
                "Makkah Almukkaramah",
                "Taif",
                "Abha",
                "Najran",
                "المحكمة العامة بجدة"
            };
        }
        
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }
    }
}