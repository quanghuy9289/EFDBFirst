using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSchoolManagement
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbConnection con, bool contextOwnsConnection) : base(con, contextOwnsConnection)
        {

        }
        public SchoolContext() : base("SchoolDB")
        {
            Database.SetInitializer<SchoolContext>(new CreateDatabaseIfNotExists<SchoolContext>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Grades { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
