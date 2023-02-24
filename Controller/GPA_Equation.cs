using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using GPACalculator.Model;

namespace GPACalculator.Controller
{
    public class GPA_Equation
    {
        private double currentPoints;
        private double currentPoints1;
        private double currentPoints2;
        private double CurrentTermGPA;
        private double previousPoints;
        private double CumulativeGPA;
        private int totalHours;

        public Subjects subject = new Subjects();
        public Data data = new Data();

        public GPA_Equation()
        {
            //
        }

        public double pointsCounter()
        {
            currentPoints1 = 3 * (subject.getGPA1_hour3() + subject.getGPA2_hour3() + subject.getGPA3_hour3() + subject.getGPA4_hour3()
            + subject.getGPA5_hour3() + subject.getGPA6_hour3());
            currentPoints2 = 2 * (subject.getGPA1_hour2() + subject.getGPA2_hour2() + subject.getGPA3_hour2() + subject.getGPA4_hour2()
            + subject.getGPA5_hour2() + subject.getGPA6_hour2());
            currentPoints = currentPoints1 + currentPoints2 + (6 * subject.getProjectGPA_hour6());
            return currentPoints;
        }
        //@Override
        public double calculateTermGPA()
        {
            CurrentTermGPA = pointsCounter() / data.TermHours;
            return CurrentTermGPA;
        }

        //@Override
        public double calculateCumulativeGPA()
        {
            previousPoints = data.PreviousGPA * data.PreviousCompletedHours;
            totalHours = data.PreviousCompletedHours + data.TermHours;

            CumulativeGPA = (previousPoints + pointsCounter()) / totalHours;
            return CumulativeGPA;
        }

        //@Override
        public void gradeType(String grade)
        {
            switch (grade)
            {

                case "A+":
                    subject.SubjectGPA = 4;
                    break;

                case "A":
                    subject.SubjectGPA = 3.75;
                    break;

                case "B+":
                    subject.SubjectGPA = 3.4;
                    break;

                case "B":
                    subject.SubjectGPA = 3.1;
                    break;

                case "C+":
                    subject.SubjectGPA = 2.8;
                    break;

                case "C":
                    subject.SubjectGPA = 2.5;
                    break;

                case "D+":
                    subject.SubjectGPA = 2.25;
                    break;

                case "D":
                    subject.SubjectGPA = 2;
                    break;

                case "F":
                    subject.SubjectGPA = 1;
                    break;

                case "Grade":
                    subject.SubjectGPA = 0.0;
                    break;
            }

        }
    }
}
