namespace AspNetCoreApplication.ModelDto {
    public class TrainingVm {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsFree { get; set; }
        public decimal AverageCost { get; set; }
        public string ConcernedPublic { get; set; }
    }
}