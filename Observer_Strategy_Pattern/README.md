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
├── Models/              # Contains abstract models
│   ├── Interfaces/      # Service and cloning interfaces
│   └── Implementations/ # Contains concrete implementations
├── obj/                 # Intermediate object files
├── Services/            # Service classes
│   └── Operations/      # Contains operation classes (add, subtract, multiply, divide)
├── Util/                # Utility classes
└── Program.cs           # Main program entry point
```

---

## Classes and Design

### Core Classes

#### **Subject**
- Abstract implementation of the subject.
- Properties:
  - `Observers`: List that contains all the observers.
- Methods:
  - `Attach()`: Adds new observer.
  - `Detach()`: Removes new observer.
  - `Notify()`: Updates the observer with the latest value in case the value changes

#### **Observer**
- Concrete implementation of the IObserver interface.
- Properties:
  - `Operation`: The operation.
  - `Operand`: The operand.
  - `LastValue`: The last emitted value.

#### **Register**
- Concrete implementation of the Subject class.
- Properties:
  - `Value`: The emitted value.
- Methods:
  - `GetObservers()`: Returns all the observers.

#### **InputValidator**
- Utility class for input validation.
- Methods:
  - `GetYesOrNoInput(string)`: Validates yes/no input.
  - `GetValidChoice(string, int, int)`: Validates numeric choices within a range.
  - `ValidateNumber(string)`: Validates user input that should be parsed into a decimal value.

#### **RegisterHelper**
- Utility class for input validation.
- Methods:
  - `SetRegisterValue(Register, string)`: Sets the value of the register.
  - `AddObserver(Register, Register)`: Adds new observer.
  - `RemoveObserver(Register, Register)`: Removes existing observer.
  - `DisplayRemainingObservers(Register, Register)`: Displays remaining observers.

#### **AddOperation**
- Class responsible for executing sum operations:
- Methods:
  - `Execute(decimal)`: Execute sum operation.

#### **SubtractOperation**
- Class responsible for executing subtraction operations:
- Methods:
  - `Execute(decimal)`: Execute subtraction operation.

#### **MultiplyOperation**
- Class responsible for executing multiplication operations:
- Methods:
  - `Execute(decimal)`: Execute multiplication operation.

#### **DivideOperation**
- Class responsible for executing division operations:
- Methods:
  - `Execute(decimal)`: Execute division operation.


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
2. Follow the on-screen instructions.

---

## Example Usage
### Adding observer that adds 1 to Register A
> +
>> Set New Observer (A|B) (+|-|*|/) <num>): a+1
< observer #0 is 11

### Adding observer that subtracts 0.5 from Register A
> +
>> Set New Observer (A|B) (+|-|*|/) <num>): a-0.5
< observer #0 is 11
< observer #1 is 9.5

### Setting value in Register A
> a
>> value=1.23
< observer #0 is 2.23
< observer #1 is 0.73

### Removing observer #1
> -
>> Remove Observer (#): 1
< observer #0 is 2.23

The observer format is: [register][operation][number] where:
- register: a or b
- operation: +, -, *, or /
- number: decimal value3
Each observer performs its mathematical operation on the register's value whenever it changes, and displays the result automatically.

