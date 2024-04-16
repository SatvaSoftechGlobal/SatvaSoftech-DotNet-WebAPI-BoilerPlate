# Satva Softech .NET WebAPI Boilerplate


## About Satva Softech

At Satva Softech, we pride ourselves on delivering robust technology solutions to a wide range of industries. Our approach combines the expertise of our mixed-shore teams to ensure top-notch implementation and support.

For more information, please visit [our website](https://www.satvasoftech.com).


## Overview

Welcome to the official repository for the Satva Softech .NET WebAPI Boilerplate. This project is designed to provide a robust starting point for building web APIs using .NET technology, demonstrating our best practices, coding standards, and commitment to quality. The boilerplate incorporates a scalable architecture that is suitable for enterprises and small to medium-sized businesses alike.

## Features

- **Clean Architecture**: Implementing the principles of clean architecture to ensure separation of concerns and easier maintenance.
- **Authentication**: Example implementations of standard authentication mechanisms.
- **Error Handling**: Unified approach to error handling, making it easier to manage exceptions and return meaningful error responses.
- **Logging**: Integrated logging for troubleshooting and monitoring the API usage.
- **Dependency Injection**: Utilizing built-in DI to manage dependencies.
- **Swagger Integration**: Configured Swagger for API documentation and testing purposes.
- **Health Checks**: Readiness and liveness probes to facilitate integration with deployment environments.
- **Unit and Integration Tests**: Examples of how to write testable code and actual tests to verify the boilerplate's functionality.

## Getting Started

### Prerequisites

Before you start using this boilerplate, ensure you have the following installed:
- [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download)
- An IDE of your choice (Visual Studio 2019+, VSCode, etc.)

### Installation

1. **Clone the repository:**
    ```bash
    git clone https://github.com/SatvaSoftech/dotnet-webapi-boilerplate.git
    ```

2. **Navigate to the project directory:**
    ```bash
    cd dotnet-webapi-boilerplate
    ```

3. **Restore dependencies:**
    ```bash
    dotnet restore
    ```

4. **Run the application:**
    ```bash
    dotnet run
    ```

### Documentation

To access the API documentation, navigate to `http://localhost:5000/swagger` after starting the application. This will display the Swagger UI with all the endpoints documented.
