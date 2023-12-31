﻿using MyFinances.WebApi.Models.Domains;

namespace MyFinances.WebApi.Models.Repositories
{
    public class OperationRepository
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

        public IEnumerable<Operation> Get(int pageSize, int currentPage)
        {

            return _context.Operations
                           .OrderBy(o => o.Id)
                           .Skip((currentPage - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();

        }


}
}
