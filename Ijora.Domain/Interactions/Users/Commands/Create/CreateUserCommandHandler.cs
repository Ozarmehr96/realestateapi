using Ijora.Domain.Infrastructure;
using Ijora.Domain.Interactions.Users.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Users.Commands.Create
{
    /// <summary>
    /// Создание пользователя.
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserModel>
    {
        private readonly IUsersRepository _usersRepository;
        public CreateUserCommandHandler(IRepositoryProvider provider)
        {
            _usersRepository = provider.GetRepository<IUsersRepository>();
        }

        public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _usersRepository.GetUserByPhone(request.PhoneNumber);
            if (user != null)
            {
                user.LastAuthDate = DateTime.Now;
                return await _usersRepository.Save(user);
            }

            user = new UserModel
            {
                UserId = Guid.NewGuid(),
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                LastAuthDate = DateTime.Now,
                RegistrationDateTime = DateTime.Now,
                Role = request.Role
            };
            return await _usersRepository.Save(user);
        }
    }
}
