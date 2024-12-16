using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Models.Interfaces
{
    public interface IService : ICloneable
    {
        string Name { get; set; }
        float Price { get; set; }
        void Configure(Dictionary<string, object> parameters);
    }
}
