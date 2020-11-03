using System.Linq;
using System.Threading.Tasks;
using ConsoleApp1.repos;
using ConsoleApp1.services;

namespace ConsoleApp1
{
    class AlfaTask
    {
        private readonly IAlsekoService _alseko;
        private readonly IInvoiceRepo _invoiceRepo;
        private readonly ILogger _logger;
        
        public AlfaTask(IAlsekoService alseko, IInvoiceRepo invoice, ILogger logger)
        {
            _alseko = alseko;
            _invoiceRepo = invoice;
            _logger = logger;
        }

        private async Task<int> TaskForOneInvoice(int invoiceId)
        { 
            var invoice = await _invoiceRepo.GetInvoiceById(invoiceId);
            var updatedInvoice = await _invoiceRepo.UpdateInvoiceById(invoice);
            await _alseko.PayInvoice(updatedInvoice);
            return await _invoiceRepo.UpdateInvoiceById(updatedInvoice);
        }

        public async void TestTask()
        {
            //либо можно дергать логгер после Task.WhenAll(), вместо PLINQ
            (await _alseko.GetInvoices()).AsParallel()
                .Select(async x => await TaskForOneInvoice(x))
                .ForAll(async x => await _logger.LogInfo($"updated successfully | invoiceId: {x}"));
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}