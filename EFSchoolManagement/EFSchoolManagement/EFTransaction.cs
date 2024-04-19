using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolManagement
{
    class EFTransaction
    {
        // BeginTransaction se tao ra 1 transaction noi bo va chi thuc thi cac lenh ben trong khi goi Commit
        // neu co loi xay ra se Rollback toan bo cac hanh dong
        public static void EFTransaction_BeginTransaction()
        {
            using (var context = new SchoolDBEntities())
            {
                context.Database.Log = Console.WriteLine;
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var standard = context.Standards.Add(new Standard { StandardName = "1st Grade" });
                        context.Students.Add(new Student()
                        {
                            StudentName = "Rama2",
                            StandardId = standard.StandardId
                        });

                        context.SaveChanges();

                        context.Courses.Add(new Course() { CourseName = "Computer Science" });

                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                }
            }
        }

        // UseTransaction se KO tao ra 1 transaction noi bo ma su dung 1 transaction ben ngoai duoc cung cap
        // neu co loi xay ra se Rollback toan bo cac hanh dong
        public static void EFTransaction_UseTransaction()
        {
            string serverName = ".";
            string databaseName = "SchoolDB";

            // Initialize the connection string builder for the SQL Server provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;

            using (SqlConnection con = new SqlConnection(sqlBuilder.ToString()))
            {
                con.Open();

                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SchoolContext context = new SchoolContext(con, false))
                        {
                            context.Database.UseTransaction(transaction);

                            context.Students.Add(new Student()
                            {
                                StudentName = "Ravi"
                            });

                            context.SaveChanges();
                        }

                        using (SchoolContext context = new SchoolContext(con, false))
                        {
                            context.Database.UseTransaction(transaction);

                            context.Grades.Add(new Standard()
                            {
                                StandardName = "Grade 1",
                                Description = "A"
                            });

                            context.SaveChanges();
                        }

                        // commit
                        transaction.Commit();
                        
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                    
                }
            }
        }
    }
}
