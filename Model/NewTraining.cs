using System;
using System.Collections.Generic;

namespace AspNetCoreApplication.Model {
    public class NewTraining {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Guid TechnologyId { get; set; }

        public ICollection<Technologies> Technologies { get; set; } = new List<Technologies> ();

    }
}