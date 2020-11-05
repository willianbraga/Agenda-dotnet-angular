using System;
using System.Collections.Generic;
using Agenda.Domain.Entities;

namespace Agenda.Domain.Repositories
{
    public interface IAgendaRepository
    {
         void Create(AgendaItem Agenda);
         void Update(AgendaItem Agenda);
         AgendaItem GetById(Guid id, string user);
         IEnumerable<AgendaItem> GetAll(string user);
         IEnumerable<AgendaItem> GetAllDone(string user);
         IEnumerable<AgendaItem> GetAllUndone(string user);
         IEnumerable<AgendaItem> GetByPeriod(string user,DateTime date, bool done);
    }
}