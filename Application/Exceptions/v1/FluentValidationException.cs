using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Application.Exceptions.v1
{
    public class FluentValidationException : Exception
    {
        public FluentValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }
        public FluentValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
