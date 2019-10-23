using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Orders.Api.Application.Requests
{
    public class SubmitInvoiceRequest
    {
        public string InvoiceNumber { get; set; }
        
        public IFormFile InvoiceFile { get; set; }
        
        public async Task<ProcessInvoice> ToCommand()
        {
            return new ProcessInvoice(InvoiceNumber, await InvoiceFile.GetFileArray());
        }
    }
}