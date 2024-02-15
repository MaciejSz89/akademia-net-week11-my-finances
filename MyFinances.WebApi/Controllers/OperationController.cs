using Microsoft.AspNetCore.Mvc;
using MyFinances.Core.Dtos;
using MyFinances.Core.Response;
using MyFinances.WebApi.Models;
using MyFinances.WebApi.Models.Converters;
using MyFinances.WebApi.Models.Services;

namespace MyFinances.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        //[HttpGet]
        //public IEnumerable<Operation> Get2()
        //{
        //    return _unitOfWork.Operation.Get();
        //}


        //[HttpGet]
        //public IActionResult Get3()
        //{
        //    return Ok(_unitOfWork.Operation.Get());
        //}

        [HttpGet]
        public DataResponse<IEnumerable<OperationDto>> Get()
        {
            var response = new DataResponse<IEnumerable<OperationDto>>();

            try
            {
                response.Data = _operationService.Get();
            }
            catch (Exception exception)
            {
                //logowanie do pliku..
                response.Errors.Add(new Error(exception.Source,
                                              exception.Message));
            }
            return response;
        }

        /// <summary>
        /// Get operation by Id
        /// </summary>
        /// <param name="id">Operation Id</param>
        /// <returns>DataResponse - Operation Dto</returns>
        [HttpGet("{id}")]
        public DataResponse<OperationDto> Get(int id)
        {
            var response = new DataResponse<OperationDto>();

            try
            {
                response.Data = _operationService.Get(id);
            }
            catch (Exception exception)
            {
                //logowanie do pliku..
                response.Errors.Add(new Error(exception.Source,
                                              exception.Message));
            }
            return response;
        }

        [HttpGet("{pageSize}/{currentPage}")]
        public DataResponse<OperationPageDto> Get(int pageSize, int currentPage)
        {
            var response = new DataResponse<OperationPageDto>();

            try
            {
                if (pageSize <= 0)
                    throw  new ArgumentException(nameof(pageSize));

                if (currentPage <= 0)
                    throw new ArgumentException(nameof(currentPage));
                
                response.Data = _operationService.Get(pageSize, currentPage); 
            }
            catch (Exception exception)
            {
                //logowanie do pliku..
                response.Errors.Add(new Error(exception.Source,
                                              exception.Message));
            }
            return response;
        }

        [HttpPost]
        public DataResponse<int> Add(OperationDto operationDto)
        {
            var response = new DataResponse<int>();

            try
            {
                
    
                response.Data = _operationService.Add(operationDto);
            }
            catch (Exception exception)
            {
                //logowanie do pliku..
                response.Errors.Add(new Error(exception.Source,
                                              exception.Message));
            }
            return response;
        }

        [HttpPut]
        public Response Update(OperationDto operationDto)
        {
            var response = new Response();

            try
            {
                _operationService.Update(operationDto);
            }
            catch (Exception exception)
            {
                //logowanie do pliku..
                response.Errors.Add(new Error(exception.Source,
                                              exception.Message));
            }
            return response;
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var response = new Response();

            try
            {
                _operationService.Delete(id);
            }
            catch (Exception exception)
            {
                //logowanie do pliku..
                response.Errors.Add(new Error(exception.Source,
                                              exception.Message));
            }
            return response;
        }
    }
}
