using MyFinances.WebApi.Models.Repositories;

namespace MyFinances.WebApi.Models
{
    public interface IUnitOfWork
    {
        OperationRepository Operation { get; set; }

        void Complete();
    }
}