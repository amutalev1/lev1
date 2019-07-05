namespace Seldat.Amuta.Entities
{
    public class BranchExam
    {
        public int Id { get; set; }
        public Branch Branch { get; set; }
        public int SumbitExamScholarshipAddition { get; set; }
        public int FailingSumbitExamScholarshipReducing { get; set; }
        public int PassedExamScholarshipAddition { get; set; }
        public int NotPassedExamScholarshipReducing { get; set; }
        public decimal PassGrade { get; set; }
        public string Subject { get; set; }
    }
}