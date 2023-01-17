using MediatR;
using System.ComponentModel.DataAnnotations;

namespace C.Service.CQRS.Commands.CustomerCommands
{
    public class DeleteCustomerCommand : IRequest<bool>
    {
        [Required]
        public int Id { get; set; }
    }
}
