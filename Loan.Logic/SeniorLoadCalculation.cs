using Loan.Common;
using Loan.Logic.Interfaces;

namespace Loan.Logic;

public class SeniorLoadCalculation : ILoanCalculationExecution
{
    public double CalculateLoan(int amount, int period)
    {
        double interestPercentage = amount switch
        {
            <= 15000 => 1.5 + Constants.PrimeInterest,
            <= 30000 => Constants.PrimeInterest + 3,
            > 30000 => Constants.PrimeInterest + 1,
        };
        
        double interestAmount = amount * (interestPercentage / 100);
        double extraMonthInterest = 0;

        if (period <= 12)
        {
            return amount + interestAmount + extraMonthInterest;
        }
        
        double extraMonths = period - 12;
        extraMonthInterest = (extraMonths * Constants.ExtraMonthInterest / 100) * amount;

        return amount + interestAmount + extraMonthInterest;
    }
}