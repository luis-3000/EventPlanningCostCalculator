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

        /* This property treutns true if the writinng is too long for the cake.
         * we'll use it to display a "TOO LONG" message to the user. */
        public bool CakeWritingTooLong
        {
            get
            {
                if (CakeWriting.Length > MaxWritingLength())
                    return true;
                else
                    return false;
            }
        }

        /* Just like the one in the DinnerParty class. */
        private decimal CalculateCostOfDecorations()
        {
            decimal costOfDecorations;
            if (FancyDecorations)
                costOfDecorations = (NumberOfPeople * 15.00M) + 50M;
            else
                costOfDecorations = (NumberOfPeople * 7.50M) + 30M;
            return costOfDecorations;
        }

        /* The BirthdayParty class has a decimal Cost property, just like DinnerParty. But it does
         * a different calculation that uses the CakeSize() method and actualLength field (which is set by the
         * CakeWriting property). */
        public decimal Cost 
        {
            get
            {
                decimal totalCost = CalculateCostOfDecorations();
                totalCost += CostOfFoodPerPerson * NumberOfPeople;
                decimal cakeCost;
                if (CakeSize() == 8)
                    cakeCost = 40M + ActualLength * .25M;
                else
                    cakeCost = 75M + ActualLength * .25M;
                return totalCost + cakeCost;
            }
        }
    }
}
