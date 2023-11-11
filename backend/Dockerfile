FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ChatApp.Common/ChatApp.Common.csproj", "Common/"]
COPY ["ChatApp.DAL/ChatApp.DAL.csproj", "DAL/"]
COPY ["ChatApp.BLL/ChatApp.BLL.csproj", "BLL/"]
COPY ["ChatApp.WebAPI/ChatApp.WebAPI.csproj", "ChatApp.WebAPI/"]
RUN dotnet restore "ChatApp.WebAPI/ChatApp.WebAPI.csproj"

COPY . .
WORKDIR "/src/ChatApp.WebAPI"
RUN dotnet build "ChatApp.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatApp.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatApp.WebAPI.dll"]