using Microsoft.AspNetCore.Mvc;
using Loan.Application.PresentationModel;
using Loan.DomainModel;

namespace PensionWebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class LoanController : ControllerBase
{
    private readonly ILoanProcessor loanProcessor;
    private readonly ILogger<LoanController> _logger;

    public LoanController(ILogger<LoanController> logger, ILoanProcessor loanProcessor)
    {
        _logger = logger;
        this.loanProcessor = loanProcessor;
    }

    [HttpPost]
    public async Task<IActionResult> CalculateLoan(CalculateLoanPresentationModel presentationModel)
    {
        CalculateLoanForClientInput calculateLoanForClientInput = new()
        {
            ClientId = presentationModel.ClientId,
            Amount = presentationModel.Amount,
            Period = presentationModel.Period,
        };

        CalculateLoanForClientOutput calculateLoanForClientOutput =
            await this.loanProcessor.CalculateLoanForClient(calculateLoanForClientInput);

        return Ok(calculateLoanForClientOutput);
    }
}