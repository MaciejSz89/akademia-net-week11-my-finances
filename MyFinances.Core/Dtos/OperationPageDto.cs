using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.Core.Dtos
{
    public class OperationPageDto
    {
        public IEnumerable<OperationDto> Operations {  get; set; }
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }

    }
}
