\# 📝 Todo API

A simple RESTful API for managing a todo list, built with **ASP\.NET Core**, **Entity Framework Core**, and **SQL Server** \(via Docker\)\. Supports full CRUD operations\. Includes a unit test suite using **NUnit** with high test coverage\.

## 🚀 Features

\- CRUD operations for Todo items \(`Title`, `Description`\)  
\- ASP\.NET Core Web API \(Minimal Program\.cs\)  
\- Entity Framework Core for data persistence  
\- SQL Server running in Docker container  
\- Swagger \(OpenAPI\) documentation  
\- NUnit\-based unit tests  
\- Code coverage using Coverlet  
\- Rider\-friendly setup \(cross\-platform\)

## 📦 Requirements

\- \[\.NET 8 SDK\]\(https://dotnet.microsoft.com/download\)  
\- \[Docker\]\(https://www.docker.com/products/docker-desktop\)  
\- Rider / VS Code / Visual Studio

## 🛠️ Getting Started

### 1\. Clone the Repository

\`\`\`bash
git clone https://github.com/your-username/todo-api.git
cd todo-api
\`\`\`

### 2\. Start SQL Server with Docker

\`\`\`bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrong!Passw0rd" \
   -p 1433:1433 --name sqlserver \
   -d mcr.microsoft.com/mssql/server:2022-latest
\`\`\`

### 3\. Update `appsettings.json`

\`\`\`json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=TodoDb;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
}
\`\`\`

### 4\. Run EF Core Migrations

\`\`\`bash
dotnet ef migrations add InitialCreate
dotnet ef database update
\`\`\`

### 5\. Run the Application

\`\`\`bash
dotnet run
\`\`\`

\- API: https://localhost:5001/api/todo  
\- Swagger UI: https://localhost:5001/swagger

## 📖 API Endpoints

| Method | Endpoint         | Description        |
|--------|------------------|--------------------|
| GET    | /api/todo        | Get all todos      |
| GET    | /api/todo/{id}   | Get todo by ID     |
| POST   | /api/todo        | Create new todo    |
| PUT    | /api/todo/{id}   | Update existing    |
| DELETE | /api/todo/{id}   | Delete a todo      |

## 🧪 Testing

### Run Unit Tests with NUnit

\`\`\`bash
dotnet test
\`\`\`

### Code Coverage \(with Coverlet\)

\`\`\`bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov
\`\`\`

Generates `coverage.info` file for visualization tools or Rider integration\.

## 🛠 Rider Tips

\- Open **Unit Tests**: `View → Tool Windows → Unit Tests`  
\- Right\-click test methods or classes to run/debug  
\- If tests aren't detected, ensure:  
  \- `Microsoft.NET.Test.Sdk`, `NUnit`, and `NUnit3TestAdapter` are installed  
  \- Test methods use `[Test]` and classes use `[TestFixture]`

## 🧹 Clean Up

\`\`\`bash
docker stop sqlserver
docker rm sqlserver
\`\`\`

## 📬 Contact

Feel free to open an issue or PR if you spot a bug or want to contribute\.
