namespace Seldat.Amuta.Dto
{
  public  class BranchProcedureDto
    {
        public int BranchId { get; set; }
        public int MaximumLateness { get; set; }
        public int MaximumAbsences { get; set; }
        public bool IsRequiredExams { get; set; }
        public int ExamsPerPeriod { get; set; }
        public string ExamsPeriod { get; set; }
    }

}
