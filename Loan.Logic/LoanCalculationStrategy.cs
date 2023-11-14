namespace Loan.Logic;

using Loan.Common;
using Loan.Logic.Interfaces;

public class LoanCalculationStrategy : ILoanCalculationStrategy
{
    private readonly Dictionary<CalculationTypeEnum, ILoanCalculationExecution> loanCalculationExecutions;

    public LoanCalculationStrategy()
    {
        loanCalculationExecutions = new Dictionary<CalculationTypeEnum, ILoanCalculationExecution>
        {
            { CalculationTypeEnum.Under20, new YounglingLoadCalculation() },
            { CalculationTypeEnum.Between20To35, new MidLoadCalculation() },
            { CalculationTypeEnum.Over35, new SeniorLoadCalculation() }
        };
    }

    public double CalculateLoanByType(CalculationTypeEnum calculationType, int amount, int period)
    {
        ILoanCalculationExecution loanCalculationExecution = this.loanCalculationExecutions[calculationType];

        if (loanCalculationExecutions is null)
        {
            throw new KeyNotFoundException($"Calculation logic for type {calculationType} is not found.");
        }

        return loanCalculationExecution.CalculateLoan(amount, period);
    }
}