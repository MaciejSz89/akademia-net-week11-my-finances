using MyFinances.Core.Dtos;
using MyFinances.WebApi.Models.Domains;

namespace MyFinances.WebApi.Models.Converters
{
    public static class OperationConverter
    {
        public static OperationDto ToDto(this Operation model)
        {
            return new OperationDto
            {
                CategoryId = model.CategoryId,
                Date = model.Date,
                Description = model.Description,
                Id = model.Id,
                Name = model.Name,
                Value = model.Value
            };
        }

        public static IEnumerable<OperationDto> ToDtos(this IEnumerable<Operation> model)
        {
            if (model == null)
                return Enumerable.Empty<OperationDto>();
            else 
                return model.Select(x => ToDto(x));
        }

        public static Operation ToDao(this OperationDto model)
        {
            return new Operation
            {
                CategoryId = model.CategoryId,
                Date = model.Date,
                Description = model.Description,
                Id = model.Id,
                Name = model.Name,
                Value = model.Value
            };
        }

        public static OperationPageDto ToDto(this IDataPage<Operation> model)
        {
            return new OperationPageDto
            {
                Operations = model.Items != null ? model.Items.Select(x => x.ToDto()) : Enumerable.Empty<OperationDto>(),
                CurrentPage = model.CurrentPage,
                LastPage = model.LastPage

            };
        }
    }
}
