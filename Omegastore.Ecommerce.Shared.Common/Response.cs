using FluentValidation.Results;
using System.Collections.Generic;

namespace Omegastore.Ecommerce.Shared.Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}