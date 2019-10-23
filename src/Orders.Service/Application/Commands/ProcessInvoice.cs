using NServiceBus;

// ReSharper disable CheckNamespace
namespace Orders
    // ReSharper restore CheckNamespace
{
    public class ProcessInvoice : ICommand
    {
        public ProcessInvoice(string invoiceNumber, byte[] invoiceFile)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceFile = new DataBusProperty<byte[]>(invoiceFile);
        }
        
        public string InvoiceNumber { get; }

        public DataBusProperty<byte[]> InvoiceFile { get; }
    }
}