using LounasRavintola.Models;

namespace LounasRavintola.Services
{
    public interface IWeekMenuService
    {
        Task AddMenuAsync(WeekMenu menu);
        Task EditMenuAsync(WeekMenu menu);
        Task<WeekMenu> GetMostRecentMenuAsync();
        Task<WeekMenu?> GetNextWeekMenuAsync(DateTime date);
        Task<WeekMenu?> GetPreviousWeekMenuAsync(DateTime date);
        Task<List<WeekMenu>> GetWeekMenusAsync();
        Task RemoveMenu(WeekMenu menu);
    }
}