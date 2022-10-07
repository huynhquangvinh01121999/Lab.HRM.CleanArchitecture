using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Application.Exceptions.v2
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException() : base("One or more validation errors occurred.")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }
        public ValidationErrorException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
