using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agenda.Domain.Commands;
using Agenda.Domain.Entities;
using Agenda.Domain.Handlers;
using Agenda.Domain.Repositories;

namespace Agenda.Domain.Api.Controllers
{
#pragma warning disable 1591
    [ApiController]
    [Route("v1/Agenda")]
    [Authorize]
    public class AgendaController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IEnumerable<AgendaItem> GetAll(
            [FromServices] IAgendaRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return repository.GetAll(user);
        }
        [Route("done")]
        [HttpGet]
        public IEnumerable<AgendaItem> GetAllDone(
            [FromServices] IAgendaRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return repository.GetAllDone(user);
        }
        [Route("undone")]
        [HttpGet]
        public IEnumerable<AgendaItem> GetAllUndone(
            [FromServices] IAgendaRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return repository.GetAllUndone(user);
        }
        [Route("done/today")]
        [HttpGet]
        public IEnumerable<AgendaItem> GetDoneForToday(
            [FromServices] IAgendaRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date,
                true
            );
        }
        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<AgendaItem> GetUndoneForToday(
            [FromServices] IAgendaRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date,
                false
            );
        }
        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<AgendaItem> GetDoneForTomorrow(
            [FromServices] IAgendaRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                true
            );
        }
        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<AgendaItem> GetUndoneForTomorrow(
        [FromServices] IAgendaRepository repository
        )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                false
            );
        }
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateAgendaCommand command,
            [FromServices] AgendaHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            ;
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateAgendaCommand command,
            [FromServices] AgendaHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkAgendaAsDoneCommand command,
            [FromServices] AgendaHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody] MarkAgendaAsUndoneCommand command,
            [FromServices] AgendaHandler handler
        )
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "name").Value;
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}