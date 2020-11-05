using System;
using Flunt.Notifications;
using Flunt.Validations;
using Agenda.Domain.Commands.Contracts;

namespace Agenda.Domain.Commands
{
    public class CreateAgendaCommand : Notifiable, ICommand
    {
        public CreateAgendaCommand() { }

        public CreateAgendaCommand(string title, string user, DateTime date)
        {
            this.Title = title;
            this.User = user;
            this.Date = date;
        }

        public string Title { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }

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