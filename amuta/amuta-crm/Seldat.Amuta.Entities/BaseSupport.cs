using System;

namespace Seldat.Amuta.Entities
{
   public abstract class BaseSupport
    {    
        public int Id { get; set; }
        public Student Student { get; set; }
        public Branch branch { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public bool? IsApproved { get; set; }
        public RequestStatus CurrentStatus { get; set; }
        public bool? Iscanceled { get; set; }
    }
}
