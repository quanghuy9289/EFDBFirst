using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolManagement
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            StudentRepo repo = new StudentRepo();
            //await repo.HandleConcurrencyInEF();

            //var courses = repo.GetCoursesByStudentId(1);
            //Console.WriteLine("Course of student: {0}", repo.GetStudentById(1).StudentName);
            //foreach(var course in courses)
            //{
            //    Console.WriteLine("CourseId: {0} - Course Name: {1}", course.CourseId, course.CourseName);
            //}

            //repo.CRUD_WithStoreProcedure();
            //repo.AddNewStudentWithValidation();
            //SQLLogger.DbCommandLogging();
            SQLLogger.DbCommandLogging_ToConsole();
            Console.Read();
        }
    }
}
