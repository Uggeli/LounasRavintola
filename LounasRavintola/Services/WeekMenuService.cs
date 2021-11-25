using LounasRavintola.Data;
using LounasRavintola.Models;
using Microsoft.EntityFrameworkCore;

namespace LounasRavintola.Services
{
    public class WeekMenuService : IWeekMenuService
    {
        private readonly WeekMenuContext _context;

        public WeekMenuService(WeekMenuContext context)
        {
            _context = context;
        }


        public async Task<WeekMenu> GetMostRecentMenuAsync()
        {
            List<WeekMenu> Menus = await _context.WeekMenus.ToListAsync();

            System.Console.WriteLine(Menus.Count);
            if (Menus.Count == 0)
                return new WeekMenu();

            WeekMenu mostRecent = Menus.First();
            foreach (WeekMenu item in Menus)
            {
                if (item.Date > mostRecent.Date)
                    mostRecent = item;
            }

            mostRecent.MenuItems = await _context.MenuItems
                .Where(item => item.WeekMenuForeignKey
                .Equals(mostRecent.Id))
                .ToListAsync();

            return mostRecent;
        }

        public async Task<List<WeekMenu>> GetWeekMenusAsync()
        {
            return await _context.WeekMenus.ToListAsync();
        }

        public async Task AddMenuAsync(WeekMenu menu)
        {
            await _context.WeekMenus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveMenu(WeekMenu menu)
        {
            _context.WeekMenus.Remove(menu);
            await _context.SaveChangesAsync();
        }

        public async Task EditMenuAsync(WeekMenu menu)
        {
            _context.WeekMenus.Update(menu);
            await _context.SaveChangesAsync();

        }

    }
}
