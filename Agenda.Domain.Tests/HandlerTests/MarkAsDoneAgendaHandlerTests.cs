using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Commands;
using Agenda.Domain.Entities;
using Agenda.Domain.Handlers;
using Agenda.Domain.Tests.Repositories;

namespace Agenda.Domain.Tests.HandlerTests
{
    [TestClass]
    public class MarkAsDoneAgendaHandlerTests
    {
        private static readonly AgendaItem _invalidAgendaItem = new AgendaItem("Teste Invalido", DateTime.Now, "");
        private static readonly AgendaItem _validAgendaItem = new AgendaItem("Teste Valido", DateTime.Now, "Willian");
        private readonly MarkAgendaAsDoneCommand _invalidCommand = new MarkAgendaAsDoneCommand(_invalidAgendaItem.Id, _invalidAgendaItem.User);
        private readonly MarkAgendaAsDoneCommand _validCommand = new MarkAgendaAsDoneCommand(_validAgendaItem.Id, _validAgendaItem.User);
        private readonly AgendaHandler _handler = new AgendaHandler(new FakeAgendaRepository());
        private GenericCommandResult _validResult = new GenericCommandResult();
        private GenericCommandResult _invalidResult = new GenericCommandResult();

        public MarkAsDoneAgendaHandlerTests()
        {
            _invalidResult = (GenericCommandResult)_handler.Handle(_invalidCommand);
            _validResult = (GenericCommandResult)_handler.Handle(_validCommand);

        }
        [TestMethod]
        public void Given_a_invalid_command_must_stop_running()
        {
            Assert.AreEqual(_invalidResult.Success, false);
        }
        [TestMethod]
        public void Given_a_valid_command_must_create_Agenda()
        {
            Assert.AreEqual(_validResult.Success, true);
        }
    }
}
