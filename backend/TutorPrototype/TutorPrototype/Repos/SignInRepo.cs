using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorPrototype.EF;
using TutorPrototype.Models;
using TutorPrototype.Models.ViewModels;
using TutorPrototype.Repos.Interfaces;

namespace TutorPrototype.Repos
{
    public abstract class SignInRepo : BaseRepo, ISignInRepo
    {
        public DbSet<SignIn> Table;

        protected SignInRepo()
        {
            Table = _db.Set<SignIn>();
        }

        protected SignInRepo(DbContextOptions options) : base(options)
        {
            Table = _db.Set<SignIn>();
        }

        public int CreateSignIn(SignIn signIn)
        {
            Table.Add(signIn);

            return SaveChanges();
        }

        public int UpdateSignIn(SignIn signIn)
        {
            Table.Update(signIn);

            return SaveChanges();
        }

        public async Task<SignInViewModel> GetSignIn(int id)
        {
            if(!SignInExists(id))
            {
                return null;
            }

            var signIn =  await Table.Include(e => e.Person).Include(e => e.Semester).Include(x => x.Courses)
                            .ThenInclude(x => x.Course).ThenInclude(x=>x.Department)
                            .Include(x=> x.Reasons).ThenInclude(x => x.Reason)
                            .Where(x => x.ID == id).Select(item => GetRecord(item)).FirstAsync();

            return signIn;
        }

        private static SignInViewModel GetRecord(SignIn signIn) =>
            new SignInViewModel()
            {
                Id = signIn.ID,
                PersonId = signIn.PersonId,
                FirstName = signIn.Person.FirstName,
                LastName = signIn.Person.LastName,
                FullName = signIn.Person.FirstName + " " + signIn.Person.LastName,
                Email = signIn.Person.Email,
                SemesterId = signIn.SemesterId,
                SemesterName = signIn.Semester.Name,
                InTime = signIn.InTime,
                OutTime = signIn.OutTime,
                Tutoring = signIn.Tutoring,
                Courses = signIn.Courses.Select(x => x.Course).ToList(),
                Reasons = signIn.Reasons.Select(x => x.Reason).ToList()
            };

        public bool SignInExists(int id)
        {
            return Table.Any(e => e.ID == id);
        }

        public abstract StudentInfoViewModel GetStudentInfoWithEmail(string studentEmail);

        public abstract StudentInfoViewModel GetStudentInfoWithID(int studentID);


    }
}
