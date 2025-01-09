using MediatR;

namespace Ijora.Domain.Interactions.Properties.Queries.GetProperty
{
    public class GetPropertyQuery : IRequest<int>
    {
        public GetPropertyQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
