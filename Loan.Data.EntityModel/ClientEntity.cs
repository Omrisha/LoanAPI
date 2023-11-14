using System.ComponentModel.DataAnnotations.Schema;

namespace Loan.Data.EntityModel;

[Table("Client")]
public class ClientEntity : IEntity<Guid>
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public Guid Identifier { get; set; }

    /// <summary>
    /// Gets or sets the age.
    /// </summary>
    public int Age { get; set; }
}