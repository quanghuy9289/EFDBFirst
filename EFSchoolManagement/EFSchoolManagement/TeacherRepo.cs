using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolManagement
{
    public class TeacherRepo
    {
        public void AddNewTeacher()
        {
            using (var context = new SchoolDBEntities())
            {
                Teacher teacher = new Teacher();
                teacher.TeacherName = "Nguyen Van A";
                teacher.TeacherType = TeacherType.Permanent;

                context.Teachers.Add(teacher);
                context.SaveChanges();
            }
        }
    }
}
