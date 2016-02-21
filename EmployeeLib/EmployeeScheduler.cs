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

        public List<Employee> AvailableEmployees
        {
            get { return availableEmployees; }
            set { this.availableEmployees = value; }
        }
        public List<Employee> BusyEmployees
        {
            get { return busyEmployees; }
            set { this.busyEmployees = value; }
        }
        //professionsDemand - перелік професій для різних груп однаковий. 
        public EmployeeScheduler(int groupCount, int groupSize, List<Employee> initialEmployees, List<String> professionsDemand)
        {
            this.availableEmployees = initialEmployees;
            this.groups = new List<EmployeeGroup>();
            for (int i = 0; i < groupCount; i++)
                this.groups.Add(new EmployeeGroup(this));
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
        public void divideUsersInGroups_deprecated()
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
        public bool divideUsersInGroups()
        {
            for (int i = 0; i < groups.Count(); i++)
            {
                EmployeeGroup currentGroup = groups[i];
                foreach (String demandedProfession in groupProffesionsDemanded)
                {
                    if (currentGroup.getEmployees().Count == groupSize) break;
                   bool successful = reassignEmployeeToGroupWithReplacement(currentGroup, demandedProfession,0);
                    if (!successful) return false;
                   /* for (int j = 0; j < availableEmployees.Count(); j++)
                    {
                        Employee curEmpl = availableEmployees[j];
                        updateProfessionsStatistic();
                        if (curEmpl.hasProfession(demandedProfession) && !(curEmpl.hasProfession(getRarityProffesions())))
                        {
                            assignEmployeeToGroup(curEmpl, currentGroup, demandedProfession);
                            break;
                        }

                    }
                    availableEmployees = availableEmployees.Except(busyEmployees).ToList();*/
                }
            }
            return true;
        }
        /// <summary>
        /// Переміщення працівника в іншу групу, підставляючи на його місце вільного працівника, або рекурсивно працівника з іншої групи.
        /// </summary>
        /// <param name="proffesionName">Професія</param>
        /// <param name="recursionLevel">Для заборони нескінченної рекурсії</param>
        /// <returns></returns>
        public bool reassignEmployeeToGroupWithReplacement(EmployeeGroup destinationGroup,string proffesionName,int recursionLevel)
        {
            //Спочатку шукаємо робітника з потрібною професією в списку вільних працівників
           foreach(Employee employee in availableEmployees)
            {
                if (employee.hasProfession(proffesionName))
                {
                    employee.CurrentProfession = proffesionName;
                    destinationGroup.addEmployee(employee);
                    return true;
                }
                if (recursionLevel > 10) return false;
                for (int i = 0; i < groups.Count(); i++)
                {
                    for (int j = 0; j< groups[i].getEmployees().Count; j++)
                    {
                        EmployeeGroup currentGroup = groups[i];
                        Employee currentEmployee = currentGroup.getEmployees()[j];
                        if (currentEmployee.hasExtraProfession(proffesionName))
                        {
                            if (reassignEmployeeToGroupWithReplacement(currentGroup, currentEmployee.CurrentProfession, recursionLevel + 1))
                            {
                                currentGroup.freeEmployee(currentEmployee);//Робітник виходить з групи, бо на його місце став інший.
                                currentEmployee.CurrentProfession = proffesionName;//Поточною професією ставимо ту, яка нам потрібна щоб в нього була
                                destinationGroup.addEmployee(currentEmployee);
                            return true;
                            }
                        }
                    }
                }
            }
            return false;
           //Якщо вільного працівника з цією професією немає, то потрібно переназначити на цю професію компетентного працівника, в свою чергу
           // замінивши його на компетентного працівника з пулу (або так само  рекурсивно взяти з групи). Замутно короче.
        }
        void assignEmployeeToGroup(Employee employee, EmployeeGroup group, String profession)
        {
            employee.CurrentProfession = profession;
            group.addEmployee(employee);
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
