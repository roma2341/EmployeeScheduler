using Combinatorial;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib;

namespace MainProg
{
    class Program
    {
        static void Main(string[] args)
        {
            const int GROUPS_COUNT = 3;
            string[] DAY_JOBS = new string[] { "engeener", "doctor", "driver" };
            Employee e1 = new Employee(0);
            e1.Professions.AddRange(new string[] { "doctor", "driver" });
            Employee e2 = new Employee(1);
            e2.Professions.AddRange(new string[] { "doctor", "engeener" });
            Employee e3 = new Employee(2);
            e3.Professions.AddRange(new string[] { "driver", "doctor" });
            Employee e4 = new Employee(3);
            e4.Professions.AddRange(new string[] { "doctor", "driver" });
            Employee e5 = new Employee(4);
            e5.Professions.AddRange(new string[] { "doctor", "driver" });
            Employee e6 = new Employee(5);
            e6.Professions.AddRange(new string[] { "doctor", "driver"});
            List<Employee> employees = new List<Employee>();
            employees.Add(e1);
            while (true)
            {

            }
            string[] demandedProfArr = new string[] { "driver", "doctor"};
            List<String> demandedProfessionsList = new List<String>();
            demandedProfessionsList.AddRange(demandedProfArr);
            EmployeeScheduler EmpScheduler = new EmployeeScheduler(2,2,employees, demandedProfessionsList);
            EmpScheduler.divideUsersInGroups();
            Console.Write(EmpScheduler);

            Console.ReadKey(true);
        }
    }
  

}
