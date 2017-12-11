using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreApplication.Model {
    public class Employee {
        [Key]
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

    }
}