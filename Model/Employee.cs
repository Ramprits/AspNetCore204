using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AspNetCoreApplication.Model {
    public class Employee {
        [Key]
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Column (Order = 2)]
        public string Mobile { get; set; }

    }
}