using Loan.Data;
using Loan.Data.EntityModel;
using Loan.Logic;

namespace Loan.DomainModel.Impl;

public class LoanProcessor : ILoanProcessor
{
    private readonly IRepository<ClientEntity, Guid> clientRepository;
    private readonly ILoanCalculationStrategy loanCalculationStrategy;

    /// <summary>
    /// Initialize a new instance ot <see cref="LoanProcessor"/>.
    /// </summary>
    /// <param name="clientRepository">A <see cref="IRepository{TEntity,TIdentifier}"/> instance.</param>
    /// <param name="loanCalculationStrategy">A <see cref="ILoanCalculationStrategy"/> instance.</param>
    public LoanProcessor(IRepository<ClientEntity, Guid> clientRepository, ILoanCalculationStrategy loanCalculationStrategy)
    {
        this.clientRepository = clientRepository;
        this.loanCalculationStrategy = loanCalculationStrategy;
    }

    public async Task<CalculateLoanForClientOutput> CalculateLoanForClient(CalculateLoanForClientInput input)
    {
        ClientEntity? clientEntity = (await this.clientRepository
            .GetEntities(e => e.Identifier == input.ClientId))
            .FirstOrDefault();

        if (clientEntity is null)
        {
            throw new KeyNotFoundException($"Client with {input.ClientId} is not found");
        }

        double totalAmount = clientEntity.Age switch
        {
            <= 20 => this.loanCalculationStrategy.CalculateLoanByType(CalculationTypeEnum.Under20, input.Amount, input.Period),
            <= 35 => this.loanCalculationStrategy.CalculateLoanByType(CalculationTypeEnum.Between20To35, input.Amount, input.Period),
            > 35 => this.loanCalculationStrategy.CalculateLoanByType(CalculationTypeEnum.Over35, input.Amount, input.Period),
        };

        return new CalculateLoanForClientOutput()
        {
            TotalAmount = totalAmount,
        };
    }
}