#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MailSender_Application/MailSender_Application.csproj", "MailSender_Application/"]
COPY ["MailSender_ApplicationCore/MailSender_ApplicationCore.csproj", "MailSender_ApplicationCore/"]
COPY ["MailSender_Domain/MailSender_Domain.csproj", "MailSender_Domain/"]
COPY ["MailSender_InfraCrossCutting/MailSender_InfraCrossCutting.csproj", "MailSender_InfraCrossCutting/"]
COPY ["MailSender_Infra/MailSender_Infra.csproj", "MailSender_Infra/"]
RUN dotnet restore "MailSender_Application/MailSender_Application.csproj"
COPY . .
WORKDIR "/src/MailSender_Application"
RUN dotnet build "MailSender_Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MailSender_Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MailSender_Application.dll"]