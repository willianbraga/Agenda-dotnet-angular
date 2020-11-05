using Agenda.Domain.Commands.Contracts;

namespace Agenda.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult() { }

        public GenericCommandResult(string message, bool success, object data)
        {
            this.Message = message;
            this.Success = success;
            this.Data = data;
        }
        public string Message { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
    }
}