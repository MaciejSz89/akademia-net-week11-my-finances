using MyFinances.WebApi.Models.Domains;

namespace MyFinances.WebApi.Models.Repositories
{
    public interface IOperationRepository
    {
        void Add(Operation operation);
        void Delete(int id);
        IEnumerable<Operation> Get();
        Operation Get(int id);
        IDataPage<Operation> Get(int pageSize, int currentPage);
        void Update(Operation operation);
    }
}