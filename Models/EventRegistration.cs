using System;

namespace EventEase.Models
{
    public class EventRegistration
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool HasAttended { get; set; }
    }
}