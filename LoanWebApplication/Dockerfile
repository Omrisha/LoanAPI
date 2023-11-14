FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PensionWebApplication/PensionWebApplication.csproj", "PensionWebApplication/"]
COPY ["Pension.Data/Pension.Data.csproj", "Pension.Data/"]
COPY ["Pension.Common/Pension.Common.csproj", "Pension.Common/"]
COPY ["Pension.Data.EntityModel/Pension.Data.EntityModel.csproj", "Pension.Data.EntityModel/"]
COPY ["Pension.DomainModel.Impl/Pension.DomainModel.Impl.csproj", "Pension.DomainModel.Impl/"]
COPY ["Pension.DomainModel/Pension.DomainModel.csproj", "Pension.DomainModel/"]
COPY ["Pension.LoanLogic/Pension.LoanLogic.csproj", "Pension.LoanLogic/"]
COPY ["Pension.Application.PresentationModel/Pension.Application.PresentationModel.csproj", "Pension.Application.PresentationModel/"]
RUN dotnet restore "PensionWebApplication/PensionWebApplication.csproj"
COPY . .
WORKDIR "/src/PensionWebApplication"
RUN dotnet build "PensionWebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PensionWebApplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PensionWebApplication.dll"]
