using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorPrototype.Models.ViewModels;

namespace TutorPrototype.Repos.Interfaces
{
    public interface IVisitsRepo
    {
        Task<List<WeeklyVisitViewModel>> WeeklyVisits(DateTime startWeek, DateTime endWeek);
    }
}
