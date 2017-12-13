using System;
using System.Collections.Generic;
using AspNetCoreApplication.Model;

namespace AspNetCoreApplication.ModelDto {
    public class CategoriesVm {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Training> Trainings { get; set; }

    }
}