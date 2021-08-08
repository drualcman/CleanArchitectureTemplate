using Core.Abstractions;
using Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Features.Clients.Commands.Create
{
    public class CreateClientCommand : IRequest<Client>
    {
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Notes { get; set; }

        internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Client>
        {
            private readonly IRepository<Client> Repository;
            public CreateClientCommandHandler(IRepository<Client> repository)
            {
                Repository = repository;
            }

            async Task<Client> IRequestHandler<CreateClientCommand, Client>.Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                Client data = new Client
                {
                    Phone = request.Phone,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Company = request.Company,
                    City = request.City,
                    Notes = request.Notes
                };
                await Repository.Add(data);
                return data;
            }
        }
    }
}
