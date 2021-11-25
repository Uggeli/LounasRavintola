using System.ComponentModel.DataAnnotations.Schema;

namespace LounasRavintola.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int WeekDay { get; set; }
        public string? Title { get; set; } = null;
        public string Notes { get; set; } = "";
        public bool V { get; set; }
        public bool G { get; set; }
        public bool L { get; set; }

        public int WeekMenuForeignKey { get; set; }
        [ForeignKey("WeekMenuForeignKey")]
        public WeekMenu WeekMenu { get; set; }
    }
}
