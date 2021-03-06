using System;
using Flunt.Notifications;
using Flunt.Validations;
using Agenda.Domain.Commands.Contracts;

namespace Agenda.Domain.Commands
{
    public class MarkAgendaAsUndoneCommand : Notifiable, ICommand
    {
        public MarkAgendaAsUndoneCommand(){ }
        public MarkAgendaAsUndoneCommand(Guid id, string user)
        {
            this.Id = id;
            this.User = user;
        }
        public Guid Id { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(User,6,"User", "Usuario invalido")
            );
        }
    }
}