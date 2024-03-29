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
            await repo.HandleConcurrencyInEF();

            Console.Read();
        }
    }
}
