using System;

namespace Seldat.Amuta.Entities
{
    public class Attendance
    {
        //TODO how to use it-according to db
        public enum AttendanceType
        {
            Regular,
            Late,
            Absence
        }

        public int Id { get; set; }
        public Student Student { get; set; }
        public Branch branch { get; set; }
        public DateTime Time { get; set; }
        public bool IsStart { get; set; }
        public AttendanceType? Type { get; set; }
        public string Reason { get; set; }
        public int UserLoggedId { get; set; }
        public DateTime TimeLogged { get; set; }
        public bool? IsApproved { get; set; }
        public string UserApprovedId { get; set; }
        public Device Device { get; set; }
        public string LocationDevice { get; set; }
        public bool IsActive { get; set; }

        public bool IsValid()
        {
            //do with func or annotations?
            //and custom annotation to reason for example that required just if it is late or missing
            if (Student != null && branch != null && isValidTime())
                return true;
            return true;
        }

        private bool isValidTime()
        {
            throw new NotImplementedException();
        }
    }
}
