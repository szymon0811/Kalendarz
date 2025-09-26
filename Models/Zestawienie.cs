namespace Kalendarz.Models
{
    public class Zestawienie
    {
        public int Id { get; set; }
        public int IdKierowcy {  get; set; }
        public Kierowca Kierowca { get; set; }
        public int IdToru { get; set; }
        public Tor Tor { get; set; }
        public TimeSpan Czas { get; set; }
    }
}
