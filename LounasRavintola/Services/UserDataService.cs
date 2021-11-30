using LounasRavintola.Areas.Identity.Data;
using LounasRavintola.Data;
using Microsoft.EntityFrameworkCore;

namespace LounasRavintola.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly UserContext _context;

        public UserDataService(UserContext context)
        {
            _context = context;
        }

        public async Task<List<LounasRavintolaUser>> GetLounasRavintolaUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<LounasRavintolaUser> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userName);
        }

        public async Task UpdateUser(LounasRavintolaUser user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(LounasRavintolaUser user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

    }
}
