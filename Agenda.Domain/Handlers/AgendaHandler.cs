
using Flunt.Notifications;
using Agenda.Domain.Commands;
using Agenda.Domain.Commands.Contracts;
using Agenda.Domain.Entities;
using Agenda.Domain.Handlers.Contracts;
using Agenda.Domain.Repositories;

namespace Agenda.Domain.Handlers
{
    public class AgendaHandler : 
            Notifiable, 
            IHandler<CreateAgendaCommand>, 
            IHandler<UpdateAgendaCommand>, 
            IHandler<MarkAgendaAsDoneCommand>, 
            IHandler<MarkAgendaAsUndoneCommand>
    {
        private readonly IAgendaRepository _repository;

        public AgendaHandler(IAgendaRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateAgendaCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult("Opa, temos um erro aqui, por favor verifique", false, command.Notifications);
            }

            var Agenda = new AgendaItem(command.Title, command.Date, command.User);

            _repository.Create(Agenda);

            return new GenericCommandResult("Salvo com sucesso", true, Agenda);
        }

        public ICommandResult Handle(UpdateAgendaCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult("Opa, temos um erro aqui, por favor verifique", false, command.Notifications);
            }

            var Agenda = _repository.GetById(command.Id, command.User);

            Agenda.UpdateTitle(command.Title);

            _repository.Update(Agenda);

            return new GenericCommandResult("Tarefa atualizada", true, Agenda);
        }

        public ICommandResult Handle(MarkAgendaAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult("Opa, temos um erro aqui, por favor verifique", false, command.Notifications);
            }

            var Agenda = _repository.GetById(command.Id, command.User);

            Agenda.MarkAsDone();

            _repository.Update(Agenda);

            return new GenericCommandResult("Tarefa atualizada", true, Agenda);
        }

        public ICommandResult Handle(MarkAgendaAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult("Opa, temos um erro aqui, por favor verifique", false, command.Notifications);
            }

            var Agenda = _repository.GetById(command.Id, command.User);

            Agenda.MarkAsUndone();

            _repository.Update(Agenda);

            return new GenericCommandResult("Tarefa atualizada", true, Agenda);
        }
    }
}