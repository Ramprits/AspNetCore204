using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreApplication.Model {
    [Table ("Training", Schema = "dbo")]
    public class Training : ModelEntity {
        [Key]
        public Guid TrainingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsFree { get; set; }
        public DateTime StartDate { get; set; }
        public decimal AverageCost { get; set; }
        public string ConcernedPublic { get; set; }
        public string EducationalObjectives { get; set; }
        public string OthersEducationalObjectives { get; set; }
        public int DurationInDays { get; set; }
        public string Location { get; set; }
        public string ExternalLinks { get; set; }
        public string Language { get; set; }
        public bool IsApproved { get; set; }
        public string IsCPF { get; set; }
        public Guid BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public Guid ModalityId { get; set; }
        public Modality Modality { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }

    }
}