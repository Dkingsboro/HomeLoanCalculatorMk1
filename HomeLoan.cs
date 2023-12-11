using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLoanCalculator
{
    internal class HomeLoan : Loan
    {
        public string HouseStyle { get; set; } // Instance variables for HomeLoan class, like I said before the interest rate and loan term years should go in LOAN but it works like this right now
        public int SquareFootage { get; set; }
        public int LoanTermYears { get; set; }
        public double InterestRate { get; set; }
        public HomeLoan() : base() // No argument constructor for HomeLoan derived class
        {

        }

        public HomeLoan(string HouseStyle, int SquareFootage, int LoanTermYears, double InterestRate, string CustomerName, int LoanNumber, double LoanAmount)
            : base(CustomerName, LoanNumber, LoanAmount) // Constructor for HomeLoan with ALL the details.
        {
            this.HouseStyle = HouseStyle;
            this.SquareFootage = SquareFootage;
            this.LoanTermYears = LoanTermYears;
            this.InterestRate = InterestRate;
        }

        public HomeLoan(int LoanTermYears, double InterestRate, int LoanNumber, double LoanAmount)  // Constructor for ONLY the financial details. Overcomplicated things by putting the not seperating financial and details
             : base(null, LoanNumber, LoanAmount)                                                                                       // : base(null, LoanNumber, LoanAmount)
        {
            this.LoanTermYears = LoanTermYears;
            this.InterestRate = InterestRate;
        }

        public override double GetMonthlyPayment() // Calculation method for calculating monthly payments
        {
            double loanAmount = base.LoanAmount;
            double monthlyInterestRate = InterestRate / 100 / 12;
            int totalPayments = LoanTermYears * 12;
            double power = Math.Pow(1 + monthlyInterestRate, totalPayments);
            double monthlyPayment = loanAmount * monthlyInterestRate * power / (power - 1);
            return monthlyPayment;
        }

        public override double GetLifetimePayment() // Calculation for Lifetime Payment
        {
            double monthlyPayment = GetMonthlyPayment();
            int totalPayments = LoanTermYears * 12;
            double lifetimeCost = monthlyPayment * totalPayments;
            return lifetimeCost;
        }

        public override double GetInterestRate() // To return interest rate to Loan Class
        {
            return InterestRate / 100;
        }

        public override int GetLoanTermYears() // Litereally just to return Loan term to the Loan class
        {
            return LoanTermYears;
        }

        public override string ToString() => base.ToString() + // To string to add non financial details to Loan class
            $"\n" + $"Customer {base.CustomerName} has a {HouseStyle} type of house with {SquareFootage} sqaure feet space.";
    }
}
