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
        public DbSet<Course> CoursesTable;
        public DbSet<Department> DepartmentsTable;
        public DbSet<Reason> ReasonsTable;
        public DbSet<Semester> SemestersTable;
        public DbSet<SignInCourses> SignInCoursesTable;
        public DbSet<SignInReason> SignInReasonsTable;

        protected SignInRepo()
        {
            Table = _db.Set<SignIn>();
            CoursesTable = _db.Set<Course>();
            ReasonsTable = _db.Set<Reason>();
            SemestersTable = _db.Set<Semester>();
            DepartmentsTable = _db.Set<Department>();
            SignInCoursesTable = _db.Set<SignInCourses>();
            SignInReasonsTable = _db.Set<SignInReason>();
        }


        protected SignInRepo(DbContextOptions options) : base(options)
        {
            Table = _db.Set<SignIn>();
            CoursesTable = _db.Set<Course>();
            ReasonsTable = _db.Set<Reason>();
            SemestersTable = _db.Set<Semester>();
            DepartmentsTable = _db.Set<Department>();
            SignInCoursesTable = _db.Set<SignInCourses>();
            SignInReasonsTable = _db.Set<SignInReason>();
        }        


        public int CreateSignIn(SignIn signIn, List<Course> courses, List<Reason> reasons)
        {
            if(!SemesterExists(signIn.SemesterId))
            {
                AddSemester(signIn.SemesterId);
            }
            Table.Add(signIn);
            
            foreach(Course course in courses)
            {
                if(!CourseExists(course.CRN))
                {
                    CoursesTable.Add(course);  
                }

                SignInCoursesTable.Add(new SignInCourses
                {
                    SignInID = signIn.ID,
                    CourseID = course.CRN
                });
            }

            foreach(Reason reason in reasons)
            {
                if (!ReasonExists(reason.ID))
                {
                    ReasonsTable.Add(reason);
                }

                SignInReasonsTable.Add(new SignInReason
                {
                    SignInID = signIn.ID,
                    ReasonID = reason.ID
                });
            }

            return SaveChanges();
        }


        private void AddSemester(int id)
        {
            String name = "";
            if(id % 100 == 01)
            {
                name = "Fall " + id / 100;
            }
            else if(id % 100 == 02)
            {
                name = "Spring " + id / 100;
            }
            else
            {
                name = "Summer " + id / 100;
            }

            
            SemestersTable.Add(new Semester
            {
                ID = id,
                Name = name 
            });
        }

        public int CreateSignInCourses(SignIn signIn)
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
                OutTime = (DateTime) signIn.OutTime,
                Tutoring = signIn.Tutoring,
                Courses = signIn.Courses.Select(x => x.Course).ToList(),
                Reasons = signIn.Reasons.Select(x => x.Reason).ToList()
            };

        public bool SignInExists(int id)
        {
            return Table.Any(e => e.ID == id);
        }

        public bool CourseExists(int crn)
        {
            return CoursesTable.Any(e => e.CRN == crn);
        }

        public bool ReasonExists(int id)
        {
            return ReasonsTable.Any(e => e.ID == id);
        }

        public bool SemesterExists(int id)
        {
            return SemestersTable.Any(e => e.ID == id);
        }

        public abstract StudentInfoViewModel GetStudentInfoWithEmail(string studentEmail);

        public abstract StudentInfoViewModel GetStudentInfoWithID(int studentID);


    }
}
