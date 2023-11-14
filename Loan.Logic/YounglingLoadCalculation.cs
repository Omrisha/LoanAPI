namespace Loan.Logic;

using Loan.Common;
using Loan.Logic.Interfaces;

public class YounglingLoadCalculation : ILoanCalculationExecution
{
    public double CalculateLoan(int amount, int period)
    {
        double interestPercentage = Constants.PrimeInterest + 2;
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