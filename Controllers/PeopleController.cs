using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteTakerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;

        private List<Models.Person> _people = new List<Models.Person>
        {
            new Models.Person
            {
                Id = 1,
                Name = "Veikko Lavi"
            },
            new Models.Person
            {
                Id = 2,
                Name = "Kikka"
            },
            new Models.Person
            {
                Id = 3,
                Name = "Reijo Taipale"
            },
            new Models.Person
            {
                Id = 4,
                Name = "Tapio Rautavaara"
            },
            new Models.Person
            {
                Id = 5,
                Name = "Arja Koriseva"
            },
            new Models.Person
            {
                Id = 6,
                Name = "Taiska"
            },
        };

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Fetch a list of all available people.
        /// </summary>
        /// <returns>All people in the storage</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Models.Person>> Get()
        {
            return new OkObjectResult(_people);
        }
    }
}
