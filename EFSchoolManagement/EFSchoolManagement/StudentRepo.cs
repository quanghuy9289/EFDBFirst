using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace EFSchoolManagement
{
    class StudentRepo
    {
        public async Task<Student> GetStudentAsync()
        {
            Student st = null;

            using(var context = new SchoolDBEntities())
            {
                Console.WriteLine("Start GetStudent...");

                st = await context.Students.Where(x => x.StudentID == 1).FirstOrDefaultAsync();

                Console.WriteLine("Finish GetStudent...");
            }

            return st;
        }

        public async Task<int> SaveStudentAsync(Student student)
        {
            using (var context = new SchoolDBEntities())
            {
                context.Entry(student).State = EntityState.Modified;

                Console.WriteLine("Start SaveStudent...");

                int res = await context.SaveChangesAsync();

                Console.WriteLine("Finish SaveStudent...");

                return res;
            }
        }

        public void QueryAndSave()
        {
            var query = GetStudentAsync();

            Console.WriteLine("Do something else here till we get the query result..");

            query.Wait();

            Student st = query.Result;

            st.StudentName = "Steve";

            var numOfSavedStudent = SaveStudentAsync(st);

            Console.WriteLine("Do something else here till we save a student..");

            numOfSavedStudent.Wait();

            Console.WriteLine("Saved Entities: {0}", numOfSavedStudent.Result);
        }

        public async Task QueryAndSaveAsync()
        {
            Console.WriteLine("Do something else here till we get the query result..");
            var student = await GetStudentAsync();

            student.StudentName = "Steve 2";

            Console.WriteLine("Do something else here till we save a student..");

            var numOfSavedStudent = await SaveStudentAsync(student);
            Console.WriteLine("Saved Entities: {0}", numOfSavedStudent);
        }


        public async Task HandleConcurrencyInEF()
        {
            var st1 = await GetStudentAsync();
            var st2 = await GetStudentAsync();
            try
            {
                st1.StudentName = "St1";
                await SaveStudentAsync(st1);

                st2.StudentName = "St2";
                await SaveStudentAsync(st2);
            }
            catch(DbUpdateConcurrencyException ex)
            {
                Console.WriteLine("Concurrency Exception Occurred.");
                
                foreach (var entry in ex.Entries) // ex.Entries chua cac entities bi anh huong
                {
                    // entry.Entity là entity bị ảnh hưởng
                    // Bạn có thể làm gì đó với entity này, ví dụ:
                    var currentValues = entry.CurrentValues; // chứa giá trị của entity trong context khi SaveChanges() được gọi
                    var databaseValues = entry.GetDatabaseValues(); // chứa giá trị mới nhất từ cơ sở dữ liệu.

                    // TODO: Xử lý xung đột giữa currentValues và databaseValues
                    // Ví dụ: Cập nhật UI, thông báo cho người dùng, v.v.
                    Console.WriteLine("The saved entity is different with the original value: currentValues - {0}, databaseValues - {1}", currentValues, databaseValues);
                }
            }
        }
    }
}
