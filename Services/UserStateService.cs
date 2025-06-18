using EventEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventEase.Services
{
    public class UserStateService
    {
        private List<EventRegistration> _registeredEvents = new List<EventRegistration>();
        
        public event Action OnChange;
        
        public IReadOnlyList<EventRegistration> RegisteredEvents => _registeredEvents.AsReadOnly();
        
        public void RegisterForEvent(int eventId, string eventName)
        {
            if (!_registeredEvents.Any(r => r.EventId == eventId))
            {
                _registeredEvents.Add(new EventRegistration
                {
                    EventId = eventId,
                    EventName = eventName,
                    RegistrationDate = DateTime.Now
                });
                
                NotifyStateChanged();
            }
        }
        
        public void MarkAttendance(int eventId)
        {
            var registration = _registeredEvents
                .FirstOrDefault(r => r.EventId == eventId);
                
            registration.HasAttended = true;
            NotifyStateChanged();
        }
        
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}