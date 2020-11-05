using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Entities;

namespace Agenda.Domain.Tests.EntityTests
{
    [TestClass]
    public class AgendaItemTests
    {
        private readonly AgendaItem _Agenda = new AgendaItem("Nova Tarefa", DateTime.Now, "Willian");

        [TestMethod]
        public void Given_a_new_Agenda_it_must_be_undone()
        {
            Assert.AreEqual(_Agenda.Done, false);
        }
    }
}

