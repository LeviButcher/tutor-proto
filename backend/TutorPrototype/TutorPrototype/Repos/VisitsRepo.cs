using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorPrototype.Models;
using TutorPrototype.Models.ViewModels;
using TutorPrototype.Repos.Interfaces;

namespace TutorPrototype.Repos
{
    public class VisitsRepo : BaseRepo, IVisitsRepo
    {
        public DbSet<SignIn> Table;

        public VisitsRepo()
        {
            Table = _db.Set<SignIn>();
        }
        public async Task<List<WeeklyVisitViewModel>> WeeklyVisits(DateTime startWeek, DateTime endWeek)
        {
            var result = new List<WeeklyVisitViewModel>();
            var count = 1;
            while (startWeek <= endWeek)
            {
                result.Add(new WeeklyVisitViewModel
                {
                    Week = count,
                    Count = await Table.Where(x => x.InTime >= startWeek && x.InTime <= startWeek.AddDays(7)).CountAsync()
                });
                count++;
                startWeek = startWeek.AddDays(7);
            } 
                    
                   
            //    weeklyCount.Add(await Table.Where(x => x.InTime >= startWeek && x.InTime <= startWeek.AddDays(7)).CountAsync());
            //    result.Add("Week: " + count + "Count: " + weeklyCount.ElementAt(count - 1));
            //    startWeek = startWeek.AddDays(7);
            //    count++;
            //}
           
            return result;
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
                OutTime = (DateTime)signIn.OutTime,
                Tutoring = signIn.Tutoring,
                Courses = signIn.Courses.Select(x => x.Course).ToList(),
                Reasons = signIn.Reasons.Select(x => x.Reason).ToList()
            };


    }
}
