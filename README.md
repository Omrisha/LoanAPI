# LoanAPI

## Installation

- Run the command `git clone https://github.com/Omrisha/LoanAPI`
- Open the SLN file in Visual Studio/Rider/Visual Studio Code

# Option #1
- Run the project (or  `dotnet run` if in VSCode) - to run with kestrel.

# Option #2 - Docker
- Run `docker compose`.


## Endpoints
POST - `http://localhost:5001/Loan`
JSON:
```
{
    "clientId": "03BFC6CC-2CD1-40CB-AA61-E63C728E2B12",
    "amount": 4500,
    "period": 13
}
```