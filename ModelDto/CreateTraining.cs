using System;

namespace AspNetCoreApplication.ModelDto {
    public class CreateTraining {
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
        public Guid ModalityId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CategoryId { get; set; }
    }
}