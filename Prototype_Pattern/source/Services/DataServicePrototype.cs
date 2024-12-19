using source.Models.Interfaces;
using source.Models.Models;

namespace source.Services
{
    public class DataServicePrototype : BaseEntity, IService
    {
        public int DataLimitGB { get; set; }
        public double DownloadSpeedMbps { get; set; }
        public double UploadSpeedMbps { get; set; }

        public object Clone()
        {
            var clone = (DataServicePrototype)this.MemberwiseClone();
            clone.Id = Guid.NewGuid();
            return clone;
        }

        public void Configure(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("DataLimitGB"))
                DataLimitGB = (int)parameters["DataLimitGB"];
            if (parameters.ContainsKey("DownloadSpeedMbps"))
                DownloadSpeedMbps = (int)parameters["DownloadSpeedMbps"];
            if (parameters.ContainsKey("UploadSpeedMbps"))
                UploadSpeedMbps = (int)parameters["UploadSpeedMbps"];
        }
    }
}
