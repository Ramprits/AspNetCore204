using System;

namespace AspNetCoreApplication.Model {
    public class ModelEntity {
        public byte[] RowVersion { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}