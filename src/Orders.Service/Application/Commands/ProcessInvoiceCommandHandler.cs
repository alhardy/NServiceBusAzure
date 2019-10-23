using System;
using System.Threading.Tasks;
using NServiceBus;

namespace Orders.Service.Application.Commands
{
    public class ProcessInvoiceCommandHandler : IHandleMessages<ProcessInvoice>
    {
        public Task Handle(ProcessInvoice command, IMessageHandlerContext context)
        {
            Console.WriteLine($"Received Invoice {command.InvoiceNumber}, Invoice Size: {command.InvoiceFile.Value.Length}");

            return Task.CompletedTask;
        }
    }
}