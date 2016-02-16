using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
   public class EmployeeScheduler
    {

        private int groupSize = 0;
        private List<EmployeeGroup> groups;
        private List<String> groupProffesionsDemanded = new List<String>();

        private Dictionary<string, int> professionsStatistic = new Dictionary<string, int>();
        private List<Employee> availableEmployees = new List<Employee>();
        private List<Employee> busyEmployees = new List<Employee>();
        //professionsDemand - перелік професій для різних груп однаковий. 
        public EmployeeScheduler(int groupCount, int groupSize, List<Employee> initialEmployees, List<String> professionsDemand)
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
            foreach (EmployeeGroup group in groups)
            {
                result += "group[" + groupIndex + "]={";
                foreach (Employee employee in group.getEmployees())
                {
                    result += employee.Name + "-" + employee.CurrentProfession + " ";
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
        void assignEmployeeToGroup(Employee employee, EmployeeGroup group, String profession)
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
