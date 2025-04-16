using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.OrderManagement.Application.DTOs.Client.Request;
using FluentValidation;

namespace CleanArchitecture.OrderManagement.Application.DTOs.Clients.Request
{
    internal class CreateClientRequestValidator: AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
