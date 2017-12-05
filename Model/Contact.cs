using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AspNetCoreApplication.Model {
    [Table ("Contact", Schema = "dbo")]
    public class Contact {
        public Guid ContactId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Comment { get; set; }
    }
}