using source.Models.Interfaces;
using source.Models.Models;

namespace source.Services
{
    public class VoiceServicePrototype : BaseEntity, IService
    {
        public int MinutesIncluded { get; set; }

        public object Clone()
        {
            var clone = (VoiceServicePrototype)this.MemberwiseClone();
            clone.Id = Guid.NewGuid();
            return clone;
        }

        public void Configure(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("MinutesIncluded"))
                MinutesIncluded = (int)parameters["MinutesIncluded"];
        }
    }

}
