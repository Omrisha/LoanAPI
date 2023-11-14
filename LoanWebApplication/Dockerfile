FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LoanWebApplication/LoanWebApplication.csproj", "LoanWebApplication/"]
COPY ["Loan.Application.PresentationModel/Loan.Application.PresentationModel.csproj", "Loan.Application.PresentationModel/"]
COPY ["Loan.Data/Loan.Data.csproj", "Loan.Data/"]
COPY ["Loan.Common/Loan.Common.csproj", "Loan.Common/"]
COPY ["Loan.Data.EntityModel/Loan.Data.EntityModel.csproj", "Loan.Data.EntityModel/"]
COPY ["Loan.DomainModel.Impl/Loan.DomainModel.Impl.csproj", "Loan.DomainModel.Impl/"]
COPY ["Loan.DomainModel/Loan.DomainModel.csproj", "Loan.DomainModel/"]
COPY ["Loan.Logic/Loan.Logic.csproj", "Loan.Logic/"]
RUN dotnet restore "LoanWebApplication/LoanWebApplication.csproj"
COPY . .
WORKDIR "/src/LoanWebApplication"
RUN dotnet build "LoanWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoanWebApplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoanWebApplication.dll"]
