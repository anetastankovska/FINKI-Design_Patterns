using source.Models.Interfaces;
using source.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Serrvices
{
    public class DataService : BaseEntity, IService
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int DataLimitGB { get; set; }

        public object Clone()
        {
            var clone = (DataService)this.MemberwiseClone();
            clone.Id = Guid.NewGuid();
            return clone;
        }

        public void Configure(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DataLimitGB"))
                DataLimitGB = (int)parameters["DataLimitGB"];
            if (parameters.ContainsKey("Price"))
                Price = Convert.ToSingle(parameters["Price"]);
        }
    }
}
