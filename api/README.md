# Dark Roasted Coffee API

The Dark Roasted Coffee API is a backend API project written in C# using .NET Core 7.0. It exposes endpoints to retrieve coffee drink data.

## Features

- Swagger documentation for API endpoints
- Integration tests to ensure the API functions correctly
- Unit tests using the Moq framework to test specific components

## Prerequisites

To run this project locally, make sure you have the following prerequisites installed:

- [.NET Core 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)

## Getting Started

To get started with the Dark Roasted Coffee API, follow these steps:

## Running locally from your IDE

1. Clone this repo
 ```console
 git clone  https://github.com/Multiconsult-Group/10223788-02-Portal-backend.git
 ```
2. Navigate to the project directory:
```console
 cd dark-roasted-coffee-api/api/
 ```
3. Build the project:
```console
 dotnet build
 ```
 4. Run the project:
 ```console
 dotnet run
 ```

 5. The API will be accessible at https://localhost:5001 by default.

Explore the API documentation:

Open a web browser and navigate to https://localhost:5001/swagger to access the Swagger UI documentation. Here, you can view and interact with the available API endpoints.

## Running Tests

The Dark Roasted Coffee API includes both integration tests and unit tests. To run the tests, follow these steps:

1. Navigate to the test project directory:
```console
 cd dark-roasted-coffee-api/api/CoffeAPITests
 ```
2. Run tests
```console
 dotnet test
 ```

 The tests will be executed, and the results will be displayed in the console.


