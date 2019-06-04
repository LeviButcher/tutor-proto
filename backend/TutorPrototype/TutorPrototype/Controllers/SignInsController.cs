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
        public async Task<ActionResult<SignInViewModel>> Get([FromRoute] int id)
        {
            return Ok(await _iRepo.GetSignIn(id));
        }

         // POST: api/SignIns/
        [HttpPost]
        public IActionResult Create([FromBody] SignInViewModel signInViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SignIn signIn = new SignIn();
            signIn.PersonId = signInViewModel.PersonId;
            signIn.SemesterId = signInViewModel.SemesterId;
            signIn.Tutoring = signInViewModel.Tutoring;
            signIn.InTime = DateTime.Now;

            List<Course> courses = signInViewModel.Courses;
            List<Reason> reasons = signInViewModel.Reasons;
            
            return Ok(_iRepo.CreateSignIn(signIn, courses, reasons));         
        }

        // PUT: api/SignIns/5
        [HttpPut("/signIns/{id}")]
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
        }
        
        // GET: api/SignIns/1/id
        [HttpGet("{studentID}/id")]
        public StudentInfoViewModel GetStudentInfoWithID([FromRoute] int studentID)
        {
            return _iRepo.GetStudentInfoWithID(studentID);
        }

        // GET: api/SignIns/student@wvup.edu/email
        [HttpGet("{studentEmail}/email")]
        public StudentInfoViewModel GetStudentInfoWithEmail([FromRoute] string studentEmail)
        {
            return _iRepo.GetStudentInfoWithEmail(studentEmail);
        }
    }
}