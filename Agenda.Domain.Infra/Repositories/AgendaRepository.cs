using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Agenda.Domain.Entities;
using Agenda.Domain.Infra.Contexts;
using Agenda.Domain.Repositories;
using Agenda.Domain.Queries;

namespace Agenda.Domain.Infra.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly DataContext _context;
        public AgendaRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(AgendaItem Agenda)
        {
            _context.Add(Agenda);
            _context.SaveChanges();
        }

        public IEnumerable<AgendaItem> GetAll(string user)
        {
            return _context.Agendas
                .AsNoTracking()
                .Where(AgendaQueries.GetAll(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<AgendaItem> GetAllDone(string user)
        {
            return _context.Agendas
                .AsNoTracking()
                .Where(AgendaQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<AgendaItem> GetAllUndone(string user)
        {
            return _context.Agendas
                .AsNoTracking()
                .Where(AgendaQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);
        }

        public AgendaItem GetById(Guid id, string user)
        {
            return _context.Agendas
                .AsNoTracking()
                .FirstOrDefault(AgendaQueries.GetById(user, id));
        }

        public IEnumerable<AgendaItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Agendas
                .AsNoTracking()
                .Where(AgendaQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }

        public void Update(AgendaItem Agenda)
        {
            _context.Entry(Agenda).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}