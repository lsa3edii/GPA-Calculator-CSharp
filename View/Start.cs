using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPACalculator.View
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
            circularBar.Value = 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            circularBar.Value += 2;
            circularBar.Text = circularBar.Value.ToString() + "%";

            if (circularBar.Value == 100)
            {
                timer.Enabled = false;
                this.Visible = false;
                new GPA().Show();
            }
        }

    }
}
