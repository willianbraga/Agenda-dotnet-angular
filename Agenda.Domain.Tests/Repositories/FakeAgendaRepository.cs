using System;
using System.Collections.Generic;
using Agenda.Domain.Entities;
using Agenda.Domain.Repositories;

namespace Agenda.Domain.Tests.Repositories
{
    public class FakeAgendaRepository : IAgendaRepository
    {
        public void Create(AgendaItem agenda)
        {
        }

        public IEnumerable<AgendaItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgendaItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AgendaItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public AgendaItem GetById(Guid id, string user)
        {
            return new AgendaItem("Titulo do GetById",DateTime.Now, "Willian Braga");
        }

        public IEnumerable<AgendaItem> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(AgendaItem Agenda)
        {
            
        }
    }
}