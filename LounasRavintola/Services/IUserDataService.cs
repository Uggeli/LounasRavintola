using LounasRavintola.Areas.Identity.Data;

namespace LounasRavintola.Services
{
    public interface IUserDataService
    {
        Task DeleteUser(LounasRavintolaUser user);
        Task<List<LounasRavintolaUser>> GetLounasRavintolaUsers();
        Task<LounasRavintolaUser> GetUserByUserNameAsync(string userName);
        Task UpdateUser(LounasRavintolaUser user);
    }
}