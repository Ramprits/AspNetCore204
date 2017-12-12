using System;

namespace AspNetCoreApplication.ModelDto {
    public class CampaignForCreationDto {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaximumWishes { get; set; }
        public bool IsActive { get; set; }
        public bool IsClose { get; set; }
        public bool UserLock { get; set; }
        public bool ManagerLock { get; set; }
    }
}