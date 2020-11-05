using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda.Domain.Commands;

namespace Agenda.Domain.Tests.CommandTests
{
    [TestClass]
    public class MarkAgendaAsUndoneCommandTests
    {
        private readonly MarkAgendaAsUndoneCommand _invalidCommand = new MarkAgendaAsUndoneCommand(Guid.NewGuid(), "");
        private readonly MarkAgendaAsUndoneCommand _validCommand = new MarkAgendaAsUndoneCommand(Guid.NewGuid(), "Wilian Braga");
        public MarkAgendaAsUndoneCommandTests()
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
