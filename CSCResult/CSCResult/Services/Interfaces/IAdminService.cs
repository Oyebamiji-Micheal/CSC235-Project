using CSCResult.Models;
using CSCResult.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSCResult.Services.Interfaces
{
    public interface IAdminService
    {
        Task<bool> UpdateScore(StudentCoursesModel studentCoursesModel);
        Task<List<StudentCoursesModel>> GetAllCourses();
        Task<bool> DeleteCourse(string key);
    }
}
