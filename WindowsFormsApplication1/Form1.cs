using EmployeeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<Employee> employees = new List<Employee>();
        List<string> demandedProfArr = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        public void updateEmployeesFromRtb()
        {
            employees.Clear();
            for (int index = 0; index < rtbEmployees.Lines.Length; index++)
            {
                string currentEmployeeString = rtbEmployees.Lines[index];
               string[] EmplData = currentEmployeeString.Split(' ');
                Employee empl = new Employee(index);
                for (int i = 0; i<EmplData.Length; i++)
                {
                    EmplData[i] = EmplData[i].Trim();
                }
                if (EmplData.Length < 1) return;
                empl.Name = EmplData[0];
                for (int i = 1; i< EmplData.Length; i++)
                {
                    empl.Professions.Add(EmplData[i]);
                }
                employees.Add(empl);


            }
        }
        public void updateProfessionsFromRtb()
        {
            demandedProfArr.Clear();
            for (int index = 0; index < rtbProfessionsDemand.Lines.Length; index++)
            {
                string currentProfString = rtbProfessionsDemand.Lines[index];
                currentProfString.Trim();
                demandedProfArr.Add(currentProfString);
            }
        }


        private void btnProcessGroups_Click_1(object sender, EventArgs e)
        {
            string groupCountStr = tbGroupCount.Text;
            string groupSizeStr = tbGroupSize.Text;
            int groupCount = 0;
            int groupSize = 0;
            try
            {
                groupCount = int.Parse(groupCountStr);
                groupSize = int.Parse(groupSizeStr);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Виключення для розміру груп");
                return;
            }
            updateEmployeesFromRtb();
            updateProfessionsFromRtb();
            EmployeeScheduler EmpScheduler = new EmployeeScheduler(groupCount, groupSize, employees, demandedProfArr);
            if (!EmpScheduler.divideUsersInGroups())
            {
                MessageBox.Show("Сукупність вхідних даних не дозволяє отримати бажаний результат ! Або я щось криво закодив =)");
            }
            rtbGroups.Text = EmpScheduler.ToString();
        }
    }
}
