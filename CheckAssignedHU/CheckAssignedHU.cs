using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using System.Diagnostics;
using System.Threading;


namespace VMS.TPS
{
    public class Script
    {
        public void Execute(ScriptContext context)
        {
            // Your code here.
            run(context.IonPlanSetup, context.Patient, context.Course);
        }
        public void run(IonPlanSetup plan, Patient patient, Course kurs)
        {
            List<Structure> Strukturer = plan.StructureSet.Structures.ToList();
            List<string> strOut = new List<string>();
            double HUvalue;

            foreach (Structure m_strukt in Strukturer)
            {
                bool ok = false;
                ok = m_strukt.GetAssignedHU(out HUvalue);
                if (ok)
                {
                    strOut.Add("Strukturen: " + m_strukt.Id + " Har ett ansatt HU värde på: " + HUvalue);
                }
            }
            string result = string.Join("\n", strOut);
            MessageBox.Show(result);
        }
    }
}
