using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreApplication.Model {

    [Table ("Campaign", Schema = "dbo")]
    public class Campaign : ModelEntity {

        [Key]
        public Guid CampaignId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public int MaximumWishes { get; set; }
        public DateTime Year { get; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
        public bool IsClose { get; set; }
        public bool UserLock { get; set; }
        public bool ManagerLock { get; set; }

    }
}