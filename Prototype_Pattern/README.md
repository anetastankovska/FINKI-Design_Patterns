# Project: Design Patterns - Prototype Pattern

## Overview
This project demonstrates the **Prototype Design Pattern** in C# using a practical example of keeping a value in specific registers and updating that value based on the operator and the operation.

---

## Features
- **Prototype Pattern Implementation**:
  - Cloning service and package objects.
  - Preserving and customizing service attributes.
- **Customizable Packages**:
  - Allows users to select predefined packages.
  - Supports adding or replacing services dynamically.
  - Displays updated package details after each customization.
- **Input Validation**:
  - Includes helper methods to validate user input for choices and yes/no prompts.
- **Dynamic Service Options**:
  - Services are dynamically added, replaced, and removed from available options.

---

## Folder Structure

```
source/
├── bin/                # Compiled binary files
├── Models/             # Contains abstract and concrete models
│   ├── Interfaces/     # Service and cloning interfaces
│   └── Models/         # Package and service prototypes
├── obj/                # Intermediate object files
├── Services/           # Service prototypes (voice, SMS, data, roaming)
├── Util/               # Utility classes (e.g., InputValidator)
└── Program.cs          # Main program entry point
```

---

## Classes and Design

### Core Classes

#### **BaseEntity**
- Abstract base class for all entities.
- Properties:
  - `Id`: Unique identifier for the entity.
  - `Name`: Name of the entity.
  - `Price`: Price associated with the entity.

#### **PackagePrototype**
- Represents a customizable package.
- Implements `ICloneable` for cloning.
- Properties:
  - `Price`: Calculated sum of all included service prices.
  - `Services`: List of services included in the package.
- Methods:
  - `Clone()`: Creates a copy of the package.
  - `AddService(IService)`: Adds a service to the package.
  - `CustomizeService(List<IService>)`: Allows dynamic customization of the package.
  - `ConfigureService(string, Dictionary<string, object>)`: Updates service configuration.

#### **InputValidator**
- Utility class for input validation.
- Methods:
  - `GetYesOrNoInput(string)`: Validates yes/no input.
  - `GetValidChoice(string, int, int)`: Validates numeric choices within a range.

#### **Service Prototypes**
- Concrete implementations for different services:
  - `VoiceServicePrototype`
  - `SMSServicePrototype`
  - `DataServicePrototype`
  - `RoamingServicePrototype`
- All services implement the `IService` interface.

---

## Getting Started

### Prerequisites
- **.NET SDK**: Ensure the .NET SDK is installed.
- **Visual Studio**: Recommended for building and running the project.

### Setup
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Navigate to the project directory:
   ```bash
   cd <project-directory>
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Build the project:
   ```bash
   dotnet build
   ```

### Running the Application
1. Run the application:
   ```bash
   dotnet run
   ```
2. Follow the on-screen instructions to select and customize packages.

---

## Example Usage

1. **Select a Package**:
   ```
   Please select a Package
   0: Standard
   1: Optimum
   2: Premium
   ```

2. **Customize Services**:
   ```
   Would you like to customize your package? (y/n)
   y
   Which service would you like to add or replace?
   0: None | 1: Optimum Voice | 2: Premium Voice | ...
   ```

3. **View Updated Package**:
   ```
   Updated package details:
   --- Standard + Optimum Data ---
   Standard Voice:
     MinutesIncluded: 300
     Price: 300
   Optimum Data:
     DataLimitGB: 30
     Price: 300
   *** Total Package Price: 800
   ```


