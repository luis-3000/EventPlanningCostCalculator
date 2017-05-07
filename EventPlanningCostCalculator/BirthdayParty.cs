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

        /* A private property that calculates the actual length of the writing to use for the calculation. 
         * If the writing is too long for the cake, this property calculates the actual number of letters
         * that will fit on the cake. */
        private int ActualLength 
        {
            get
            {
                if (CakeWriting.Length > MaxWritingLength())
                    return MaxWritingLength();
                else
                    return CakeWriting.Length;
            }
        }

        private int CakeSize() {
            if (NumberOfPeople <= 4)
                return 8;
            else
                return 16;
        }

        private int MaxWritingLength()
        {
            if (CakeSize() == 8)
                return 16;
            else
                return 40;
        }


    }
}
