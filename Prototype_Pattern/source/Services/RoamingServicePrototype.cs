using source.Models.Interfaces;
using source.Models.Models;

namespace source.Services
{
    public class RoamingServicePrototype : BaseEntity, IService
    {
        public int RoamingMinutesIncluded { get; set; }
        public int RoamingSMSIncluded { get; set; }
        public int RoamingDataLimitGB { get; set; }

        public object Clone()
        {
            var clone = (RoamingServicePrototype)this.MemberwiseClone();
            clone.Id = Guid.NewGuid();
            return clone;
        }

        public void Configure(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("RoamingMinutesIncluded"))
                RoamingMinutesIncluded = (int)parameters["RoamingMinutesIncluded"];
            if (parameters.ContainsKey("RoamingSMSIncluded"))
                RoamingMinutesIncluded = (int)parameters["RoamingSMSIncluded"];
            if (parameters.ContainsKey("RoamingDataLimitGB"))
                RoamingMinutesIncluded = (int)parameters["RoamingDataLimitGB"];
        }
    }
}
