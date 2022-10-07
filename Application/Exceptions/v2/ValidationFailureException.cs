using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Application.Exceptions.v2
{
    public class ValidationFailureException : Exception
    {
        public ValidationFailureException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }
        public ValidationFailureException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
