using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreApplication.Model {
    [Table ("Organization", Schema = "dbo")]
    public class Organization : ModelEntity {
        [Key]
        public Guid OrganizationId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Training> Training { get; set; }
    }
}