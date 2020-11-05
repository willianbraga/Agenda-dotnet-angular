using System;
using System.Linq.Expressions;
using Agenda.Domain.Entities;

namespace Agenda.Domain.Queries
{
    public class AgendaQueries
    {
        public static Expression<Func<AgendaItem, bool>> GetAll(string user)
        {
            return x => x.User == user;
        }
        public static Expression<Func<AgendaItem, bool>> GetAllDone(string user)
        {
            return x => x.User == user && x.Done == true;
        }
        public static Expression<Func<AgendaItem, bool>> GetAllUndone(string user)
        {
            return x => x.User == user && x.Done == false;
        }
        public static Expression<Func<AgendaItem, bool>> GetByPeriod(string user, DateTime date, bool done)
        {
            return x =>
                x.User == user &&
                x.Date== date &&
                x.Done == done;
        }
        public static Expression<Func<AgendaItem, bool>> GetById(string user, Guid id)
        {
            return x => x.User == user && x.Id == id;
        }
    }
}