using source.Models.Models;

namespace source.Services
{
    public class PackageManager
    {
        private Dictionary<string, PackagePrototype> _packagePrototypes;

        public PackageManager()
        {
            _packagePrototypes = new Dictionary<string, PackagePrototype>();
        }

        public void RegisterPackage(string name, PackagePrototype prototype)
        {
            _packagePrototypes[name] = prototype;
        }

        public PackagePrototype CreatePackage(string name)
        {
            if (_packagePrototypes.ContainsKey(name))
            {
                return (PackagePrototype)_packagePrototypes[name].Clone();
            }
            throw new ArgumentException($"Package '{name}' not found.");
        }

        public List<string> ListPackageNames()
        {
            for (int i = 0; i < _packagePrototypes.Count; i++)
            {
                Console.WriteLine($"{i}: {_packagePrototypes.Keys.ElementAt(i)}");
            }
            return _packagePrototypes.Keys.ToList();
        }


        public PackagePrototype CreateCustomPackage(string baseName)
        {
            var basePackage = CreatePackage(baseName);
            basePackage.Name += " (Custom)";
            return basePackage;
        }
    }

}
