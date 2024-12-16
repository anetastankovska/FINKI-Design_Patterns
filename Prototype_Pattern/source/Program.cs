using source.Models.Models;
using source.Serrvices;

var packageManager = new PackageManager();

// Create and register package prototypes
var standardPackage = new PackagePrototype { Name = "Standard" };
standardPackage.AddService(new VoiceService { Name = "Voice", Price = 10f, MinutesIncluded = 100 });
standardPackage.AddService(new SMSService { Name = "SMS", Price = 5f, SMSIncluded = 100 });
packageManager.RegisterPackage("Standard", standardPackage);

var optimumPackage = new PackagePrototype { Name = "Optimum" };
optimumPackage.AddService(new VoiceService { Name = "Voice", Price = 20f, MinutesIncluded = 500 });
optimumPackage.AddService(new DataService { Name = "Data", Price = 30f, DataLimitGB = 20 });
optimumPackage.AddService(new SMSService { Name = "SMS", Price = 5f, SMSIncluded = 100 });
packageManager.RegisterPackage("Optimum", optimumPackage);

var premiumPackage = new PackagePrototype { Name = "Premium" };
premiumPackage.AddService(new VoiceService { Name = "Voice", Price = 20f, MinutesIncluded = 500 });
premiumPackage.AddService(new DataService { Name = "Data", Price = 30f, DataLimitGB = 20 });
premiumPackage.AddService(new SMSService { Name = "SMS", Price = 5f, SMSIncluded = 100 });
premiumPackage.AddService(new RoamingService { Name = "Roaming", Price = 5f, RoamingIncluded = 200 });
packageManager.RegisterPackage("Premium", premiumPackage);

// Create a standard package
var newStandardPackage = packageManager.CreatePackage("Standard");
Console.WriteLine($"Created package: {newStandardPackage.Name}, Id: {newStandardPackage.Id}");

// Create a custom package based on Premium
var customPackage = packageManager.CreateCustomPackage("Premium");
customPackage.ConfigureService("Voice", new Dictionary<string, object> { { "MinutesIncluded", 1000 }, { "Price", 25f } });
customPackage.ConfigureService("Data", new Dictionary<string, object> { { "DataLimitGB", 50 }, { "Price", 40f } });
customPackage.ConfigureService("SMS", new Dictionary<string, object> { { "SMSIncluded", 70 }, { "Price", 30f } });
customPackage.ConfigureService("Roaming", new Dictionary<string, object> { { "RoamingIncluded", 150 }, { "Price", 60f } });


Console.WriteLine($"Created custom package: {customPackage.Name}, Id: {customPackage.Id}");

// Output package details
foreach (var service in customPackage.Services)
{
    Console.WriteLine($"Service: {service.Name}, Price: {service.Price}, Id: {((BaseEntity)service).Id}");
}
