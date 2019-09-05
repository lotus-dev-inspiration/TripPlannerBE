FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build

COPY Repository/*.csproj ./app/Repository/
WORKDIR /app/Repository
RUN dotnet restore
COPY Repository/. ./
RUN dotnet build -c Release -o /app

COPY Entities/*.csproj ./app/Entities/
WORKDIR /app/Entities
RUN dotnet restore
COPY Entities/. ./
RUN dotnet build -c Release -o /app

COPY TripPlannerBE/*.csproj ./app/TripPlannerBE/
WORKDIR /app/TripPlannerBE
RUN dotnet restore
COPY TripPlannerBE/. ./
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS runtime
WORKDIR /app
COPY /app .
ENTRYPOINT ["dotnet", "TripplannerBE.dll"]
