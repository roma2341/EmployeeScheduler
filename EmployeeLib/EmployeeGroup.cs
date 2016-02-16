using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
   public class EmployeeGroup
    {
        private List<Employee> employeeList;
        public EmployeeGroup()
        {
            employeeList = new List<Employee>();
        }
        public void addEmployee(Employee employee)
        {
            employeeList.Add(employee);
        }
        public List<Employee> getEmployees()
        {
            return employeeList;
        }
    }
}
