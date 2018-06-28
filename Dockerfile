# Build project for production
FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o dist

# Run
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime
WORKDIR /app
COPY --from=build /app/dist ./
ENTRYPOINT ["dotnet", "TodoApi.dll"]
