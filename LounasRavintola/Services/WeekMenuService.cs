using LounasRavintola.Data;
using LounasRavintola.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LounasRavintola.Services
{
    public class WeekMenuService : IWeekMenuService
    {
        private readonly WeekMenuContext _context;

        public WeekMenuService(WeekMenuContext context)
        {
            _context = context;
        }

        private async Task<List<MenuItem>> PopulateMenu(WeekMenu menu)
        {
           return await _context.MenuItems.Where(item => item.WeekMenuForeignKey.Equals(menu.Id)).ToListAsync();
        }


        public async Task<WeekMenu> GetMostRecentMenuAsync()
        {
            List<WeekMenu> Menus = await _context.WeekMenus.ToListAsync();

            if (Menus.Count == 0)
                return new WeekMenu();

            WeekMenu mostRecent = Menus.First();
            foreach (WeekMenu item in Menus)
            {
                if (item.StartDate > mostRecent.EndDate)
                    mostRecent = item;
            }

            mostRecent.MenuItems = await PopulateMenu(mostRecent);

            return mostRecent;
        }

        public async Task<WeekMenu?> GetPreviousWeekMenuAsync(DateTime date)
        {
            //return await _context.WeekMenus.FirstOrDefaultAsync(m => GetWeekNumber(m.StartDate) - 1 == GetWeekNumber(date));
            List<WeekMenu> Menus = await _context.WeekMenus.ToListAsync();
            foreach (WeekMenu item in Menus)
            {
                if (GetWeekNumber(item.StartDate) == GetWeekNumber(date) -1)
                {
                    item.MenuItems = await PopulateMenu(item);
                    return item;
                }
                    
            }
            return null;
        }

        public async Task<WeekMenu?> GetNextWeekMenuAsync (DateTime date)
        {
            //return await _context.WeekMenus.FirstOrDefaultAsync(m => GetWeekNumber(m.StartDate) + 1 == GetWeekNumber(date));
            List<WeekMenu> Menus = await _context.WeekMenus.ToListAsync();
            foreach (WeekMenu item in Menus)
            {
                if (GetWeekNumber(item.EndDate) == GetWeekNumber(date) + 1)
                {
                    item.MenuItems = await PopulateMenu(item);
                    return item;
                }
                    
            }
            return null;
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

        private int GetWeekNumber(DateTime date)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

    }
}
