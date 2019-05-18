﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutorPrototype.EF;

namespace TutorPrototype.Migrations
{
    [DbContext(typeof(TPContext))]
    [Migration("20190515015223_AddInverseProperties")]
    partial class AddInverseProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TutorPrototype.Models.Course", b =>
                {
                    b.Property<int>("CRN")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("ShortName");

                    b.HasKey("CRN");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TutorPrototype.Models.Department", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Code");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TutorPrototype.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("TutorPrototype.Models.Reason", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Reasons");
                });

            modelBuilder.Entity("TutorPrototype.Models.Semester", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("TutorPrototype.Models.SignIn", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InTime");

                    b.Property<DateTime>("OutTime");

                    b.Property<int>("PersonId");

                    b.Property<int>("SemesterId");

                    b.Property<bool>("Tutoring");

                    b.HasKey("ID");

                    b.HasIndex("PersonId");

                    b.HasIndex("SemesterId");

                    b.ToTable("SignIns");
                });

            modelBuilder.Entity("TutorPrototype.Models.SignInCourses", b =>
                {
                    b.Property<int>("SignInID");

                    b.Property<int>("CourseID");

                    b.HasKey("SignInID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("SignInCourses");
                });

            modelBuilder.Entity("TutorPrototype.Models.SignInReason", b =>
                {
                    b.Property<int>("SignInID");

                    b.Property<int>("ReasonID");

                    b.HasKey("SignInID", "ReasonID");

                    b.HasIndex("ReasonID");

                    b.ToTable("SignInReasons");
                });

            modelBuilder.Entity("TutorPrototype.Models.Course", b =>
                {
                    b.HasOne("TutorPrototype.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TutorPrototype.Models.SignIn", b =>
                {
                    b.HasOne("TutorPrototype.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TutorPrototype.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TutorPrototype.Models.SignInCourses", b =>
                {
                    b.HasOne("TutorPrototype.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TutorPrototype.Models.SignIn", "SignIn")
                        .WithMany("Courses")
                        .HasForeignKey("SignInID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TutorPrototype.Models.SignInReason", b =>
                {
                    b.HasOne("TutorPrototype.Models.Reason", "Reason")
                        .WithMany()
                        .HasForeignKey("ReasonID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TutorPrototype.Models.SignIn", "SignIn")
                        .WithMany("Reasons")
                        .HasForeignKey("SignInID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
