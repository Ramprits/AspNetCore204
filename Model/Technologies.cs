using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreApplication.Model {
    public class Technologies {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid ();
        public string Name { get; set; }
    }
}