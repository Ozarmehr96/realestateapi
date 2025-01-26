using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.Users.Models;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Users
{
    public interface IUsersRepository : IRepository
    {
        /// <summary>
        /// Сохранение пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<UserModel> Save(UserModel user);

        /// <summary>
        /// Получение пользователя по номеру телефона.
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<UserModel> GetUserByPhone(string phone);
    }
}
