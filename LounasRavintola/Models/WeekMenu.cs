namespace LounasRavintola.Models
{
    public class WeekMenu
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(5);

        public List<MenuItem>? MenuItems { get; set; } = new List<MenuItem>();
    }
}
