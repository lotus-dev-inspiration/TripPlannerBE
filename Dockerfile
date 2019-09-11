FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

COPY TripPlannerBE/TripPlannerBE.csproj TripPlannerBE/
COPY . .
RUN dotnet restore TripPlannerBE/TripPlannerBE.csproj

# COPY ./TripPlannerBE ./TripPlannerBE/
# COPY ./Repository ./Repository/
# COPY ./Entities ./Entities/


WORKDIR /src/TripPlannerBE
# RUN dotnet build TripPlannerBE.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TripPlannerBE.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "TripPlannerBE.dll"]
