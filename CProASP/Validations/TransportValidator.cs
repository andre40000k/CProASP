using CProASP.Transport.Transport;
using CProASP.Transport.TransportRequest;
using FluentValidation;

namespace CProASP.Validations
{
    public class TransportValidator : AbstractValidator<BaseTransport>
    {
        public TransportValidator() 
        { 
            RuleFor(x => x.Type).NotNull().NotEmpty();
            RuleFor(x => x.Weight).InclusiveBetween(10, 50);
        }
    }
}
