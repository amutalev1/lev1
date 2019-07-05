namespace Seldat.Amuta.Entities
{

    public enum RequestStatus
    {
        Finished,
        WaitingForMangerApproving
    }
    public class RequestProcessInfo
    {
        public enum SupportType
        {
            DentalHealth,
            Health,
        }
            public int Id { get; set; }
            public int SupportRequestId { get; set; }
            public SupportType Type { get; set; }
            public UserExtraDetails User { get; set; }
            public RequestStatus PreviousStatus { get; set; }
            public RequestStatus? NextStatus { get; set; }
            public RequestStatus CurrentStatus { get; set; }
    }

}
