using Redmond.Application.Dtos;
using Redmond.Domain.Commands;
using System.Threading.Tasks;

namespace Redmond.Application.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task<CommandResult> HandleAsync(TCommand command);
    }
}
