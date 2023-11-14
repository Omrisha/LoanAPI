namespace Loan.Data.EntityModel;

public interface IEntity<TIdentifier>
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    TIdentifier Identifier { get; set; }
}