FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Glasno.Case.Aggregator.Presentation/Glasno.Case.Aggregator.Presentation.csproj", "src/Glasno.Case.Aggregator.Presentation/"]
RUN dotnet restore "src/Glasno.Case.Aggregator.Presentation/Glasno.Case.Aggregator.Presentation.csproj"
COPY . .
WORKDIR "/src/src/Glasno.Case.Aggregator.Presentation"
RUN dotnet build "Glasno.Case.Aggregator.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Glasno.Case.Aggregator.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Glasno.Case.Aggregator.Presentation.dll"]
