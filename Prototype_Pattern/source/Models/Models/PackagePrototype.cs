using source.Models.Interfaces;
using source.Util;

namespace source.Models.Models
{
    public class PackagePrototype : BaseEntity, ICloneable
    {
        public double Price => Services.Sum(service => service.Price);
        public List<IService> Services { get; set; }

        public PackagePrototype() { 
            Services = new List<IService>();
        }

        public PackagePrototype(string name)
        {
            Name = name;
            Services = new List<IService>();
        }

        public object Clone()
        {
            PackagePrototype clone = (PackagePrototype)this.MemberwiseClone();
            clone.Id = Guid.NewGuid();
            clone.Services = new List<IService>();
            foreach (var service in Services)
            {
                clone.Services.Add((IService)service.Clone());
            }
            return clone;
        }

        public void AddService(IService service)
        {
            Services.Add(service);
        }

        public PackagePrototype CustomizeService(List<IService> services)
        {
            var newPackage = (PackagePrototype)Clone();
            while (true)
            {
                var response = InputValidator.GetYesOrNoInput("Would you like to customize your package? (y/n)");
                if (response == "n")
                {
                    Console.WriteLine("Package customization complete.");
                    break;
                }

                var serviceParts = services.Select(x => $"{services.IndexOf(x) + 1}: {x.Name}");
                var promptMessage = "Which service would you like to add or replace?\n0: None | " + string.Join(" | ", serviceParts);

                var choice = InputValidator.GetValidChoice(promptMessage, 0, services.Count);
                if (choice == 0)
                {
                    Console.WriteLine("No changes made to the package.");
                    continue;
                }

                choice--;
                var selectedService = services[choice];

                var nameParts = selectedService.Name.Split(' ');
                var packageType = nameParts.Length > 1 ? nameParts[1] : string.Empty;

                var existingService = newPackage.Services.FirstOrDefault(x => x.Name.EndsWith(packageType));
                if (existingService != null)
                {
                    newPackage.Services.Remove(existingService);
                }

                newPackage.AddService(selectedService);
                newPackage.AdjustPackageName();

                Console.WriteLine($"Added {selectedService.Name} to your package.");

                Console.WriteLine("Updated package details:");
                Console.WriteLine(newPackage);
            }

            return newPackage;
        }

        private void AdjustPackageName()
        {
            var defaultPackage = Name.Split(" + ")[0];
            var serviceParts = Services.Select(x => x.Name).Where(x => !x.StartsWith(defaultPackage));
            Name = $"{defaultPackage} + {String.Join(" + ", serviceParts)}";
        }

        public void ConfigureService(string serviceName, Dictionary<string, object> parameters)
        {
            var service = Services.FirstOrDefault(s => s.Name == serviceName);
            if (service != null) 
            {
                service.Configure(parameters);
            }
        }

        public override string ToString()
        {
            var parts = new List<string>();
            parts.Add($"--- {Name} ---");
            double totalPrice = Price;
            foreach (var service in Services)
            {
                var props = service.GetType().GetProperties()
                    .Where(x => x.Name != "Name" && x.Name != "Id")
                    .Select(x => $"{x.Name}: {x.GetValue(service)}");
                parts.Add($"{service.Name}:\n  {string.Join("\n  ", props)}");
            }
            parts.Add($"*** Total Package Price: {totalPrice}");
            return string.Join("\n", parts);
        }

    }
}
