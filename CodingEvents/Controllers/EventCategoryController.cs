using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<EventCategory> category = context.Category.ToList();
            return View(category);

        }

      
        public IActionResult Create()
        {
            AddEventCategoryViewModel addEventCategoryViewModel = new AddEventCategoryViewModel();

            return View(addEventCategoryViewModel);
        }

        [HttpPost]
        [Route("/EventCategory")]
        public IActionResult ProcessCreateEventCategoryForm(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory newEvent = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name,
                };

                context.Category.Add(newEvent);
                context.SaveChanges();

                return Redirect("/EventCategory");

            }
            return View(addEventCategoryViewModel);
        }
    }
}

