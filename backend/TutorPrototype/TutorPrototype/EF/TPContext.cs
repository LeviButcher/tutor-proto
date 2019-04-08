﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TutorPrototype.Models;

namespace TutorPrototype.EF
{
    public class TPContext : DbContext
    {
        protected string connection = @"Server=(localdb)\mssqllocaldb;Database=TutorProto;Trusted_connection=True;MultipleActiveResultSets=true;";

        public DbSet<Course> Courses { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Reason> Reasons { get; set; }

        public DbSet<SignIn> SignIns { get; set; }

        public DbSet<Semester> Semesters{ get; set; }

        public DbSet<SignInCourses> SignInCourses{ get; set; }

        public DbSet<SignInReason> SignInReasons{ get; set; }

        public DbSet<Department> Departments { get; set; }

        

        public TPContext()
        {

        }

      
        public TPContext(DbContextOptions options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception)
            {
                //Book says do something intelligent here
            }
        }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connection, options => options.EnableRetryOnFailure());
            }
        }
    }
}