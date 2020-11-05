using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Commands;

namespace Agenda.Domain.Tests.CommandTests
{
    [TestClass]
    public class UpdateAgendaCommandTests
    {
        private readonly UpdateAgendaCommand _invalidCommand = new UpdateAgendaCommand(Guid.NewGuid(), "", "");
        private readonly UpdateAgendaCommand _validCommand = new UpdateAgendaCommand(Guid.NewGuid(), "Tarefa criada com sucesso", "Wilian Braga");
        public UpdateAgendaCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Given_an_invalid_command()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }
        [TestMethod]
        public void Given_a_valid_command()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
