using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingEvents.Models
{
    public enum EventType
    {
        Conference,
        Meetup,
        Workshop,
        Social

   // public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
   //{
   //   new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
   //   new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
   //   new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
   //   new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString())
   //};

    }

    
}
