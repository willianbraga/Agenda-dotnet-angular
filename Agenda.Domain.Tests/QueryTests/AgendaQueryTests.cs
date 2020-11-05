using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Entities;
using Agenda.Domain.Queries;

namespace Agenda.Domain.Tests.QueryTests
{
    [TestClass]
    public class AgendaQueryTests
    {
        private readonly List<AgendaItem> _items;
        public AgendaQueryTests()
        {
            _items = new List<AgendaItem>
            {
                new AgendaItem("Tarefa 1", DateTime.Now, "Usuario 1"),
                new AgendaItem("Tarefa 2", DateTime.Now, "willian"),
                new AgendaItem("Tarefa 3", DateTime.Now, "Usuario 1"),
                new AgendaItem("Tarefa 4", DateTime.Now, "Usuario 1"),
                new AgendaItem("Tarefa 5", DateTime.Now, "willian")
            };
        }
        [TestMethod]
        public void Should_return_only_Agenda_of_willian()
        {
            var result = _items.AsQueryable().Where(AgendaQueries.GetAll("willian"));
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Should_return_only_Agenda_done_of_willian()
        {
            var result = _items.AsQueryable().Where(AgendaQueries.GetAllDone("willian"));
            Assert.AreEqual(0, result.Count());
        }
        [TestMethod]
        public void Should_return_only_Agenda_undone_of_willian()
        {
            var result = _items.AsQueryable().Where(AgendaQueries.GetAllUndone("willian"));
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Should_return_only_Agenda_of_a_day_undone()
        {
            var result = _items.AsQueryable().Where(AgendaQueries.GetByPeriod("willian", DateTime.Now, false));
            Assert.AreEqual(2, result.Count());
        }
        [TestMethod]
        public void Should_return_only_Agenda_of_a_day_done()
        {
            var result = _items.AsQueryable().Where(AgendaQueries.GetByPeriod("willian", DateTime.Now, true));
            Assert.AreEqual(0, result.Count());
        }
        [TestMethod]
        public void Should_return_only_Agenda_an_id()
        {

        }
    }
}