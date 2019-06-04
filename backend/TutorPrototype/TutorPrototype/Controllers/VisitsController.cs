using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutorPrototype.EF;
using TutorPrototype.Models;
using TutorPrototype.Models.ViewModels;
using TutorPrototype.Repos.Interfaces;

namespace TutorPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {

        private readonly TPContext _context;
        private IVisitsRepo _iRepo;


        public VisitsController(TPContext context, IVisitsRepo iRepo)
        {
            _context = context;
            _iRepo = iRepo;
        }

        // GET api/visits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeeklyVisitViewModel>>> Get([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            return Ok(await _iRepo.WeeklyVisits(start, end));
        }

        //[HttpGet]
        //public string Get([FromQuery] DateTime start, [FromQuery] DateTime end)
        //{
        //    return "dates are: " + start + "end: " + end;
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
