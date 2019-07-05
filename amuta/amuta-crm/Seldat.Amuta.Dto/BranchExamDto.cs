namespace Seldat.Amuta.Dto
{
    public class BranchExamDto
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int FailingSumbitExamScholarshipAddition { get; set; }
        public int FailingSumbitExamScholarshipReducing { get; set; }
        public int NotPassedExamScholarshipAddition { get; set; }
        public int NotPassedExamScholarshipReducing { get; set; }
        public decimal PassGrade { get; set; }
        public string Subject { get; set; }
    }
}