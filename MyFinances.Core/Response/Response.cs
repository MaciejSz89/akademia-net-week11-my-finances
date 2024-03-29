﻿using System.Collections.Generic;
using System.Linq;

namespace MyFinances.Core.Response
{
    public class Response
    {
        public Response()
        {
            Errors = new List<Error>();
        }
        public bool IsSuccess => Errors == null || !Errors.Any();

        public List<Error> Errors { get; set; }

    }
}
