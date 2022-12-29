using MediatR;

namespace C.Service.CQRS.Commands.CustomerCommands
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
