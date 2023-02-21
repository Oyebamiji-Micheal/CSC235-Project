using CSCResult.Models;
using CSCResult.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSCResult.Services.Interfaces
{
    public interface ICourseService
    {
        Task<bool> AddOrUpdateCourse(StudentCoursesModel studentCoursesModel);
        Task<bool> DeleteCourse(string key);
        Task<List<StudentCoursesModel>> GetAllCourses();
    }
}
