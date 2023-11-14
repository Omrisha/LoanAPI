namespace Loan.DomainModel;

public class CalculateLoanForClientInput
{
    /// <summary>
    /// Gets or sets client identifier.
    /// </summary>
    public Guid ClientId { get; set; }

    /// <summary>
    /// Gets or sets the amount of the loan
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Gets or sets the period of the loan.
    /// </summary>
    public int Period { get; set; }
}