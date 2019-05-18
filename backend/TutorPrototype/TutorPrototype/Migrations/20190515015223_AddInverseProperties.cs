using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorPrototype.Migrations
{
    public partial class AddInverseProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_SignInReasons_ReasonID_SignInID",
                table: "SignInReasons");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_SignInCourses_CourseID_SignInID",
                table: "SignInCourses");

            migrationBuilder.CreateIndex(
                name: "IX_SignIns_PersonId",
                table: "SignIns",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SignIns_SemesterId",
                table: "SignIns",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SignInReasons_ReasonID",
                table: "SignInReasons",
                column: "ReasonID");

            migrationBuilder.CreateIndex(
                name: "IX_SignInCourses_CourseID",
                table: "SignInCourses",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SignInCourses_Courses_CourseID",
                table: "SignInCourses",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CRN",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SignInCourses_SignIns_SignInID",
                table: "SignInCourses",
                column: "SignInID",
                principalTable: "SignIns",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SignInReasons_Reasons_ReasonID",
                table: "SignInReasons",
                column: "ReasonID",
                principalTable: "Reasons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SignInReasons_SignIns_SignInID",
                table: "SignInReasons",
                column: "SignInID",
                principalTable: "SignIns",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SignIns_People_PersonId",
                table: "SignIns",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SignIns_Semesters_SemesterId",
                table: "SignIns",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_SignInCourses_Courses_CourseID",
                table: "SignInCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SignInCourses_SignIns_SignInID",
                table: "SignInCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SignInReasons_Reasons_ReasonID",
                table: "SignInReasons");

            migrationBuilder.DropForeignKey(
                name: "FK_SignInReasons_SignIns_SignInID",
                table: "SignInReasons");

            migrationBuilder.DropForeignKey(
                name: "FK_SignIns_People_PersonId",
                table: "SignIns");

            migrationBuilder.DropForeignKey(
                name: "FK_SignIns_Semesters_SemesterId",
                table: "SignIns");

            migrationBuilder.DropIndex(
                name: "IX_SignIns_PersonId",
                table: "SignIns");

            migrationBuilder.DropIndex(
                name: "IX_SignIns_SemesterId",
                table: "SignIns");

            migrationBuilder.DropIndex(
                name: "IX_SignInReasons_ReasonID",
                table: "SignInReasons");

            migrationBuilder.DropIndex(
                name: "IX_SignInCourses_CourseID",
                table: "SignInCourses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SignInReasons_ReasonID_SignInID",
                table: "SignInReasons",
                columns: new[] { "ReasonID", "SignInID" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_SignInCourses_CourseID_SignInID",
                table: "SignInCourses",
                columns: new[] { "CourseID", "SignInID" });
        }
    }
}
