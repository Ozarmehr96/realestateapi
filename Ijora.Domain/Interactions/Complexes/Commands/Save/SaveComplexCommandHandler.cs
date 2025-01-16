using Ijora.Domain.Interactions.Complexes.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ijora.Domain.Interactions.Complexes.Commands.Save
{
    /// <summary>
    /// Обработчик сохранения ЖК (жилого комплекса).
    /// </summary>
    public class SaveComplexCommandHandler : IRequestHandler<SaveComplexCommand, ComplexModel>
    {
        public Task<ComplexModel> Handle(SaveComplexCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
