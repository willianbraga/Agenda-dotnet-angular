using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Commands;
using Agenda.Domain.Handlers;
using Agenda.Domain.Tests.Repositories;

namespace Agenda.Domain.Tests.HandlerTests
{
    [TestClass]
    public class MarkAsUndoneAgendaHandlerTests
    {
        private readonly MarkAgendaAsUndoneCommand _invalidAgenda = new MarkAgendaAsUndoneCommand(new Guid(), "Willian");
        private readonly AgendaHandler _handle = new AgendaHandler(new FakeAgendaRepository());
        private GenericCommandResult _validResult = new GenericCommandResult();
        private GenericCommandResult _invalidResult = new GenericCommandResult();

        public MarkAsUndoneAgendaHandlerTests()
        {
            _invalidResult = (GenericCommandResult)_handle.Handle(new MarkAgendaAsUndoneCommand());
            _validResult = (GenericCommandResult)_handle.Handle(_invalidAgenda);
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
