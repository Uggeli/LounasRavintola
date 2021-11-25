namespace LounasRavintola.Models
{
    public class WeekMenu
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public List<MenuItem>? MenuItems { get; set; } = new List<MenuItem>();
    }
}
