using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Features.Clients.Commands.Create
{
    public class CreateClientCommandValidation : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidation()
        {
            RuleFor(c => c.FirstName).NotNull().NotEmpty();
        }
    }
}
