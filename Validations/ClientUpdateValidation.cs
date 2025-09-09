using FluentValidation;
using PruebaTecnicaKaprielian.Dtos;
using System.Text.RegularExpressions;

namespace PruebaTecnicaKaprielian.Validations
{
    public class ClientUpdateValidation : AbstractValidator<ClienteUpdateDto>
    {
        public ClientUpdateValidation()
        {
            RuleFor(customer => customer.Id).NotNull().GreaterThan(0);
        }
    }
}
