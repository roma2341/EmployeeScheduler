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
        private EmployeeScheduler scheduler;
        public EmployeeGroup(EmployeeScheduler scheduler)
        {
            this.scheduler = scheduler;
            employeeList = new List<Employee>();
        }
        public void addEmployee(Employee employee)
        {
            scheduler.BusyEmployees.Add(employee);
            scheduler.AvailableEmployees.Remove(employee);
            employeeList.Add(employee);
        }
        public List<Employee> getEmployees()
        {
            return employeeList;
        }
        public void freeEmployee(Employee employee)
        {
            if (employee == null) return;
            scheduler.AvailableEmployees.Add(employee);
            scheduler.BusyEmployees.Remove(employee);
            employeeList.Remove(employee);
        }
    }
}
