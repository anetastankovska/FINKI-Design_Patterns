# Project: Design Patterns - Structural Patterns

## Overview
This project demonstrates the **Structural Patterns** in C# using a practical example of sending postcards to one or multiple receivers with different content.
After investigating the most commonly used structural design patterns, I decided to use the Decorator Pattern for this homework. The Decorator pattern allows the user to dynamically add functionalities to objects at runtime.

Some of the main reasons I decided to use the Decorator Pattern are:
1. Flexible Customization: The basic greeting card contains predefined text. Users need the ability to add extra content, such as text and images, without altering the base class.
2. Open-Closed Principle: It adheres to the open-closed principle, allowing me to extend the functionality of the greeting card without modifying its existing code. So, I can start with a basic greeting card and then "decorate" it with additional features like text or images.
3. Composition Over Inheritance: Instead of creating multiple subclasses for different types of greeting cards, I can use composition to add features, making the system more flexible and easier to maintain.
4. Modular Design: It keeps the core card structure intact while enabling additional functionalities like adding content or sending the card to multiple recipients.
5. Reusability: Each "decoration" (e.g., adding images or modifying text) is implemented as a separate class, promoting code reusability and separation of concerns.

---

## Features
- **Observer Pattern Implementation**:
  - Registers as subjects that can be observed.
  - Dynamic addition and removal of observers.
  - Automatic notification when register values change.
- **Strategy Pattern Implementation**
  - Different mathematical operations (addition, subtraction, multiplication, division) as strategies.
  - Each observer uses a strategy to process register values.
- **Register Management**:
  - Multiple registers can be created and managed.
  - Each register can have multiple observers.
- **Dynamic Observer Customization**:
  - Observers can be added or removed at runtime.
  - Each observer can have a unique operation and operand.
- **Automatic Updates**:
  - Observers are automatically notified and updated when register values change.
- **Input Validation**:
  - Validates decimal number inputs.
---

## Folder Structure

```
source/
├── Models/
│   ├── Implementations/
│   │   ├── Register.cs
│   │   ├── Subject.cs
│   │   └── Observer.cs
│   └── Interfaces/
│       └── IObserver.cs
├── Operations/
│   ├── AddOperation.cs
│   ├── SubtractOperation.cs
│   ├── MultiplyOperation.cs
│   └── DivideOperation.cs
├── Util/
│   ├── RegisterHelper.cs
│   └── InputValidator.cs
└── Program.cs
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
  - `ID`: The id of the observer.
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

