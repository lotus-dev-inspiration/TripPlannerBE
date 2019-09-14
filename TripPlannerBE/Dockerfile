FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY TripPlannerBE/TripPlannerBE.csproj TripPlannerBE/
COPY Repository/Repository.csproj Repository/
COPY Entities/Entities.csproj Entities/
RUN dotnet restore TripPlannerBE/TripPlannerBE.csproj
COPY . .
WORKDIR /src/TripPlannerBE
RUN dotnet build TripPlannerBE.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TripPlannerBE.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TripPlannerBE.dll"]
