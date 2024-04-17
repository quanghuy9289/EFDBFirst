using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolManagement
{
    class SQLLogger
    {
        public static void DbCommandLogging()
        {
            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Logger.Log; // dung Log delegate de log transact SQL query

                var student = context.Students.FirstOrDefault(s => s.StudentName == "St1");
                if (student != null)
                {
                    student.StudentName = "Edited name";
                    context.SaveChanges();
                }    
            }
        }

        public static void DbCommandLogging_ToConsole()
        {
            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.WriteLine; // dung console.writeLine delegate de log transact SQL query

                var student = context.Students.FirstOrDefault(s => s.StudentName == "Tim");
                if (student != null)
                {
                    student.StudentName = "Edited name";
                    context.SaveChanges();
                }
            }
        }
    }

    public class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine("EF message: {0}", message);
        }
    }
}
