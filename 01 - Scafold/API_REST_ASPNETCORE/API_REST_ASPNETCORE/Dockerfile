#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 64309
EXPOSE 44360

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["API_REST_ASPNETCORE/API_REST_ASPNETCORE.csproj", "API_REST_ASPNETCORE/"]
RUN dotnet restore "API_REST_ASPNETCORE/API_REST_ASPNETCORE.csproj"
COPY . .
WORKDIR "/src/API_REST_ASPNETCORE"
RUN dotnet build "API_REST_ASPNETCORE.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "API_REST_ASPNETCORE.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "API_REST_ASPNETCORE.dll"]