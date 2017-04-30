using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanningCostCalculator
{
    class DinnerParty
    {
        public const int CostOfFoodPerPerson = 25;

        // These properties are set in the constructor and updated by the form,
        // and they're used when calculating the cost.
        public int NumberOfPeople { get; set; }

        public bool FancyDecorations { get; set; }

        public bool HealthyOption { get; set; }

        /* The constructor sets the three properties based on the valued passed into it by the form. */
        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations) {
            this.NumberOfPeople = numberOfPeople;
            this.HealthyOption = healthyOption;
            this.FancyDecorations = fancyDecorations;
        }

        /* By making this method private, I make sure that it can't be accessed from outside
         * of the class, which will keep it from being misused. */
        private decimal CalculateCostOfDecorations() {
            
            decimal costOfDecorations = 0;
            
            if (FancyDecorations)
            {
                costOfDecorations = (15.00M * NumberOfPeople) + 50.0M;
            }
            else
            {
                costOfDecorations = (7.50M * NumberOfPeople) + 30.0M;  
            }

            return costOfDecorations;
        }

        /* The private methods used in the cost calculation such as this method, access the
         * properties so that they have the latest information from the form. */
        private decimal CalculateCostOfBeveragesPerPerson() {

            decimal costOfBeveragesPerPerson;
            
            if (HealthyOption)
            {
                costOfBeveragesPerPerson = 5.00M;
            }
            else
            {
                costOfBeveragesPerPerson = 20.00M;
            }

            return costOfBeveragesPerPerson;
        }

        /* Now that the calculations are private and encapsulated behind the Cost property, there's no way for 
         * the form to recalculate the cost of the decorations that doen't use the currently selected options.
         * This has fixed the bug that changed the costs incorrectly every time the options were changed. */
        public decimal Cost { 

            get {
                decimal totalCost = CalculateCostOfDecorations();
                totalCost +=   ( (CalculateCostOfBeveragesPerPerson() + CostOfFoodPerPerson) * NumberOfPeople );

                if (HealthyOption)
                {
                    // Apply the discount
                    totalCost *= 0.95M; // Apply the 5% discount to the overall event cost if the non-alcoholic option was chosen
                }

                return totalCost;
            }
            
        }

    }
}
