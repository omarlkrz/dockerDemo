FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50276
EXPOSE 44393

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebApi10/WebApi10.csproj", "WebApi10/"]
RUN dotnet restore "WebApi10/WebApi10.csproj"
COPY . .
WORKDIR "/src/WebApi10"
RUN dotnet build "WebApi10.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApi10.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApi10.dll"]