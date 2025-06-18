using EventEase.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventEase.Services
{
    public class EventService
    {
        // In a real app, this would come from a database
        private List<EventModel> _events = new List<EventModel>();
        private int _nextEventId = 1;
        // Method to get events
        public List<EventModel> GetEvents()
        {
            return _events;
        }

        // Method to get a specific event by ID
        public EventModel GetEventById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        // Method to add an event
        public void AddEvent(EventModel eventModel)
        {
            _events.Add(eventModel);
        }
        public int GetNextId() => _nextEventId++;
    }
}