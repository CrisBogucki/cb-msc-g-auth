FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["cb-msc-g-auth.csproj", "./"]
RUN dotnet restore "cb-msc-g-auth.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "cb-msc-g-auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cb-msc-g-auth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cb-msc-g-auth.dll"]


