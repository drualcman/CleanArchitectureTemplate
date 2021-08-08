using Core.Application.Features.Clients.Commands.Create;
using Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {

        private readonly IMediator Mediator;

        public ClientsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateClientCommand clientCommand)
        {
            return Ok(await Mediator.Send(clientCommand));
        }
    }
}
