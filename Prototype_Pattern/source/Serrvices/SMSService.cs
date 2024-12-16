using source.Models.Interfaces;
using source.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Serrvices
{
    public class SMSService : BaseEntity, IService
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int SMSIncluded { get; set; }

        public object Clone()
        {
            var clone = (SMSService)this.MemberwiseClone();
            clone.Id = Guid.NewGuid();
            return clone;
        }

        public void Configure(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("SMSIncluded"))
                SMSIncluded = (int)parameters["SMSIncluded"];
            if (parameters.ContainsKey("Price"))
                Price = Convert.ToSingle(parameters["Price"]);
        }
    }
}
