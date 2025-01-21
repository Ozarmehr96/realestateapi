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
        /// Удаление записи.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Remove(long id);
    }
}
