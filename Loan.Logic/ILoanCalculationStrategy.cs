namespace Loan.Logic;

public interface ILoanCalculationStrategy
{
    /// <summary>
    /// Calculate loan by type.
    /// </summary>
    /// <param name="calculationType">Calculation type.</param>
    /// <param name="amount">Requested amount to calculate.</param>
    /// <param name="period">Period to deploy the loan onto.</param>
    /// <returns>Total amount of loan.</returns>
    double CalculateLoanByType(CalculationTypeEnum calculationType, int amount, int period);
}