using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreApplication.Model {
    public class BusinessUnit : ModelEntity {
        [Key]
        public Guid BusinessUnitId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Training> Training { get; set; }
    }
}