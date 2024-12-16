using source.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Models.Models
{
    public class PackagePrototype : BaseEntity, ICloneable
    {
        public string Name { get; set; }
        public List<IService> Services { get; set; }

        public PackagePrototype() { 
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

        public void ConfigureService(string serviceName, Dictionary<string, object> parameters)
        {
            var service = Services.FirstOrDefault(s => s.Name == serviceName);
            if (service != null) 
            {
                service.Configure(parameters);
            }
        }
    }
}
