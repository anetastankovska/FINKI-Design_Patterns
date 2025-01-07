# Project: Design Patterns - Observer and Strategy Pattern

## Overview
This project demonstrates the **Observer and Strategy Design Patterns** in C# using a practical example of package customization for services like voice, SMS, data, and roaming. The pattern allows cloning existing objects to create new instances while maintaining the ability to modify them independently.

---

## Features
- **Observer Pattern Implementation**:
  - Registers as subjects that can be observed.
  - Dynamic addition and removal of observers.
- **Strategy Pattern Implementation**
  - Different mathematical operations (addition, subtraction, multiplication, division) as strategies.
- **Register Management**:
  - Multiple registers can be created and managed.
  - Each register can have multiple observers.
- **Dynamic Observer Customization**:
  - Observers can be added or removed at runtime.
  - Each observer can have a unique operation and operand.
- **Automatic Updates**:
  - Observers are automatically notified and updated when register values change.

---

## Folder Structure

```
source/
├── bin/                 # Compiled binary files
├── Models/              # Contains abstract and concrete models
│   ├── Interfaces/      # Service and cloning interfaces
│   └── Implementations/ # Package and service prototypes
├── obj/                 # Intermediate object files
├── Services/            # Service prototypes (voice, SMS, data, roaming)
│   ├── Observers/       # Service and cloning interfaces
│   └── Operations/      # Package and service prototypes
├── Util/                # Utility classes (e.g., InputValidator)
└── Program.cs           # Main program entry point
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


