using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorPrototype.Models.ViewModels;

namespace TutorPrototype.Repos
{
    public class ProdSignInRepo : SignInRepo
    {
        public override StudentInfoViewModel GetStudentInfoWithEmail(string studentEmail)
        {
            throw new NotImplementedException();
        }

        public override StudentInfoViewModel GetStudentInfoWithID(int studentID)
        {
            throw new NotImplementedException();
        }
    }
}
