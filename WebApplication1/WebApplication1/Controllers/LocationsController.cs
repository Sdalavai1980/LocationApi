using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Http;

// System.Web.Http.Common;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private static List<Location> locations = new List<Location>
    {
        new Location { Id = 1, Name = "Location1", AvailabilityStartTime = DateTime.Parse("10:00 AM"), AvailabilityEndTime = DateTime.Parse("1:00 PM") },
        new Location { Id = 2, Name = "Location2", AvailabilityStartTime = DateTime.Parse("9:00 AM"), AvailabilityEndTime = DateTime.Parse("12:00 PM") },
        // Add more locations as needed
    };
        [HttpGet]
        [Route("api/locations/availability")]
        public IHttpActionResult GetLocationsWithAvailability()
        {
            DateTime startTime = DateTime.Parse("10:00 AM");
            DateTime endTime = DateTime.Parse("1:00 PM");

            var availableLocations = locations
                .Where(l => l.AvailabilityStartTime <= startTime && l.AvailabilityEndTime >= endTime)
                .Select(l => new { l.Id, l.Name })
                .ToList();

            return Ok(availableLocations);
        }


    }
}
