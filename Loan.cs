using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLoanCalculator
{
    internal abstract class Loan
    {
        public string CustomerName { get; set; } // Instance variables for the base class Loan
        public int LoanNumber { get; set; }
        public double LoanAmount { get; set; }

        public Loan() // No argument constuctor

        {

        }

        public Loan(string CustomerName, int LoanNumber, double LoanAmount)// Constructor for Loan.In hindsight it would have been better to have the interest and length here as well annd have methods for calculations for
                                                                           // everything in this class since all loans have interest and length.Fix later
        {
            this.CustomerName = CustomerName;

            this.LoanNumber = LoanNumber;

            this.LoanAmount = LoanAmount;
        }
        public abstract double GetMonthlyPayment(); // Gets calculation for monthly payment in the home loan class
        public abstract double GetLifetimePayment(); // Gets and excecutes lifetime payment in home loan class
        public abstract double GetInterestRate(); // Grabs interest rate, seems excessive to have an entire method to grab it but I do not know any other way to grab it from HomeLoan
        public abstract int GetLoanTermYears(); // Same with LoanTermYears, did not see another way to pull from HomeLoan.So that is all it does.

        public override string ToString() => // To String in order to list out financial details for loan

            $"For a loan amount of {LoanAmount:C}, the monthly payment is {GetMonthlyPayment():C}" +
            $"\nApplicable interest rate = {GetInterestRate():P}" +
            $"\nLoan is for {GetLoanTermYears()} years" +
            $"\nThe life time payment for this loan is {GetLifetimePayment():C}";

    }
}
