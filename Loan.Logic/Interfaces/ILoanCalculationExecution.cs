namespace Loan.Logic.Interfaces;

public interface ILoanCalculationExecution
{
    double CalculateLoan(int amount, int period);
}