# Library App

## Description

Library App is a .NET 9.0 console application for managing library operations. It provides functionality to search patrons, view their loan history, manage book loans, and renew memberships. The application uses a layered architecture with clean separation of concerns, utilizing JSON-based data storage for portability and simplicity.

## Project Structure

```
AccelerateDevGHCopilot/
├── src/
│   ├── Library.ApplicationCore/
│   │   ├── Library.ApplicationCore.csproj
│   │   ├── Entities/
│   │   │   ├── Patron.cs
│   │   │   ├── Loan.cs
│   │   │   ├── Book.cs
│   │   │   ├── Author.cs
│   │   │   └── BookItem.cs
│   │   ├── Enums/
│   │   │   ├── ConsoleState.cs
│   │   │   ├── CommonActions.cs
│   │   │   └── EnumHelper.cs
│   │   ├── Interfaces/
│   │   │   ├── IPatronRepository.cs
│   │   │   ├── ILoanRepository.cs
│   │   │   ├── IPatronService.cs
│   │   │   └── ILoanService.cs
│   │   └── Services/
│   │       ├── PatronService.cs
│   │       └── LoanService.cs
│   ├── Library.Console/
│   │   ├── Library.Console.csproj
│   │   ├── Program.cs
│   │   ├── ConsoleApp.cs
│   │   ├── ConsoleState.cs
│   │   ├── CommonActions.cs
│   │   ├── appSettings.json
│   │   └── Json/
│   │       ├── Authors.json
│   │       ├── Books.json
│   │       ├── BookItems.json
│   │       ├── Patrons.json
│   │       └── Loans.json
│   └── Library.Infrastructure/
│       ├── Library.Infrastructure.csproj
│       └── Data/
│           ├── JsonData.cs
│           ├── JsonPatronRepository.cs
│           └── JsonLoanRepository.cs
├── tests/
│   └── UnitTests/
│       ├── UnitTests.csproj
│       ├── PatronFactory.cs
│       ├── LoanFactory.cs
│       └── ApplicationCore/
└── AccelerateDevGHCopilot.sln
```

## Key Classes and Interfaces

### Entities
- **Patron** - Represents a library member with membership dates and associated loans
- **Loan** - Tracks book loans with loan date, due date, and return date
- **Book** - Represents a book with title, author, and ISBN
- **Author** - Represents an author with name
- **BookItem** - Represents a physical copy of a book

### Services
- **PatronService** (IPatronService) - Handles patron-related business logic including membership management
- **LoanService** (ILoanService) - Manages loan operations and renewal logic

### Repositories
- **JsonPatronRepository** (IPatronRepository) - Data access layer for patrons using JSON storage
- **JsonLoanRepository** (ILoanRepository) - Data access layer for loans using JSON storage
- **JsonData** - Handles JSON deserialization and data loading

### UI Components
- **ConsoleApp** - Main application entry point managing the console state machine
- **ConsoleState** - Enumeration defining application states (PatronSearch, PatronSearchResults, PatronDetails, LoanDetails, Quit)
- **CommonActions** - Enumeration for available user actions

## Usage

### Building the Project

```bash
dotnet build
```

### Running the Application

```bash
dotnet run --project src/Library.Console/Library.Console.csproj
```

### Running Tests

```bash
dotnet test
```

### Configuration

Update `src/Library.Console/appSettings.json` to specify JSON data file locations:

```json
{
    "JsonPaths": {
        "Authors": "Json/Authors.json",
        "Books": "Json/Books.json",
        "BookItems": "Json/BookItems.json",
        "Patrons": "Json/Patrons.json",
        "Loans": "Json/Loans.json"
    }
}
```

### Features

- **Patron Search** - Search for library patrons by name
- **Loan History** - View all loans for a specific patron
- **Membership Renewal** - Renew patron memberships
- **Loan Details** - View detailed information about specific loans
- **Loan Management** - Track book returns and due dates

## License

This project is provided as-is for educational purposes.
