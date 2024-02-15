using MyFinances.Core.Dtos;
using MyFinances.Core.Response;
using MyFinances.WebApi.Models.Domains;

namespace MyFinances.WebApi.Models.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly MyFinancesContext _context;

        public OperationRepository(MyFinancesContext context)
        {
            _context = context;
        }
        public IEnumerable<Operation> Get()
        {
            return _context.Operations;
        }

        public Operation Get(int id)
        {
            return _context.Operations.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Operation operation)
        {
            operation.Date = DateTime.Now;
            _context.Operations.Add(operation);
        }

        public void Update(Operation operation)
        {
            var operationToUpdate = _context.Operations.First(x => x.Id == operation.Id);
            operationToUpdate.CategoryId = operation.CategoryId;
            operationToUpdate.Description = operation.Description;
            operationToUpdate.Name = operation.Name;
            operationToUpdate.Value = operation.Value;

            _context.Operations.Update(operationToUpdate);
        }

        public void Delete(int id)
        {
            var operationToDelete = _context.Operations.First(x => x.Id == id);

            _context.Operations.Remove(operationToDelete);
        }

        public IDataPage<Operation> Get(int pageSize, int currentPage)
        {
            var lastPage = (_context.Operations.Count() + pageSize - 1) / pageSize;
            var updatedCurrentPage = lastPage > pageSize * (currentPage - 1)
                                   ? currentPage
                                   : lastPage;

            var operationsPage = _context.Operations
                                         .OrderBy(o => o.Id)
                                         .Skip((updatedCurrentPage - 1) * pageSize)
                                         .Take(pageSize)
                                         .ToList();


            var result = new DataPage<Operation>
            {
                Items = operationsPage,
                LastPage = lastPage,
                CurrentPage = updatedCurrentPage

            };


            return result;

        }


    }
}
