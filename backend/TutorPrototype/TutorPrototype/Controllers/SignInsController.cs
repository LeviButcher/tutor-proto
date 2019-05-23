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
    [Route("api/[controller]")]
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

        // GET: api/SignIns/5
        [HttpGet("{id}")]
        [Route("{id:int}/")]
        public async Task<ActionResult<SignInViewModel>> Get([FromRoute] int id)
        {
            var signIn = await _iRepo.GetSignIn(id);

            if(signIn == null)
            {
                return NotFound();
            }
            return signIn;
        }

         // POST: api/SignIns/
        [HttpPost]
        public IActionResult Create([FromBody] SignIn signIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }      

            return Ok(_iRepo.CreateSignIn(signIn));

        }

        // PUT: api/SignIns/5
        [HttpPut("{id}")]
        [Route("{id:int}/")]
        public IActionResult Update([FromRoute] int id, [FromBody] SignIn signIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signIn.ID)
            {
                return BadRequest();
            }

            return Ok(_iRepo.UpdateSignIn(signIn));
        }

        //PUT: api/SignIns/5/SignOut
        [HttpPut("{id}")]
        [Route("{id:int}/SignOut")]
        public IActionResult SignOut([FromRoute] int id, [FromBody] SignIn signIn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signIn.ID)
            {
                return BadRequest();
            }

            signIn.OutTime = DateTime.Now;

            return Ok(_iRepo.UpdateSignIn(signIn));

            //_context.Entry(signIn).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!SignInExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }
        //TODO:   Make certain these work independently

        // GET: api/SignIns/5/student
        [HttpGet("{studentID}/student")]
        public StudentInfoViewModel GetStudentInfoWithID([FromRoute] int studentID)
        {
            return _iRepo.GetStudentInfoWithID(studentID);
        }

        // GET: api/SignIns/student@wvup.edu/student
        [HttpGet("{studentEmail}/student")]
        public StudentInfoViewModel GetStudentInfoWithEmail([FromRoute] string studentEmail)
        {
            return _iRepo.GetStudentInfoWithEmail(studentEmail);
        }
    }
}