namespace Kalendarz.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start {  get; set; }
        public DateTime End {  get; set; }
        public string Description { get; set; }
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public int Priority { get; set; }
    }
}
