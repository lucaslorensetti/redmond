using System.Threading.Tasks;

namespace Redmond.SharedKernel.Interfaces
{
    public interface IQueryHandler<TFilter, TResult>
        where TFilter : IQuery
    {
        Task<TResult> HandleAsync(TFilter filter);
    }
}
