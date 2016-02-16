using Combinatorial;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeScheduler
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
            employees.Add(e2);
            employees.Add(e3);
            employees.Add(e4);
            employees.Add(e5);
            employees.Add(e6);
            string[] demandedProfArr = new string[] { "driver", "doctor"};
            List<String> demandedProfessionsList = new List<String>();
            demandedProfessionsList.AddRange(demandedProfArr);
            EmployeeScheduler EmpScheduler = new EmployeeScheduler(2,2,employees, demandedProfessionsList);
            EmpScheduler.divideUsersInGroups();
            Console.Write(EmpScheduler);

            Console.ReadKey(true);
        }
    }
     class Employee
    {
        static int usersCount = 0;
        public List<String> Professions { get; set; }
        public string CurrentProfession { get; set; }
        public long id { get; set; }
        public string Name { get; set;  }
        public Employee(long id)
        {
            usersCount++;
            this.id = id;
            Name = "Employee#"+id;
            Professions = new List<String>();
        }
        public bool hasProfession(String profession)
        {
            if (profession != null && Professions.Contains(profession)) return true;
            else return false;
        }
        public bool hasProfession(List<String> professions)
        {
            foreach(String profession in professions)
            if (profession != null && Professions.Contains(profession)) return true;
            return false;
        }

    }
    class EmployeeGroup
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
    class EmployeeScheduler
    {
       
        private int groupSize = 0;
        private List<EmployeeGroup> groups;
        private List<String> groupProffesionsDemanded = new List<String>();

        private  Dictionary<string, int> professionsStatistic = new Dictionary<string, int>();
        private List<Employee> availableEmployees = new List<Employee>();
        private List<Employee> busyEmployees = new List<Employee>();
        //professionsDemand - перелік професій для різних груп однаковий. 
        public EmployeeScheduler(int groupCount,int groupSize,List<Employee> initialEmployees,List<String> professionsDemand)
        {
            this.availableEmployees = initialEmployees;
            this.groups = new List<EmployeeGroup>();
            for (int i = 0; i < groupCount; i++)
                this.groups.Add(new EmployeeGroup());
            this.groupSize = groupSize;
            this.groupProffesionsDemanded = professionsDemand;
        }
        public override string ToString()
        {
            string result = "";
            int groupIndex = 0;
            foreach(EmployeeGroup group in groups)
            {
                result += "group[" + groupIndex + "]={";
                foreach (Employee employee in group.getEmployees())
                {
                    result += employee.Name +"-"+ employee.CurrentProfession+" ";
                }
                result += "}\n";
                groupIndex++;
            }
            return result;
        }
        private void updateProfessionsStatistic()
        {
            professionsStatistic.Clear();
            foreach (Employee employee in availableEmployees)
            {
                List<String> employeeProffesions = employee.Professions;
                foreach (String prof in employeeProffesions)
                {
                    if (!professionsStatistic.ContainsKey(prof)) professionsStatistic[prof] = 0;
                    professionsStatistic[prof]++;
                }
            }
        }
       public void divideUsersInGroups()
        {
            for (int i = 0; i < groups.Count(); i++)
            {
                EmployeeGroup currentGroup = groups[i];
                foreach (String demandedProfession in groupProffesionsDemanded)
                {
                    if (currentGroup.getEmployees().Count == groupSize) break;
                    for (int j = 0; j < availableEmployees.Count(); j++)
                    {
                        Employee curEmpl = availableEmployees[j];
                        updateProfessionsStatistic();
                        if (curEmpl.hasProfession(demandedProfession) && !(curEmpl.hasProfession(getRarityProffesions())))
                        {
                            assignEmployeeToGroup(curEmpl, currentGroup, demandedProfession);
                            break;
                        }
                       
                    }
                    availableEmployees = availableEmployees.Except(busyEmployees).ToList();
                }
            }

        }
        void assignEmployeeToGroup(Employee employee, EmployeeGroup group,String profession)
        {
            employee.CurrentProfession = profession;
            group.addEmployee(employee);
            busyEmployees.Add(employee);  
        }
        public List<string> getRarityProffesions()
        {
            int rarityValue = int.MaxValue;//Чим менше значення - тим рідша професія 
            List<string> rarityProfessionNames = new List<string>();
            foreach (string professionName in professionsStatistic.Keys)
            {
                int currentProfessionRarity = professionsStatistic[professionName];
                if (currentProfessionRarity < rarityValue)
                { 
                    rarityProfessionNames.Clear();
                    rarityValue = currentProfessionRarity;
                    rarityProfessionNames.Add(professionName);
                }
            }
            return rarityProfessionNames;
        }
        public List<string> getCommonProffesions()
        {
            int commonValue = int.MinValue;//Чим менше значення - тим рідша професія 
            List<string> commonProfessionNames = new List<string>();
            foreach (string professionName in professionsStatistic.Keys)
            {
                int currentProfessionRarity = professionsStatistic[professionName];
                if (currentProfessionRarity > commonValue)
                {
                    commonProfessionNames.Clear();
                    commonValue = currentProfessionRarity;
                    commonProfessionNames.Add(professionName);
                }
            }
            return commonProfessionNames;
        }

    }
}
