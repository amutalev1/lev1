using System;


namespace Seldat.Amuta.Dto
{
   public class BranchActivityHoursDto
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public TimeSpan LateHour { get; set; }
        public TimeSpan StartStudyHours { get; set; }
        public TimeSpan EndStudyHours { get; set; }

    }
}
