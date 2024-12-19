using source.Models.Models;
using source.Services;

var packageManager = new PackageManager();
var serviceFactory = new ServiceFactory();

// Generate all default services (Standard, Optimum, Premium) for voice, sms, data and roaming
serviceFactory.PopulateServices();

// Create and register package pre-defined prototypes
// Standard will include Voice and SMS services
var standardPackage = new PackagePrototype("Standard");
standardPackage.AddService(serviceFactory.FindAndClone("Standard Voice"));
standardPackage.AddService(serviceFactory.FindAndClone("Standard SMS"));
packageManager.RegisterPackage("Standard", standardPackage);

// Optimum will include Voice, SMS and Data
var optimumPackage = new PackagePrototype("Optimum");
optimumPackage.AddService(serviceFactory.FindAndClone("Optimum Voice"));
optimumPackage.AddService(serviceFactory.FindAndClone("Optimum SMS"));
optimumPackage.AddService(serviceFactory.FindAndClone("Optimum Data"));
packageManager.RegisterPackage("Optimum", optimumPackage);

// Premium will include Voice, SMS, Data and Roaming
var premiumPackage = new PackagePrototype("Premium");
premiumPackage.AddService(serviceFactory.FindAndClone("Premium Voice"));
premiumPackage.AddService(serviceFactory.FindAndClone("Premium SMS"));
premiumPackage.AddService(serviceFactory.FindAndClone("Premium Data"));
premiumPackage.AddService(serviceFactory.FindAndClone("Premium Roaming"));
packageManager.RegisterPackage("Premium", premiumPackage);

// App entry point
Console.WriteLine("Please select a Package");
var packages = packageManager.ListPackageNames();
var choice = int.Parse(Console.ReadLine());
var chosenPackage = packageManager.CreatePackage(packages[choice]);
Console.WriteLine($"You have chosen the {chosenPackage.Name} package, which includes the following services:");
Console.WriteLine(chosenPackage);
var additionalServices = serviceFactory.Services.Where(s => !chosenPackage.Services.Select(x=>x.Name).Contains(s.Name)).ToList();
var upgradedPackage = chosenPackage.CustomizeService(additionalServices);
Console.WriteLine(upgradedPackage);
Console.ReadLine();

