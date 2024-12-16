using source.Models.Interfaces;
using source.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Serrvices
{
    public class VoiceService : BaseEntity, IService
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int MinutesIncluded { get; set; }

        public object Clone()
        {
            var clone = (VoiceService)this.MemberwiseClone();
            clone.Id = Guid.NewGuid();
            return clone;
        }

        public void Configure(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MinutesIncluded"))
                MinutesIncluded = (int)parameters["MinutesIncluded"];
            if (parameters.ContainsKey("Price"))
                Price = Convert.ToSingle(parameters["Price"]);
        }
    }

}
