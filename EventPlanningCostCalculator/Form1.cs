using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventPlanningCostCalculator
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;

        /* This new version allows the form to store an instance of DinnerParty and updates its properties
         * every time the number of people or party options change. */
        public Form1()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty((int)numericUpDown1.Value, healthyBox.Checked, fancyBox.Checked);
            DisplayDinnerPartyCost();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* Changes to the checkboxes on the form set the HealthyOption and FancyDecorations booleans to true or false.*/
        private void fancyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.FancyDecorations = fancyBox.Checked;
            DisplayDinnerPartyCost();
        }

        private void healthyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.HealthyOption = healthyBox.Checked;
            DisplayDinnerPartyCost();
        }

        /* Hooking up this field to the NumberOfPeople variable created in the DinnerParty class
         * and display the cost in the form. */
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dinnerParty.NumberOfPeople = (int)numericUpDown1.Value; // Needs to be cast as an 'int' since it's a Decimal property
            DisplayDinnerPartyCost(); // display cost anytime the number changes or the checkboxes are checked
        }

        /* This method now updates the dinner party cost on the form by acessing the Cost property EVERY TIME it updates the form. */
        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.Cost;
            costLabel.Text = Cost.ToString("c"); // 'c' tells it to format the cost as a currency value shown as dollar amounts
        }
    }
}
