﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new List<ValidationFailure>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures;
            //.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            //.ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IEnumerable<ValidationFailure> Errors { get; }
    }
}
