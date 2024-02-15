using MyFinances.Core.Dtos;
using MyFinances.WebApi.Models.Domains;

namespace MyFinances.WebApi.Models.Services
{
    public interface IOperationService
    {
        int Add(OperationDto operationDto);
        void Delete(int id);
        IEnumerable<OperationDto> Get();
        OperationDto Get(int id);
        OperationPageDto Get(int pageSize, int currentPage);
        void Update(OperationDto operationDto);
    }
}
