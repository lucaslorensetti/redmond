using System.Threading.Tasks;
using Redmond.SharedKernel.Dtos;

namespace Redmond.SharedKernel.Interfaces
{
    public interface IDispatcher
    {
        Task<OperationResult> DoAsync(ICommand command);
        Task<T> GetAsync<T>(IQuery query);
    }
}
