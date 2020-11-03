using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1.repos
{
    interface IInvoiceRepo
    {
        Task<IEnumerable<int>> GetInvoices();
        Task<int> GetInvoiceById(int invoiceId);
        Task<int> UpdateInvoiceById(int invoice);
    }
}