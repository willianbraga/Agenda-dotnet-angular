using System;

namespace Agenda.Domain.Entities
{
    public class AgendaItem : Entity
    {

        public AgendaItem(string title, DateTime date, string user)
        {
            this.Title = title;
            this.Done = false;
            this.Date = date;
            this.User = user;
        }
        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }
        public string Hour { get; set; }

        public void MarkAsDone()
        {
            this.Done = true;
        }
        public void MarkAsUndone()
        {
            this.Done = false;
        }
        public void UpdateTitle(string title)
        {
            this.Title = title;
        }
    }
}