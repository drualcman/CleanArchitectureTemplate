using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Exceptions
{
    public class ValidationException: Exception
    {
        public List<string> Errors { get; } = new List<string>();

        public ValidationException() : base("No paso validaciones") { }

        public ValidationException(IEnumerable<ValidationFailure> fails): this()
        {
            foreach (var item in fails)
            {
                Errors.Add(item.ErrorMessage);
            }
        }

    }
}
