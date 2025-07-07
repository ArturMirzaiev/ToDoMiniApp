FROM mcr.microsoft.com/dotnet/sdk:8.0-preview

WORKDIR /app

COPY . .

RUN dotnet publish TodoApp.csproj -c Release -o out

WORKDIR /app/out

EXPOSE 8080

ENTRYPOINT ["dotnet", "TodoApp.dll"]
