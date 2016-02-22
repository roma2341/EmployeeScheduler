using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    public class Employee
    {
        static int usersCount = 0;
        public List<String> Professions { get; set; }
        public string CurrentProfession { get; set; }
        public long id { get; set; }
        public string Name { get; set; }
        public Employee(long id)
        {
            usersCount++;
            this.id = id;
            Name = "Employee#" + id;
            Professions = new List<String>();
        }
        public bool hasProfession(String profession)
        {
            if (profession != null && Professions.Contains(profession, StringComparer.OrdinalIgnoreCase)) return true;
            else return false;
        }
        public bool hasExtraProfession(string profession)
        {
            if (profession != null && CurrentProfession!=profession && Professions.Contains(profession, StringComparer.OrdinalIgnoreCase)) return true;
            else return false;
        }
        public bool hasProfession(List<String> professions)
        {
            foreach (String profession in professions)
                if (profession != null && Professions.Contains(profession, StringComparer.OrdinalIgnoreCase)) return true;
            return false;
        }

    }
}
