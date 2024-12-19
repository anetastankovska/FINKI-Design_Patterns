using source.Models.Interfaces;

namespace source.Services
{
    internal class ServiceFactory
    {
        public List<IService> Services { get; }
        public ServiceFactory() { Services = new List<IService>(); }
        public IService FindAndClone(string name)
        {
            return (IService)Services.FirstOrDefault(x => x.Name == name).Clone();
        }

        public void PopulateServices()
        {
            // create service prototypes
            // Voice packages
            Services.Add(new VoiceServicePrototype { Name = "Standard Voice", Price = 300, MinutesIncluded = 300 });
            Services.Add(new VoiceServicePrototype { Name = "Optimum Voice", Price = 400, MinutesIncluded = 500 });
            Services.Add(new VoiceServicePrototype { Name = "Premium Voice", Price = 600, MinutesIncluded = 1000 });

            // SMS packages
            Services.Add(new SMSServicePrototype { Name = "Standard SMS", Price = 200, SMSIncluded = 100, MMSIncluded = 30 });
            Services.Add(new SMSServicePrototype { Name = "Optimum SMS", Price = 300, SMSIncluded = 200, MMSIncluded = 50 });
            Services.Add(new SMSServicePrototype { Name = "Premium SMS", Price = 400, SMSIncluded = 500, MMSIncluded = 100 });

            // Data packages
            Services.Add(new DataServicePrototype { Name = "Optimum Data", Price = 300, DataLimitGB = 30, DownloadSpeedMbps = 50, UploadSpeedMbps = 10 });
            Services.Add(new DataServicePrototype { Name = "Premium Data", Price = 500, DataLimitGB = 100, DownloadSpeedMbps = 100, UploadSpeedMbps = 50 });

            // Roaming packages
            Services.Add(new RoamingServicePrototype { Name = "Premium Roaming", Price = 500, RoamingMinutesIncluded = 100, RoamingSMSIncluded = 30, RoamingDataLimitGB = 5 });
        }
    }
}
