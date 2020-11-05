using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Commands;

namespace Agenda.Domain.Tests.CommandTests
{
    [TestClass]
    public class MarkAgendaAsDoneCommandTests
    {
        private readonly MarkAgendaAsDoneCommand _invalidCommand = new MarkAgendaAsDoneCommand(Guid.NewGuid(), "");
        private readonly MarkAgendaAsDoneCommand _validCommand = new MarkAgendaAsDoneCommand(Guid.NewGuid(), "Wilian Braga");
        public MarkAgendaAsDoneCommandTests()
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
