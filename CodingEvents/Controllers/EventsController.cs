﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;
using CodingEvents.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            return View(addEventViewModel);
        }

        [HttpPost]
         public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            Event newEvent = new Event
            {
                Name = addEventViewModel.Name,
                Description = addEventViewModel.Description
            };
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            //going into events data and using get by ID method; and store event by ID then putting in viewbag
            Event editEvent = EventData.GetById(eventId);
            ViewBag.editEvent = editEvent;
            ViewBag.eventTitle = $"Edi Event {editEvent.Name}(id= {editEvent.Id}";       

            return View();
        }


        [HttpPost]
        [Route("Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            // controller code will go here
            Event editEvent = EventData.GetById(eventId);
            editEvent.Name = name;
            editEvent.Description = description;
            return Redirect("/Events");
        }

    }
}

