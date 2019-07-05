namespace Seldat.Amuta.Entities
{
  public  class StudentExam
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public BranchExam branchExam { get; set; }
        public decimal? Grade { get; set; }
    }
}
