using MyFinances.WebApi.Models.Domains;
using MyFinances.WebApi.Models.Repositories;

namespace MyFinances.WebApi.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyFinancesContext _context;

        public UnitOfWork(MyFinancesContext context)
        {
            _context = context;
            Operation = new OperationRepository(context);
        }

        public OperationRepository Operation { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
