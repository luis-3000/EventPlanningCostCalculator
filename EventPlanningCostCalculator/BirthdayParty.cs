using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanningCostCalculator
{
    class BirthdayParty
    {
        public const int CostOfFoodPerPerson = 25;

        public int NumberOfPeople { get; set; }

        public bool FancyDecorations { get; set; }

        public string CakeWriting { get; set; }

        /* The constructor sets up the object's state by setting the properties so that it can calculate
         * the cost later.*/
        public BirthdayParty(int numberOfPeople, bool fanceDecorations, string cakeWriting)
        {
            this.NumberOfPeople = numberOfPeople;
            this.FancyDecorations = fanceDecorations;
            this.CakeWriting = cakeWriting;
        }
    }
}
