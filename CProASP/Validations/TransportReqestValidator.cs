using CProASP.Transport.TransportRequest;
using FluentValidation;

namespace CProASP.Validations
{
    public class TransportReqestValidator : AbstractValidator<BaseTransportRequest>
    {
        public TransportReqestValidator()
        {
            RuleFor(x => x.Type).NotNull().NotEmpty();
            RuleFor(x => x.Weight).InclusiveBetween(10, 50);
        }
    }
}
