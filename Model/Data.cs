using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculator.Model
{
    public class Data
    {
        private double previousGPA;
        private int previousCompletedHours;
        private int termHours;

        public Data() 
        {

        }

        public double PreviousGPA
        {
            get { return this.previousGPA; }
            set { this.previousGPA = value; }
        }

        public int PreviousCompletedHours
        {
            get { return this.previousCompletedHours; }
            set { this.previousCompletedHours = value; }
        }

        public int TermHours
        {
            get { return this.termHours; }
            set { this.termHours = value; }
        }

    }
}
