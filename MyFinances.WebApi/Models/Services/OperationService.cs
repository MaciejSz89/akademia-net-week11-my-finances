using MyFinances.Core.Dtos;
using MyFinances.WebApi.Models.Converters;
using MyFinances.WebApi.Models.Domains;

namespace MyFinances.WebApi.Models.Services
{
    public class OperationService : IOperationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OperationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Add(OperationDto operationDto)
        {
            var operation = operationDto.ToDao();
            _unitOfWork.Operation.Add(operation);
            _unitOfWork.Complete();
            return operation.Id;
        }

        public void Delete(int id)
        {
            _unitOfWork.Operation.Delete(id);
            _unitOfWork.Complete();
        }

        public IEnumerable<OperationDto> Get()
        {
            return _unitOfWork.Operation.Get().ToDtos();
        }

        public OperationDto Get(int id)
        {
            return _unitOfWork.Operation.Get(id)?.ToDto();
        }

        public OperationPageDto Get(int pageSize, int currentPage)
        {
            return _unitOfWork.Operation.Get(pageSize, currentPage).ToDto();
        }

        public void Update(OperationDto operationDto)
        {
            _unitOfWork.Operation.Update(operationDto.ToDao());
            _unitOfWork.Complete();
        }
    }
}
