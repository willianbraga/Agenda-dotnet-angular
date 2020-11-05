using System;
using Flunt.Notifications;
using Flunt.Validations;
using Agenda.Domain.Commands.Contracts;

namespace Agenda.Domain.Commands
{
    public class UpdateAgendaCommand : Notifiable, ICommand
    {
        public UpdateAgendaCommand(){ }

        public UpdateAgendaCommand(Guid id, string title, string user)
        {
            this.Id = id;
            this.Title = title;
            this.User = user;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor sua atividade")
                .HasMinLen(User, 6, "User", "Usuario invalido")
            );
        }
    }
}