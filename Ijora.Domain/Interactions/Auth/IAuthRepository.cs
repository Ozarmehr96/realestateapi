using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.Auth.Models;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Auth
{
    public interface IAuthRepository : IRepository
    {
        /// <summary>
        /// Сохранение.
        /// </summary>
        /// <param name="authAccessModel"></param>
        /// <returns></returns>
        Task<AuthAccessModel> Save(AuthAccessModel authAccessModel);

        /// <summary>
        /// Получение.
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="otp"></param>
        /// <returns></returns>
        Task<AuthAccessModel> Get(string phone, string otp);

        /// <summary>
        /// Получение данных по токену.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<AuthAccessModel> GetByToken(string token);


        /// <summary>
        /// Получение данных по токену обновлния.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<AuthAccessModel> GetByRefreshToken(string token);

        /// <summary>
        /// Получение по номеру телефона.
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<AuthAccessModel> Get(string phone);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Remove(long id);
    }
}
