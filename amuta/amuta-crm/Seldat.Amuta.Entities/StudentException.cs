namespace Seldat.Amuta.Entities
{
   public class StudentException
    {
        public enum ExceptionType
        {
            Arrival,
            Exit
        }

        public int Id { get; set; }
        public Student Student { get; set; }
        public Branch Intitution { get; set; }
        public ExceptionType Type { get; set; }
        public string value { get; set; }
    }
}
