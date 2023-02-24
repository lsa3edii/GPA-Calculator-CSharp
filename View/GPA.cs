using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPACalculator.Controller;

namespace GPACalculator.View
{
    public partial class GPA : Form
    {
        int hours2, hours3, hoursProject, fail2, fail3, failProject;
        GPA_Equation equation = new GPA_Equation();

        public GPA()
        {
            InitializeComponent();
            setSelectedFirstIndex();
            setSelectionButtons();
            setDisableButtons();
        }

        void setPreviousData()
        {
            try
            {
                equation.data.PreviousGPA = Convert.ToDouble(previousGPA.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input for 'Previous GPA' is Wrong!\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                previousGPA.Text = "0.0";
            }

            try
            {
                equation.data.PreviousCompletedHours = int.Parse(previousCompletedHours.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input for 'Previous Completed Hours' is Wrong!\n" + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                previousCompletedHours.Text = "0";
            }
        }
        void setCurrentData()
        {
            currentTermGPA.Text = "" + (Math.Round(equation.calculateTermGPA() * 1000) / 1000.0);
            cumulativeGPA.Text = "" + (Math.Round(equation.calculateCumulativeGPA() * 1000) / 1000.0);
            hours.Text = "" + (int.Parse(previousCompletedHours.Text) + hours2 + hours3 + hoursProject
                    - (fail2 + fail3 + failProject));
        }
        private void setSelectedFirstIndex()
        {
            grade1.SelectedIndex = 0;
            grade2.SelectedIndex = 0;
            grade3.SelectedIndex = 0;
            grade4.SelectedIndex = 0;
            grade5.SelectedIndex = 0;
            grade6.SelectedIndex = 0;

            projectGrade.SelectedIndex = 0;
        }
        private void setSelectionButtons()
        {
            sub1_button2.Select(); sub2_button2.Select(); sub3_button2.Select();
            sub4_button2.Select(); sub5_button2.Select(); sub6_button2.Select();

            project_button.Select();
        }
        private void setDisableButtons()
        {
            grade1.Enabled = false; sub1_button1.Enabled = false; sub1_button2.Enabled = false;
            grade2.Enabled = false; sub2_button1.Enabled = false; sub2_button2.Enabled = false;
            grade3.Enabled = false; sub3_button1.Enabled = false; sub3_button2.Enabled = false;
            grade4.Enabled = false; sub4_button1.Enabled = false; sub4_button2.Enabled = false;
            grade5.Enabled = false; sub5_button1.Enabled = false; sub5_button2.Enabled = false;
            grade6.Enabled = false; sub6_button1.Enabled = false; sub6_button2.Enabled = false;

            subjectGPA1.Enabled = false; text1.Enabled = false;
            subjectGPA2.Enabled = false; text2.Enabled = false;
            subjectGPA3.Enabled = false; text3.Enabled = false;
            subjectGPA4.Enabled = false; text4.Enabled = false;
            subjectGPA5.Enabled = false; text5.Enabled = false;
            subjectGPA6.Enabled = false; text6.Enabled = false;

            projectGrade.Enabled = false; project_button.Enabled = false;
            projectGPA.Enabled = false; projectText.Enabled = false;
        }
        private void removeData()
        {
            hours2 = 0; hours3 = 0; fail2 = 0; fail3 = 0;
            hoursProject = 0; failProject = 0;

            equation.subject.setGPA1_hour2(0); equation.subject.setGPA2_hour2(0); equation.subject.setGPA3_hour2(0);
            equation.subject.setGPA4_hour2(0); equation.subject.setGPA5_hour2(0); equation.subject.setGPA6_hour2(0);

            equation.subject.setGPA1_hour3(0); equation.subject.setGPA2_hour3(0); equation.subject.setGPA3_hour3(0);
            equation.subject.setGPA4_hour3(0); equation.subject.setGPA5_hour3(0); equation.subject.setGPA6_hour3(0);

            equation.subject.setProjectGPA_hour6(0);
        }

        private void subject1_CheckedChanged(object sender, EventArgs e)
        {
            if(subject1.Checked)
            {
                grade1.Enabled = true; sub1_button1.Enabled = true; sub1_button2.Enabled = true;
                subjectGPA1.Enabled = true; text1.Enabled = true;
            }
            else
            {
                grade1.Enabled = false; sub1_button1.Enabled = false; sub1_button2.Enabled = false;
                subjectGPA1.Enabled = false; text1.Enabled = false;
            }
        }

        private void subject2_CheckedChanged(object sender, EventArgs e)
        {
            if (subject2.Checked)
            {
                grade2.Enabled = true; sub2_button1.Enabled = true; sub2_button2.Enabled = true;
                subjectGPA2.Enabled = true; text2.Enabled = true;
            }
            else
            {
                grade2.Enabled = false; sub2_button1.Enabled = false; sub2_button2.Enabled = false;
                subjectGPA2.Enabled = false; text2.Enabled = false;
            }
        }

        private void subject3_CheckedChanged(object sender, EventArgs e)
        {
            if (subject3.Checked)
            {
                grade3.Enabled = true; sub3_button1.Enabled = true; sub3_button2.Enabled = true;
                subjectGPA3.Enabled = true; text3.Enabled = true;
            }
            else
            {
                grade3.Enabled = false; sub3_button1.Enabled = false; sub3_button2.Enabled = false;
                subjectGPA3.Enabled = false; text3.Enabled = false;
            }
        }

        private void subject4_CheckedChanged(object sender, EventArgs e)
        {
            if (subject4.Checked)
            {
                grade4.Enabled = true; sub4_button1.Enabled = true; sub4_button2.Enabled = true;
                subjectGPA4.Enabled = true; text4.Enabled = true;
            }
            else
            {
                grade4.Enabled = false; sub4_button1.Enabled = false; sub4_button2.Enabled = false;
                subjectGPA4.Enabled = false; text4.Enabled = false;
            }
        }

        private void subject5_CheckedChanged(object sender, EventArgs e)
        {
            if (subject5.Checked)
            {
                grade5.Enabled = true; sub5_button1.Enabled = true; sub5_button2.Enabled = true;
                subjectGPA5.Enabled = true; text5.Enabled = true;
            }
            else
            {
                grade5.Enabled = false; sub5_button1.Enabled = false; sub5_button2.Enabled = false;
                subjectGPA5.Enabled = false; text5.Enabled = false;
            }
        }

        private void subject6_CheckedChanged(object sender, EventArgs e)
        {
            if (subject6.Checked)
            {
                grade6.Enabled = true; sub6_button1.Enabled = true; sub6_button2.Enabled = true;
                subjectGPA6.Enabled = true; text6.Enabled = true;
            }
            else
            {
                grade6.Enabled = false; sub6_button1.Enabled = false; sub6_button2.Enabled = false;
                subjectGPA6.Enabled = false; text6.Enabled = false;
            }
        }

        private void selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(selectAll.Checked)
            {
                subject1.Checked = true; subject2.Checked = true; subject3.Checked = true;
                subject4.Checked = true; subject5.Checked = true; subject6.Checked = true;
            }
            else
            {
                subject1.Checked = false; subject2.Checked = false; subject3.Checked = false;
                subject4.Checked = false; subject5.Checked = false; subject6.Checked = false;
            }
        }

        private void graduationProject_CheckedChanged(object sender, EventArgs e)
        {
            if (graduationProject.Checked)
            {
                projectGrade.Enabled = true; project_button.Enabled = true;
                projectGPA.Enabled = true; projectText.Enabled = true;
            }
            else
            {
                projectGrade.Enabled = false; project_button.Enabled = false;
                projectGPA.Enabled = false; projectText.Enabled = false;
            }
        }

        private void grade1_SelectedIndexChanged(object sender, EventArgs e)
        {
            equation.gradeType(grade1.SelectedItem.ToString());
            subjectGPA1.Text = equation.subject.SubjectGPA.ToString();
        }

        private void grade2_SelectedIndexChanged(object sender, EventArgs e)
        {
            equation.gradeType(grade2.SelectedItem.ToString());
            subjectGPA2.Text = equation.subject.SubjectGPA.ToString();
        }

        private void grade3_SelectedIndexChanged(object sender, EventArgs e)
        {
            equation.gradeType(grade3.SelectedItem.ToString());
            subjectGPA3.Text = equation.subject.SubjectGPA.ToString();
        }

        private void grade4_SelectedIndexChanged(object sender, EventArgs e)
        {
            equation.gradeType(grade4.SelectedItem.ToString());
            subjectGPA4.Text = equation.subject.SubjectGPA.ToString();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void grade5_SelectedIndexChanged(object sender, EventArgs e)
        {
            equation.gradeType(grade5.SelectedItem.ToString());
            subjectGPA5.Text = equation.subject.SubjectGPA.ToString();
        }

        private void grade6_SelectedIndexChanged(object sender, EventArgs e)
        {
            equation.gradeType(grade6.SelectedItem.ToString());
            subjectGPA6.Text = equation.subject.SubjectGPA.ToString();
        }

        private void projectGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            equation.gradeType(projectGrade.SelectedItem.ToString());
            projectGPA.Text = equation.subject.SubjectGPA.ToString();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            setPreviousData();

            if (Double.Parse(previousGPA.Text) > 4.0)
                MessageBox.Show("Previous GPA → " + previousGPA.Text + "  ,Must be Less than or Equal to ' 4 '", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            else if (subject1.Checked == false && subject2.Checked == false && subject3.Checked == false
                && subject4.Checked == false && subject5.Checked == false && subject6.Checked == false
                && !graduationProject.Checked)
                    MessageBox.Show("Please Complete your Information!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
            {
                if (!previousGPA.Text.Equals("") && !previousCompletedHours.Text.Equals("")
                && (!previousGPA.Text.Equals("") || !previousCompletedHours.Text.Equals("")))
                {

                    if (subject1.Checked && !grade1.SelectedItem.Equals("Grade"))
                    {
                        if (sub1_button1.Checked)
                        {
                            equation.subject.setGPA1_hour2(Double.Parse(subjectGPA1.Text));
                            hours2 = hours2 + 2;
                        }
                        else
                        {
                            equation.subject.setGPA1_hour3(Double.Parse(subjectGPA1.Text));
                            hours3 = hours3 + 3;
                        }

                        if (grade1.SelectedItem.Equals("F") && sub1_button1.Checked)
                            fail2 = fail2 + 2;

                        else if (grade1.SelectedItem.Equals("F"))
                            fail3 = fail3 + 3;
                    }

                    if (subject2.Checked && !grade2.SelectedItem.Equals("Grade"))
                    {
                        if (sub2_button1.Checked)
                        {
                            equation.subject.setGPA2_hour2(Double.Parse(subjectGPA2.Text));
                            hours2 = hours2 + 2;
                        }
                        else
                        {
                            equation.subject.setGPA2_hour3(Double.Parse(subjectGPA2.Text));
                            hours3 = hours3 + 3;
                        }

                        if (grade2.SelectedItem.Equals("F") && sub2_button1.Checked)
                            fail2 = fail2 + 2;

                        else if (grade2.SelectedItem.Equals("F"))
                            fail3 = fail3 + 3;
                    }

                    if (subject3.Checked && !grade3.SelectedItem.Equals("Grade"))
                    {
                        if (sub3_button1.Checked)
                        {
                            equation.subject.setGPA3_hour2(Double.Parse(subjectGPA3.Text));
                            hours2 = hours2 + 2;
                        }
                        else
                        {
                            equation.subject.setGPA3_hour3(Double.Parse(subjectGPA3.Text));
                            hours3 = hours3 + 3;
                        }

                        if (grade3.SelectedItem.Equals("F") && sub3_button1.Checked)
                            fail2 = fail2 + 2;

                        else if (grade3.SelectedItem.Equals("F"))
                            fail3 = fail3 + 3;
                    }

                    if (subject4.Checked && !grade4.SelectedItem.Equals("Grade"))
                    {
                        if (sub4_button1.Checked)
                        {
                            equation.subject.setGPA4_hour2(Double.Parse(subjectGPA4.Text));
                            hours2 = hours2 + 2;
                        }
                        else
                        {
                            equation.subject.setGPA4_hour3(Double.Parse(subjectGPA4.Text));
                            hours3 = hours3 + 3;
                        }

                        if (grade4.SelectedItem.Equals("F") && sub4_button1.Checked)
                            fail2 = fail2 + 2;

                        else if (grade4.SelectedItem.Equals("F"))
                            fail3 = fail3 + 3;
                    }

                    if (subject5.Checked && !grade5.SelectedItem.Equals("Grade"))
                    {
                        if (sub5_button1.Checked)
                        {
                            equation.subject.setGPA5_hour2(Double.Parse(subjectGPA5.Text));
                            hours2 = hours2 + 2;
                        }
                        else
                        {
                            equation.subject.setGPA5_hour3(Double.Parse(subjectGPA5.Text));
                            hours3 = hours3 + 3;
                        }

                        if (grade5.SelectedItem.Equals("F") && sub5_button1.Checked)
                            fail2 = fail2 + 2;

                        else if (grade5.SelectedItem.Equals("F"))
                            fail3 = fail3 + 3;
                    }

                    if (subject6.Checked && !grade6.SelectedItem.Equals("Grade"))
                    {
                        if (sub6_button1.Checked)
                        {
                            equation.subject.setGPA6_hour2(Double.Parse(subjectGPA6.Text));
                            hours2 = hours2 + 2;
                        }
                        else
                        {
                            equation.subject.setGPA6_hour3(Double.Parse(subjectGPA6.Text));
                            hours3 = hours3 + 3;
                        }

                        if (grade6.SelectedItem.Equals("F") && sub6_button1.Checked)
                            fail2 = fail2 + 2;

                        else if (grade6.SelectedItem.Equals("F"))
                            fail3 = fail3 + 3;
                    }

                    if (graduationProject.Checked && !projectGrade.SelectedItem.Equals("Grade"))
                    {

                        if (project_button.Checked)
                        {
                            equation.subject.setProjectGPA_hour6(Double.Parse(projectGPA.Text));
                            hoursProject = 6;
                        }

                        if (projectGrade.SelectedItem.Equals("F"))
                            failProject = 6;
                    }

                }
            }

            equation.data.TermHours = hours2 + hours3 + hoursProject;

            setCurrentData();
            removeData();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
