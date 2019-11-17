using Redmond.SharedKernel.Dtos;
using System.Threading.Tasks;

namespace Redmond.SharedKernel.Interfaces
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task<OperationResult> HandleAsync(TCommand command);
    }
}
