using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Commands;
using Agenda.Domain.Handlers;
using Agenda.Domain.Tests.Repositories;

namespace Agenda.Domain.Tests.HandlerTests
{
    [TestClass]
    public class UpdateAgendaHandlerTests
    {
        private readonly UpdateAgendaCommand _invalidUpdate = new UpdateAgendaCommand(new Guid(), "", "");
        private readonly UpdateAgendaCommand _validAgenda = new UpdateAgendaCommand(new Guid(), "Tarefa valida", "Willian");

        private readonly AgendaHandler _handler = new AgendaHandler(new FakeAgendaRepository());
        private GenericCommandResult _validResult = new GenericCommandResult();
        private GenericCommandResult _invalidResult = new GenericCommandResult();
        public UpdateAgendaHandlerTests()
        {
            _invalidResult = (GenericCommandResult)_handler.Handle(_invalidUpdate);
            _validResult = (GenericCommandResult)_handler.Handle(_validAgenda);


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
