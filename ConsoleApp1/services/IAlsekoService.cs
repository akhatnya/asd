using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1.services
{
    public interface IAlsekoService
    {
        Task<IEnumerable<int>> GetInvoices();
        Task<int> PayInvoice(int invoiceId);
    }
}