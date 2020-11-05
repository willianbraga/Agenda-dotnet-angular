using Agenda.Domain.Commands;
using Agenda.Domain.Commands.Contracts;

namespace Agenda.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}