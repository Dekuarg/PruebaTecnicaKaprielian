using FluentValidation;
using PruebaTecnicaKaprielian.Dtos;
using System.Text.RegularExpressions;

namespace PruebaTecnicaKaprielian.Validations
{
    public class ClientesValidations : AbstractValidator<ClientesDto>
    {
        public ClientesValidations()
        {
            RuleFor(c => c.Nombres).NotEmpty().NotNull().MaximumLength(15);
            RuleFor(c => c.Apellidos).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(c => c.Cuit).NotEmpty().NotNull().MaximumLength(11);
            RuleFor(c => c.FechaNacimiento).NotEqual(DateTime.MinValue);
            RuleFor(c => c.Domicilio).MaximumLength(45);
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.TelefonoCelular).NotEmpty().NotNull().MinimumLength(10).MaximumLength(20).Matches(new Regex(@"^(?:\+54)?\s?(?:0?11|0?2\d{1,2})?\s?\d{6,8}$"));
        }
    }
}
