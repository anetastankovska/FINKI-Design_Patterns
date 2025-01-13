using System;
using System.Collections.Generic;
using source.Models;
using source.Models.Decorators;
using source.Models.Interfaces;
using source.Services;

        
// Step 1: Create a Basic Greeting Card
IGreetingCard basicCard = new BasicGreetingCard("Happy Birthday!", "Wishing you a wonderful day filled with joy.");

// Step 2: Add Text Decoration
IGreetingCard textDecoratedCard = new TextDecorator(basicCard, "Enjoy your special day!");

// Step 3: Add Image Decoration
IGreetingCard imageDecoratedCard = new ImageDecorator(textDecoratedCard, "https://example.com/birthday-cake.jpg");

// Step 4: Add Recipients
var recipients = new List<Recipient>
{
    new Recipient("Alice", "Smith", "Main Street", "123", "New York", "10001", "USA"),
    new Recipient("Bob", "Johnson", "Broadway", "456", "Los Angeles", "90001", "USA")
};

foreach (var recipient in recipients)
{
    imageDecoratedCard.AddRecipient(recipient);
}

// Step 5: Use GreetingCardService to Send the Card
var service = new GreetingCardService();
service.SendGreetingCard(imageDecoratedCard, recipients);

// Step 6: Output Result
Console.WriteLine("\nCard Sent Successfully!");
