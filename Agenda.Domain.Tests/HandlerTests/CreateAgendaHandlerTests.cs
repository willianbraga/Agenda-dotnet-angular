using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Commands;
using Agenda.Domain.Handlers;
using Agenda.Domain.Tests.Repositories;

namespace Agenda.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateAgendaHandlerTests
    {
        private readonly CreateAgendaCommand _invalidCommand = new CreateAgendaCommand("", "", DateTime.Now);
        private readonly CreateAgendaCommand _validCommand = new CreateAgendaCommand("Titulo da Tarefa", "Willian", DateTime.Now);
        private readonly AgendaHandler _handler = new AgendaHandler(new FakeAgendaRepository());
        private GenericCommandResult _validResult = new GenericCommandResult();
        private GenericCommandResult _invalidResult = new GenericCommandResult();


        public CreateAgendaHandlerTests()
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
