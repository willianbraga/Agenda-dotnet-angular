using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Commands;

namespace Agenda.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateAgendaCommandTests
    {
        private readonly CreateAgendaCommand _invalidCommand = new CreateAgendaCommand("", "", DateTime.Now);
        private readonly CreateAgendaCommand _validCommand = new CreateAgendaCommand("Titulo da Tarefa", "Wilian Braga", DateTime.Now);
        public CreateAgendaCommandTests()
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
