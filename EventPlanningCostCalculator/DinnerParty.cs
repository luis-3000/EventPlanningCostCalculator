﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanningCostCalculator
{
    class DinnerParty
    {
        public const int CostOfFoodPerPerson = 25;

        public int NumberOfPeople { get; set; }

        public bool FancyDecorations { get; set; }

        public bool HealthyOption { get; set; }


        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations) {
            this.NumberOfPeople = numberOfPeople;
            this.HealthyOption = healthyOption;
            this.FancyDecorations = fancyDecorations;
        }

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
