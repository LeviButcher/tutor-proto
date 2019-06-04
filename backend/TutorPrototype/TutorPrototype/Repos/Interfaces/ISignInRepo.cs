using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorPrototype.Models;
using TutorPrototype.Models.ViewModels;

namespace TutorPrototype.Repos.Interfaces
{
    public interface ISignInRepo
    {
        int CreateSignIn(SignIn signIn, List<Course> courses, List<Reason> reasons);

        int UpdateSignIn(SignIn signIn);

        bool SignInExists(int id);

        Task<SignInViewModel> GetSignIn(int id);

        StudentInfoViewModel  GetStudentInfoWithID(int studentID);

        StudentInfoViewModel GetStudentInfoWithEmail(string studentEmail); 

    }
}
