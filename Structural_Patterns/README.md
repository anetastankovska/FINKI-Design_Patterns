# Project: Design Patterns - Structural Patterns - Decorator Pattern

## Overview
This project demonstrates the **Decorator Pattern**, a structural design pattern in C#, through the implementation of a Greeting Card system. The system allows users to create customizable greeting cards with features such as adding text, images, animations, and sending the cards to multiple recipients.
The Decorator Pattern is used to dynamically add functionalities to the basic greeting card object without altering its core structure. This design pattern adheres to the Open-Closed Principle and promotes code reusability and flexibility.

Some of the main reasons I decided to use the Decorator Pattern are:
1. Supports Flexible Customization: The basic greeting card contains predefined text. Users need the ability to add extra content, such as text and images, without altering the base class.
2. Adheres to Open-Closed Principle: It adheres to the open-closed principle, allowing me to extend the functionality of the greeting card without modifying its existing code. So, I can start with a basic greeting card and then "decorate" it with additional features like text or images.
3. Promotes Composition Over Inheritance: Instead of creating multiple subclasses for different types of greeting cards, I can use composition to add features, making the system more flexible and easier to maintain.
4. Maintains a Modular Design: It keeps the core card structure intact while enabling additional functionalities like adding content or sending the card to multiple recipients.
5. Reusability: Each "decoration" (e.g., adding images or modifying text) is implemented as a separate class, promoting code reusability and separation of concerns.

---

## Features
- **Basic Greeting Card**:
  - Create a greeting card with a predefined title and body.
  - Add one or multiple recipients.
- **Dynamic Customization**
  - Add custom text, images, or animations to enhance the greeting card.
  - Use decorators to apply these customizations dynamically at runtime.
- **Recipient Management**:
  - Add recipients' information (name and address) to the greeting card.
- **Rendering**:
  - Render the final greeting card with all decorations applied.

---

## Folder Structure

```
source/
├── Models/
│   ├── GreetingCard.cs
│   ├── BasicGreetingCard.cs
│   ├── Recipient.cs
│   ├── Decorators/
│   │   ├── GreetingCardDecorator.cs
│   │   ├── TextDecorator.cs
│   │   ├── ImageDecorator.cs
│   │   └── AnimationDecorator.cs
│   └── Interfaces/
│       └── IGreetingCard.cs
├── Services/
│   └── GreetingCardService.cs
└── Program.cs
```

---

## Classes and Design

### Core Classes

#### **GreetingCard**
- Abstract base class that defines the structure of a greeting card.
- Properties:
  - `Id`: Unique identifier for the card.
  - `Title`: Title of the greeting card.
  - `Body`: Content of the greeting card.
  - `Recipients`: List of recipients for the card.
  - `CardLines`: Basic line decoration for the card.
- Methods:
  - `Presentation': Visual presentation of the card.
  - `Render()`: Renders the card content.
  - `AddRecipient(Recipient recipient)`: Adds a recipient to the card.

#### **BasicGreetingCard**
- Concrete implementation of GreetingCard.
- Represents a simple greeting card with predefined title and body.

#### **Recipient**
- Represents a recipient of the greeting card.
- Properties:
  - `FirstName`: First name of the recipient.
  - `LastName`: Last name of the recipient.
  - `Street`: Street of the recipient.
  - `City`: City of the recipient.
  - `ZipCode`: ZipCode of the recipient.
  - `Country`: Street of the recipient.
- Methods:
  - `ToString()`: Returns a formatted string of the recipient's address.

#### **InputValidator**
- Utility class for input validation.
- Methods:
  - `GetYesOrNoInput(string)`: Validates yes/no input.
  - `GetValidChoice(string, int, int)`: Validates numeric choices within a range.
  - `ValidateNumber(string)`: Validates user input that should be parsed into a decimal value.

### **Decorators**
#### **GreetingCardDecorator**
- Abstract decorator class that extends GreetingCard.
- Wraps an IGreetingCard to add additional functionality.
- Properties:
  - `_card`: The decorated card.
- Methods:
  - `Render()`: Calls the wrapped card's Render() method.

#### **TextDecorator**
- Adds custom text to the greeting card.
- Properties:
  - `_additionalText` - Additional text of the card.
- Methods:
  - `Render()`: Appends the additional text to the card content.

#### **ImageDecorator**
- Adds an image to the greeting card.
- Properties:
  - `_imageUrl` - Url of the card image.
- Methods:
  - `Render()`: Appends an image URL to the card content.

#### **AnimationDecorator**
- Adds an animation to the greeting card.
- Properties:
  - `_animationUrl` - Url of the card image.
- Methods:
  - `Render()`: Appends an animation URL to the card content.

#### **GreetingCardService**
- Manages sending greeting cards to recipients.
- Methods:
  - `Start() - Mehod for bulding the greeting card.
  - `SendGreetingCard(IGreetingCard card, List<Recipient> recipients)`: Sends the card to all specified recipients.

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

### Step 1: Prompt for Creating a Greeting Card
- Console displays:
  ```
  Would you like to create a Card (Y)es/(N)o:
  ```
- Enter `Y` to start creating a greeting card or `N` to exit.

### Step 2: Creating the Greeting Card
- Console prompts:
  ```
  Please enter your Card Title:
  ```
- Enter a title, for example:
  ```
  Happy Birthday
  ```
- Next prompt:
  ```
  Please enter your Card Message:
  ```
- Enter a message, for example:
  ```
  Wishing you lots of happiness and success!
  ```

### Step 3: Adding Text, Image, or Nothing
- Console prompts:
  ```
  Would you like to add (T)ext, (I)mage or (N)othing:
  ```
- If `T` is entered:
  ```
  Please type/paste the additional message:
  ```
  Enter, for example:
  ```
  Enjoy your day!
  ```
- If `I` is entered:
  ```
  Please type/paste the URL to the image:
  ```
  Enter a URL, for example:
  ```
  https://example.com/birthday.jpg
  ```

### Step 4: Adding Recipients or Sending the Card
- Console prompts:
  ```
  Would you like to add (C)heck Card, (A)dd Recipient, (S)end Card or (Q)uit:
  ```
- If `A` is entered, fill in recipient details:
  ```
  First Name: Ana
  Last Name: Petrova
  Street: Macedonia Street
  Street Number: 12
  City: Skopje
  Zip Code: 1000
  Country: Macedonia
  ```
- If `C` is entered, the rendered card will be displayed.
- If `S` is entered, the card will be sent to all recipients.

### Step 5: Ending the Process
- Enter `Q` to exit the application.


