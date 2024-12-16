using source.Models.Interfaces;
using source.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Serrvices
{
    public class RoamingService : BaseEntity, IService
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int RoamingIncluded { get; set; }

        public object Clone()
        {
            var clone = (RoamingService)this.MemberwiseClone();
            clone.Id = Guid.NewGuid();
            return clone;
        }

        public void Configure(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("RoamingIncluded"))
                RoamingIncluded = (int)parameters["RoamingIncluded"];
            if (parameters.ContainsKey("Price"))
                Price = Convert.ToSingle(parameters["Price"]);
        }
    }
}
