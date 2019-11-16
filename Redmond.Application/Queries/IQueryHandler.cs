using Redmond.Domain.Queries;
using System.Threading.Tasks;

namespace Redmond.Application.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
