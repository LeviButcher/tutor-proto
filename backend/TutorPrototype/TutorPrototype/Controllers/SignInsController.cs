using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutorPrototype.EF;
using TutorPrototype.Models;
using TutorPrototype.Models.ViewModels;
using TutorPrototype.Repos.Interfaces;

namespace TutorPrototype.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignInsController : ControllerBase
    {
        private readonly TPContext _context;
        private ISignInRepo _iRepo;

        public SignInsController(TPContext context, ISignInRepo iRepo)
        {
            _context = context;
            _iRepo = iRepo;
        }

        //// GET: api/SignIns/Get/0/10
        //[HttpGet]
        //public IEnumerable<SignIn> Get([FromQuery] int skip = 0, [FromQuery] int take = 10)
        //{
        //   return Ok(_iRepo.GetAll(skip, take));
        //   return  _context.SignIns.AsEnumerable();
        //}

        //[HttpGet("{userId}")]
        //public IActionResult Followers(string userId, [FromQuery] int skip = 0, [FromQuery] int take = 10)
        //{
        //   var result = Ok(_iRepo.GetFollowers(userId, skip, take));
        //   return result;
        //}

        // GET: api/SignIns/Get/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            //TODO: Check if SignIn Exists first
            return Ok(await _iRepo.GetSignIn(id));
        }

        // PUT: api/SignIns/UpdateSignIn/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSignIn([FromRoute] int id, [FromBody] SignIn signIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signIn.ID)
            {
                return BadRequest();
            }

            _context.Entry(signIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignInExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/SignIns/SignOut/5
        [HttpPut("{id}")]
        public async Task<IActionResult> SignOut([FromRoute] int id, [FromBody] SignIn signIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signIn.ID)
            {
                return BadRequest();
            }

            _context.Entry(signIn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignInExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // GET: api/SignIns/SignInExists/5
        [HttpGet("{id}")]
        private bool SignInExists([FromRoute] int id)
        {
            return _iRepo.SignInExists(id);
        }

        // GET: api/SignIns/GetStudentInfoWithID/5
        [HttpGet("{studentID}")]
        public StudentInfoViewModel GetStudentInfoWithID([FromRoute] int studentID)
        {
            return _iRepo.GetStudentInfoWithID(studentID);
        }

        // GET: api/SignIns/GetStudentInfoWithID/email
        [HttpGet("{studentEmail}")]
        public StudentInfoViewModel GetStudentInfoWithEmail([FromRoute] string studentEmail)
        {
            return _iRepo.GetStudentInfoWithEmail(studentEmail);
        }
    }
}