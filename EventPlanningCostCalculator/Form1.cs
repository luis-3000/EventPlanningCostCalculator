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

        public Form1()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty() { NumberOfPeople = 5 };
            dinnerParty.SetHealthyOption(false);
            dinnerParty.CalculateCostOfDecorations(fancyBox.Checked);
            dinnerParty.SetHealthyOption(healthyBox.Checked);
            DisplayDinnerPartyCost();
        }


        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
         
        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.CalculateCost(healthyBox.Checked);
            costLabel.Text = Cost.ToString("c"); // 'c' tells it to format the cost as a currency value
        }

        /* Hooking up this field to the NumberOfPeople variable created in the DinnerParty class
         * and display the cost in the form. */
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dinnerParty.NumberOfPeople = (int)numericUpDown1.Value; // Needs to be cast as an 'int' since it's a Decimal property
            DisplayDinnerPartyCost(); // display cost anytime the number changes or the checkboxes are checked
                                        // This method calls the CalculateCost() method, but not the CalculateCostOfDecorations() method.
        }

        /* Changes to the checkboxes on the form set the healthyOption and fancy booleans to true or false
          in the SetHealthyOption() and CalculateCostOfDecorations() methods. */
        private void fancyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.CalculateCostOfDecorations(fancyBox.Checked);
            DisplayDinnerPartyCost(); 
        }


        private void healthyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.SetHealthyOption(healthyBox.Checked);
            DisplayDinnerPartyCost();
        }

    }
}
