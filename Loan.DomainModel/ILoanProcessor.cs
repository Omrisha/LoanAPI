namespace Loan.DomainModel;

public interface ILoanProcessor
{
    /// <summary>
    /// Calculating loan for a client.
    /// </summary>
    /// <param name="input">A <see cref="CalculateLoanForClientInput"/> instance.</param>
    /// <returns>A <see cref="CalculateLoanForClientOutput"/> output.</returns>
    Task<CalculateLoanForClientOutput> CalculateLoanForClient(CalculateLoanForClientInput input);
}