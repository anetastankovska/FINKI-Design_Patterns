using source.Models.Interfaces;
using source.Models.Models;

namespace source.Services
{
    public class SMSServicePrototype : BaseEntity, IService
    {
        public int SMSIncluded { get; set; }
        public int MMSIncluded { get; set; }

        public object Clone()
        {
            var clone = (SMSServicePrototype)this.MemberwiseClone();
            clone.Id = Guid.NewGuid();
            return clone;
        }

        public void Configure(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("SMSIncluded"))
                SMSIncluded = (int)parameters["SMSIncluded"];
            if (parameters.ContainsKey("MMSIncluded"))
                MMSIncluded = (int)parameters["MMSIncluded"];
        }
    }
}

