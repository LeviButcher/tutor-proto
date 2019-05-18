using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorPrototype.EF;
using TutorPrototype.Models;
using TutorPrototype.Models.ViewModels;

namespace TutorPrototype.Repos
{
    public class DevSignInRepo : SignInRepo
    {
        
        public DbSet<Person> PersonTable;
        public DbSet<Course> CourseTable;

        public override StudentInfoViewModel GetStudentInfoWithEmail(string studentEmail)
        {
            return GetStudentInfo();
        }

        public override StudentInfoViewModel GetStudentInfoWithID(int studentID)
        {
            return GetStudentInfo();
        }

        private StudentInfoViewModel GetStudentInfo()
        {
            PersonTable = _db.Set<Person>();
            CourseTable = _db.Set<Course>();

            StudentInfoViewModel studentInfoViewModel = new StudentInfoViewModel();
            
            Person newStudent = PersonTable.Where(x => x.Email == "mtmqbude26@wvup.edu").First();
            studentInfoViewModel.studentEmail = newStudent.Email;
            studentInfoViewModel.firstName = newStudent.FirstName;
            studentInfoViewModel.lastName = newStudent.LastName;
            studentInfoViewModel.studentID = newStudent.ID;
            studentInfoViewModel.semesterId = 201903;

            List<Course> schedule = new List<Course>();
            Course first = CourseTable.Where(x => x.CRN == 1).First();
            Course second = CourseTable.Where(x => x.CRN == 2).First();
            Course third = CourseTable.Where(x => x.CRN == 3).First();
            Course fourth = CourseTable.Where(x => x.CRN == 4).First();
            schedule.Add(first);
            schedule.Add(second);
            schedule.Add(third);
            schedule.Add(fourth);

            studentInfoViewModel.classSchedule = schedule;

            return studentInfoViewModel;
        }
    }
}
