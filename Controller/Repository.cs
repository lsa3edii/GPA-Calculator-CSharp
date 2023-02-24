using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPACalculator.Model;

namespace GPACalculator.Controller
{
    public interface Repository
    {
        double calculateTermGPA();
        double calculateCumulativeGPA();
        void gradeType(String grade);
    }
}
